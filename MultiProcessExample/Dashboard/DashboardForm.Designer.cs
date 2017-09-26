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
            this.buttonTerminate = new System.Windows.Forms.Button();
            this.textBoxHeartbeatLog = new System.Windows.Forms.RichTextBox();
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
            // textBoxHeartbeatLog
            // 
            this.textBoxHeartbeatLog.Location = new System.Drawing.Point(12, 41);
            this.textBoxHeartbeatLog.Name = "textBoxHeartbeatLog";
            this.textBoxHeartbeatLog.ReadOnly = true;
            this.textBoxHeartbeatLog.Size = new System.Drawing.Size(342, 243);
            this.textBoxHeartbeatLog.TabIndex = 4;
            this.textBoxHeartbeatLog.Text = "";
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 325);
            this.Controls.Add(this.textBoxHeartbeatLog);
            this.Controls.Add(this.buttonTerminate);
            this.Controls.Add(this.buttonLaunch);
            this.Name = "DashboardForm";
            this.Text = "Dashboard";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.DashboardForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonLaunch;
        private System.Windows.Forms.Button buttonTerminate;
        private System.Windows.Forms.RichTextBox textBoxHeartbeatLog;
    }
}

