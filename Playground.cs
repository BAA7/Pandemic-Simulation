using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;

namespace PandemicSimulation
{
    public partial class Playground : Form
    {
        public Playground()
        {
            InitializeComponent();
        }
        List<Point> citizens = new List<Point>();
        int stepsMade;
        private void btnStart_Click(object sender, EventArgs e)
        {
            this.btnStart.Hide();
            this.btnStart.Enabled = false;
            txtInfect.Visible = false;
            txtSymptoms.Visible = false;
            trackInfect.Visible = false;
            trackInfect.Enabled = false;
            trackSymptoms.Visible = false;
            trackSymptoms.Enabled = false;
            comboAlgoritm.Visible = false;
            comboAlgoritm.Enabled = false;
            txtAlgo.Hide();

            Random rand = new Random();
            stepsMade = 0;
            DataBase.citizensAmount = 25;
            DataBase.ill = new int[DataBase.citizensAmount];
            DataBase.socialLink = new int[DataBase.citizensAmount, DataBase.citizensAmount];
            DataBase.isolation = new bool[DataBase.citizensAmount];
            DataBase.isolationDays = new int[DataBase.citizensAmount];
            DataBase.cureResist = 3;
            DataBase.economyLevel = 12;
            DataBase.infectiousness = trackInfect.Value;
            DataBase.symptomsVisibility = trackSymptoms.Value;
            int diseaseTargetsAmount = 3;
            for (int i = 0; i < DataBase.citizensAmount; i++)
            {
                citizens.Add(new Point());
            }
            for(int i = 0; i < DataBase.socialLink.GetLength(0); i++)
            {
                DataBase.ill[i] = 0;
                DataBase.isolation[i] = false;
                DataBase.isolationDays[i] = 0;
                for(int j = i+1; j < DataBase.socialLink.GetLength(1); j++)
                {
                    DataBase.socialLink[i, j] = rand.Next(10)/9;
                    DataBase.socialLink[j, i] = DataBase.socialLink[i, j];
                }
            }
            while (!isLinked(DataBase.socialLink))
            {
                for (int i = 0; i < DataBase.socialLink.GetLength(0); i++)
                {
                    for (int j = i+1; j < DataBase.socialLink.GetLength(1); j++)
                    {
                        DataBase.socialLink[i, j] = rand.Next(10) / 9;
                        DataBase.socialLink[j, i] = DataBase.socialLink[i, j];
                    }
                }
            }
            for(int i = 1; i < DataBase.citizensAmount; i++)
            {
                for(int j = 0; j < i; j++)
                {
                    DataBase.socialLink[i, j] = DataBase.socialLink[j, i];
                }
            }

            for (int i = 0; i < diseaseTargetsAmount; i++)
            {
                DataBase.ill[rand.Next(DataBase.citizensAmount)] = 1;
            }

            citizens[0] = new Point(285, 270);
            // 1-9
            int radius = 150;
            double fi = Math.PI * 2 / 9;
            for(int i = 1; i < 10; i++)
            {
                int x = Convert.ToInt32(285 + radius * Math.Sin(fi * (i - 1)));
                int y = Convert.ToInt32(270 + radius * Math.Cos(fi * (i - 1)));
                citizens[i] = new Point(x, y);
            }
            // 10-24
            radius = 250;
            fi = Math.PI * 2 / 15;
            for (int i = 10; i < DataBase.citizensAmount; i++)
            {
                int x = Convert.ToInt32(285 + radius * Math.Sin(fi * (i - 10) + Math.PI / 20));
                int y = Convert.ToInt32(270 + radius * Math.Cos(fi * (i - 10) + Math.PI / 20));
                citizens[i] = new Point(x, y);
            }

            printGraph();
            solution();
        }

