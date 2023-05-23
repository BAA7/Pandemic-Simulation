
namespace PandemicSimulation
{
    partial class Playground
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStart = new System.Windows.Forms.Button();
            this.canvas = new System.Windows.Forms.Panel();
            this.txtAlgo = new System.Windows.Forms.Label();
            this.comboAlgoritm = new System.Windows.Forms.ComboBox();
            this.txtSymptoms = new System.Windows.Forms.Label();
            this.trackSymptoms = new System.Windows.Forms.TrackBar();
            this.txtInfect = new System.Windows.Forms.Label();
            this.trackInfect = new System.Windows.Forms.TrackBar();
            this.canvas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackSymptoms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackInfect)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Trebuchet MS", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStart.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnStart.Location = new System.Drawing.Point(225, 162);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(150, 64);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Начать";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.SystemColors.Control;
            this.canvas.Controls.Add(this.txtAlgo);
            this.canvas.Controls.Add(this.comboAlgoritm);
            this.canvas.Controls.Add(this.txtSymptoms);
            this.canvas.Controls.Add(this.trackSymptoms);
            this.canvas.Controls.Add(this.txtInfect);
            this.canvas.Controls.Add(this.trackInfect);
            this.canvas.Location = new System.Drawing.Point(0, 0);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(584, 561);
            this.canvas.TabIndex = 2;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint);
            // 
            // txtAlgo
            // 
            this.txtAlgo.AutoSize = true;
            this.txtAlgo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtAlgo.Location = new System.Drawing.Point(33, 283);
            this.txtAlgo.Name = "txtAlgo";
            this.txtAlgo.Size = new System.Drawing.Size(84, 20);
            this.txtAlgo.TabIndex = 6;
            this.txtAlgo.Text = "Алгоритм";
            // 
            // comboAlgoritm
            // 
            this.comboAlgoritm.FormattingEnabled = true;
            this.comboAlgoritm.Items.AddRange(new object[] {
            "обход в ширину",
            "метод вероятностей"});
            this.comboAlgoritm.Location = new System.Drawing.Point(12, 307);
            this.comboAlgoritm.Name = "comboAlgoritm";
            this.comboAlgoritm.Size = new System.Drawing.Size(148, 21);
            this.comboAlgoritm.TabIndex = 5;
            this.comboAlgoritm.Text = "обход в ширину";
            // 
            // txtSymptoms
            // 
            this.txtSymptoms.AutoSize = true;
            this.txtSymptoms.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtSymptoms.Location = new System.Drawing.Point(205, 366);
            this.txtSymptoms.Name = "txtSymptoms";
            this.txtSymptoms.Size = new System.Drawing.Size(183, 20);
            this.txtSymptoms.TabIndex = 4;
            this.txtSymptoms.Text = "Видимость симптомов";
            // 
            // trackSymptoms
            // 
            this.trackSymptoms.Location = new System.Drawing.Point(180, 389);
            this.trackSymptoms.Maximum = 9;
            this.trackSymptoms.Minimum = 1;
            this.trackSymptoms.Name = "trackSymptoms";
            this.trackSymptoms.Size = new System.Drawing.Size(243, 45);
            this.trackSymptoms.TabIndex = 3;
            this.trackSymptoms.Value = 1;
            // 
            // txtInfect
            // 
            this.txtInfect.AutoSize = true;
            this.txtInfect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtInfect.Location = new System.Drawing.Point(249, 264);
            this.txtInfect.Name = "txtInfect";
            this.txtInfect.Size = new System.Drawing.Size(99, 20);
            this.txtInfect.TabIndex = 2;
            this.txtInfect.Text = "Заразность";
            // 
            // trackInfect
            // 
            this.trackInfect.Location = new System.Drawing.Point(180, 283);
            this.trackInfect.Maximum = 9;
            this.trackInfect.Minimum = 1;
            this.trackInfect.Name = "trackInfect";
            this.trackInfect.Size = new System.Drawing.Size(243, 45);
            this.trackInfect.TabIndex = 1;
            this.trackInfect.Value = 1;
            // 
            // Playground
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 562);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.canvas);
            this.Name = "Playground";
            this.Text = "MainMenu";
            this.canvas.ResumeLayout(false);
            this.canvas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackSymptoms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackInfect)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Panel canvas;
        private System.Windows.Forms.TrackBar trackInfect;
        private System.Windows.Forms.Label txtSymptoms;
        private System.Windows.Forms.TrackBar trackSymptoms;
        private System.Windows.Forms.Label txtInfect;
        private System.Windows.Forms.ComboBox comboAlgoritm;
        private System.Windows.Forms.Label txtAlgo;
    }
}