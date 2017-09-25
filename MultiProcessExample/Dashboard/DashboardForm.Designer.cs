namespace Dashboard
{
    partial class DashboardForm
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
            this.buttonLaunch = new System.Windows.Forms.Button();
            this.labelTime = new System.Windows.Forms.Label();
            this.textBoxProcess = new System.Windows.Forms.TextBox();
            this.buttonTerminate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonLaunch
            // 
            this.buttonLaunch.Location = new System.Drawing.Point(74, 54);
            this.buttonLaunch.Name = "buttonLaunch";
            this.buttonLaunch.Size = new System.Drawing.Size(75, 23);
            this.buttonLaunch.TabIndex = 0;
            this.buttonLaunch.Text = "Start";
            this.buttonLaunch.UseVisualStyleBackColor = true;
            this.buttonLaunch.Click += new System.EventHandler(this.buttonLaunch_Click);
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(40, 30);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(0, 13);
            this.labelTime.TabIndex = 1;
            // 
            // textBoxProcess
            // 
            this.textBoxProcess.Location = new System.Drawing.Point(34, 94);
            this.textBoxProcess.Multiline = true;
            this.textBoxProcess.Name = "textBoxProcess";
            this.textBoxProcess.Size = new System.Drawing.Size(193, 102);
            this.textBoxProcess.TabIndex = 2;
            // 
            // buttonTerminate
            // 
            this.buttonTerminate.Location = new System.Drawing.Point(74, 212);
            this.buttonTerminate.Name = "buttonTerminate";
            this.buttonTerminate.Size = new System.Drawing.Size(75, 23);
            this.buttonTerminate.TabIndex = 3;
            this.buttonTerminate.Text = "Terminate";
            this.buttonTerminate.UseVisualStyleBackColor = true;
            this.buttonTerminate.Click += new System.EventHandler(this.buttonTerminate_Click);
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.buttonTerminate);
            this.Controls.Add(this.textBoxProcess);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.buttonLaunch);
            this.Name = "DashboardForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.DashboardForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLaunch;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.TextBox textBoxProcess;
        private System.Windows.Forms.Button buttonTerminate;
    }
}

