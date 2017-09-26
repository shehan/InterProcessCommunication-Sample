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
            this.textBoxHeartbeatLog = new System.Windows.Forms.TextBox();
            this.buttonTerminate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonLaunch
            // 
            this.buttonLaunch.Location = new System.Drawing.Point(12, 12);
            this.buttonLaunch.Name = "buttonLaunch";
            this.buttonLaunch.Size = new System.Drawing.Size(342, 23);
            this.buttonLaunch.TabIndex = 0;
            this.buttonLaunch.Text = "Start";
            this.buttonLaunch.UseVisualStyleBackColor = true;
            this.buttonLaunch.Click += new System.EventHandler(this.buttonLaunch_Click);
            // 
            // textBoxHeartbeatLog
            // 
            this.textBoxHeartbeatLog.Location = new System.Drawing.Point(12, 46);
            this.textBoxHeartbeatLog.Multiline = true;
            this.textBoxHeartbeatLog.Name = "textBoxHeartbeatLog";
            this.textBoxHeartbeatLog.ReadOnly = true;
            this.textBoxHeartbeatLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxHeartbeatLog.Size = new System.Drawing.Size(342, 229);
            this.textBoxHeartbeatLog.TabIndex = 2;
            // 
            // buttonTerminate
            // 
            this.buttonTerminate.Location = new System.Drawing.Point(12, 290);
            this.buttonTerminate.Name = "buttonTerminate";
            this.buttonTerminate.Size = new System.Drawing.Size(342, 23);
            this.buttonTerminate.TabIndex = 3;
            this.buttonTerminate.Text = "Terminate";
            this.buttonTerminate.UseVisualStyleBackColor = true;
            this.buttonTerminate.Click += new System.EventHandler(this.buttonTerminate_Click);
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 350);
            this.Controls.Add(this.buttonTerminate);
            this.Controls.Add(this.textBoxHeartbeatLog);
            this.Controls.Add(this.buttonLaunch);
            this.Name = "DashboardForm";
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.DashboardForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLaunch;
        private System.Windows.Forms.TextBox textBoxHeartbeatLog;
        private System.Windows.Forms.Button buttonTerminate;
    }
}