        private bool isLinked(int[,] a) // алгоритм Флойда-Уоршелла
        {
            bool[,] ans = new bool[DataBase.citizensAmount, DataBase.citizensAmount];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(0); j++)
                {
                    ans[i, j] = a[i,j]>0;
                }
            }
            for (int k = 0; k < a.GetLength(0); k++)
            {
                for(int i = 0; i < a.GetLength(0); i++)
                {
                    for(int j = 0; j < a.GetLength(0); j++)
                    {
                        ans[i, j] = ans[i, j] || ans[i, k] && ans[k, j];
                    }
                }
            }
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(0); j++)
                {
                    if (!ans[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void solutionWidth() // обход в ширину
        {      
            bool[] check= new bool[DataBase.citizensAmount];
            for(int i = 0; i < DataBase.citizensAmount; i++)
            {
                check[i] = false;
            }
            Queue<int> q = new Queue<int>();
            Random rand = new Random();
            q.Enqueue(rand.Next(DataBase.citizensAmount));
            while (q.Count > 0)
            {
                foreach (int i in q)
                {
                    isolate(i);
                }
                //Thread.Sleep(1000);
                for (int i = 0; i < DataBase.cureResist; i++)
                {
                    step();
                    if (defeat(DataBase.ill) || victory(DataBase.ill))
                    {
                        return;
                    }
                    //Thread.Sleep(1000);
                }
                List<int> neighbours = new List<int>();
                foreach (int i in q)
                {
                    check[i] = true;
                    isolate(i);
                    for (int j = 0; j < DataBase.citizensAmount; j++)
                    {
                        if (DataBase.socialLink[i, j] > 0 && !check[j] && !DataBase.isolation[j])
                        {
                            if (!neighbours.Contains(j))
                            {
                                neighbours.Add(j);
                            }
                        }
                    }
                }
                //Thread.Sleep(1000);
                q.Clear();
                foreach(int i in neighbours)
                {
                    q.Enqueue(i);
                }
            }
        }

        private void solutionProbability(int diseaseTargetsAmount) // метод вероятностей
        {
            bool hasSickFriend(int a)
            {
                for(int i = 0; i < DataBase.citizensAmount; i++)
                {
                    if (i != a && DataBase.ill[i] == 2)
                    {
                        return true;
                    }
                }
                return false;
            }
            int isolatedAmount = 0;
            int[] daysWithoutSymptoms = new int[DataBase.citizensAmount];
            int[] daysWithSickFriend = new int[DataBase.citizensAmount];
            double[] P = new double[DataBase.citizensAmount];
            for(int i = 0; i < P.Length; i++)
            {
                P[i] = diseaseTargetsAmount / DataBase.citizensAmount;
                daysWithoutSymptoms[i] = 0;
                daysWithSickFriend[i] = 0;
            }
            while (true)
            {
                step();
                //Thread.Sleep(1000);
                if (defeat(DataBase.ill) || victory(DataBase.ill))
                {
                    return;
                }
                for(int i = 0; i < DataBase.citizensAmount; i++)
                {
                    if (DataBase.ill[i] == 2)
                    {
                        P[i] = 1;
                        daysWithoutSymptoms[i] = 0;
                    }
                    else if (hasSickFriend(i))
                    {
                        daysWithSickFriend[i]++;
                        P[i] = 0.9;
                    }
                    else
                    {
                        daysWithoutSymptoms[i]++;
                        if (DataBase.isolationDays[i] > DataBase.cureResist)
                        {
                            P[i] = 0;
                        }
                        else
                        {
                            P[i] = Math.Pow(1 - (double)DataBase.symptomsVisibility / 10, daysWithoutSymptoms[i]);
                        }
                    }
                }
                for(int i = 0; i < DataBase.citizensAmount; i++)
                {
                    if (P[i] == 1 && isolatedAmount<DataBase.economyLevel)
                    {
                        isolate(i);
                        isolatedAmount++;
                    }
                }
                if (isolatedAmount == 0)
                {
                    isolate(0);
                    isolatedAmount++;
                }
                while (isolatedAmount < DataBase.economyLevel)
                {
                    for(int i = 0; i < DataBase.citizensAmount; i++)
                    {
                        if (DataBase.isolation[i])
                        {
                            for(int j = 0; j < DataBase.citizensAmount; j++)
                            {
                                if (isolatedAmount >= DataBase.economyLevel)
                                {
                                    break;
                                }
                                if (DataBase.socialLink[i, j] > 0 && !DataBase.isolation[j] && isolatedAmount<DataBase.economyLevel){
                                    isolate(j);
                                    isolatedAmount++;
                                }
                            }
                        }
                    }
                }
                for(int i = 0; i < DataBase.citizensAmount; i++)
                {
                    if (DataBase.isolation[i])
                    {
                        for (int j = 0; j < DataBase.citizensAmount; j++)
                        {
                            if (!DataBase.isolation[j] && P[j] > P[i] &&DataBase.isolation[i])
                            {
                                isolate(i);
                                isolate(j);
                            }
                        }
                    }
                }
                printGraph();
                //Thread.Sleep(1000);
            }
        }

        private void solution()
        {
            switch (comboAlgoritm.Text)
            {
                case "обход в ширину":
                    solutionWidth();
                    break;
                case "метод вероятностей":
                    solutionProbability(3);
                    break;
                default:
                    solutionWidth();
                    break;
            }
        }

        private void step() // завершение хода
        {
            //moveCounter.Text = Convert.ToString(++stepsMade, 10) + " moves";
            stepsMade++;
            Random rand = new Random();
            for (int i = 0; i < DataBase.citizensAmount; i++)
            {
                if (DataBase.isolation[i])
                {
                    DataBase.isolationDays[i]++;
                }
                if (DataBase.isolationDays[i] >= DataBase.cureResist)
                {
                    DataBase.ill[i] = 0;
                }
                if (DataBase.ill[i] > 0)
                {
                    for (int j = 0; j < DataBase.citizensAmount; j++)
                    {
                        if (DataBase.socialLink[i,j] == 1 && DataBase.ill[j] == 0)
                        {
                            DataBase.ill[j] = rand.Next(10) / (10 - DataBase.infectiousness);
                            if (DataBase.ill[j] > 0)
                            {
                                DataBase.ill[j] = 1;
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < DataBase.citizensAmount; i++)
            {
                if (DataBase.ill[i] == 1)
                {
                    DataBase.ill[i] = rand.Next(100) / (10 - DataBase.symptomsVisibility);
                    if (DataBase.ill[i] > 0)
                    {
                        DataBase.ill[i] = 2;
                    }
                    else
                    {
                        DataBase.ill[i] = 1;
                    }
                }
            }
            printGraph();
            //Thread.Sleep(1000);
            if (defeat(DataBase.ill))
            {
                EndWindow pg = new EndWindow();
                pg.moveCounter.Text = "in " + stepsMade + " moves";
                pg.ShowDialog();
                return;
            }
            if (victory(DataBase.ill))
            {
                EndWindow pg = new EndWindow();
                pg.txtLose.Text = "VICTORY";
                pg.moveCounter.Text = "in " + stepsMade + " moves";
                pg.ShowDialog();
                return;
            }
        }

        private void btnStep_Click(object sender, EventArgs e)
        {
            step();

        }

        // проверка, закончена ли игра
        private bool defeat(int[] a)
        {
            for(int i = 0; i < a.Length; i++)
            {
                if (a[i] == 0)
                {
                    return false;
                }
            }
            return true;
        }

        private bool victory(int[] a)
        {
            for(int i = 0; i < a.Length; i++)
            {
                if (a[i] > 0)
                {
                    return false;
                }
            }
            return true;
        }

        private void printGraph()
        {
            Graphics gObject = canvas.CreateGraphics();
            Pen activeLink = new Pen(Color.Black, 3f);
            Pen inactiveLink = new Pen(Color.FromKnownColor(KnownColor.ControlDarkDark), 3f);
            SolidBrush citizenHealthy = new SolidBrush(Color.Black);
            SolidBrush citizenIll = new SolidBrush(Color.Red);
            Point pointI = new Point(0,0);
            Point pointJ = new Point(0,0);
            for(int i = 0; i < DataBase.citizensAmount; i++)
            {
                Rectangle rect = new Rectangle(citizens[i].X, citizens[i].Y, 30, 30);
                if (!DataBase.isolation[i])
                {
                    gObject.DrawRectangle(new Pen(Color.FromKnownColor(KnownColor.Control), 3f), rect);
                }
            }
            for (int i = 0; i < DataBase.socialLink.GetLength(0); i++)
            {
                pointI.X = citizens[i].X + 15;
                pointI.Y = citizens[i].Y + 15;
                Rectangle rect = new Rectangle(citizens[i].X, citizens[i].Y, 30, 30);
                for (int j = i+1; j < DataBase.socialLink.GetLength(1); j++)
                {
                    if (DataBase.socialLink[i, j] > 0)
                    {
                        pointJ.X = citizens[j].X + 15;
                        pointJ.Y = citizens[j].Y + 15;
                        if (DataBase.socialLink[i, j] == 1)
                        {
                            gObject.DrawLine(activeLink, pointI, pointJ);
                        }
                        else
                        {
                            gObject.DrawLine(inactiveLink, pointI, pointJ);
                        }
                    }
                }
                if (DataBase.isolation[i])
                {
                    gObject.DrawRectangle(activeLink, rect);
                }
            }
            for(int i = 0; i < DataBase.citizensAmount; i++)
            {
                Rectangle rect = new Rectangle(citizens[i].X, citizens[i].Y, 30, 30);
                if (DataBase.ill[i] < 2)
                {
                    gObject.FillEllipse(citizenHealthy, rect);
                }
                else
                {
                    gObject.FillEllipse(citizenIll, rect);
                }
            }
            canvas.SendToBack();
        }

        private void isolate(int i)
        {
            if (DataBase.isolation[i] == false)
            {
                
                DataBase.isolation[i] = true;
                for(int j = 0; j < DataBase.citizensAmount; j++)
                {
                    if (DataBase.socialLink[i, j] == 1)
                    {
                        DataBase.socialLink[i, j] = 2;
                        DataBase.socialLink[j, i] = 2;
                    }
                }
            }
            else
            {
                DataBase.isolation[i] = false;
                DataBase.isolationDays[i] = 0;
                for (int j = 0; j < DataBase.citizensAmount; j++)
                {
                    if (DataBase.socialLink[i, j] == 2 && !DataBase.isolation[j])
                    {
                        DataBase.socialLink[i, j] = 1;
                        DataBase.socialLink[j, i] = 1;
                    }
                }
            }
            printGraph();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            /*Graphics gObject = canvas.CreateGraphics();
            Pen pen = new Pen(Color.Black, 3f);
            gObject.DrawLine(pen, 285,285,300,300);*/
        }
    }
}
