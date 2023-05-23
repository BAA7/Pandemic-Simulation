
namespace PandemicSimulation
{
    partial class EndWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtLose = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.moveCounter = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtLose
            // 
            this.txtLose.AutoSize = true;
            this.txtLose.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtLose.Location = new System.Drawing.Point(185, 67);
            this.txtLose.Name = "txtLose";
            this.txtLose.Size = new System.Drawing.Size(424, 108);
            this.txtLose.TabIndex = 0;
            this.txtLose.Text = "DEFEAT";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(364, 254);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "exit";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // moveCounter
            // 
            this.moveCounter.AutoSize = true;
            this.moveCounter.Font = new System.Drawing.Font("Trebuchet MS", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.moveCounter.Location = new System.Drawing.Point(319, 185);
            this.moveCounter.Name = "moveCounter";
            this.moveCounter.Size = new System.Drawing.Size(170, 40);
            this.moveCounter.TabIndex = 2;
            this.moveCounter.Text = "in 0 moves";
            // 
            // EndWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 328);
            this.Controls.Add(this.moveCounter);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtLose);
            this.Name = "EndWindow";
            this.Text = "Playground";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label txtLose;
        public System.Windows.Forms.Button btnOk;
        public System.Windows.Forms.Label moveCounter;
    }
}

