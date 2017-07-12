namespace CLCode
{
    partial class Main
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
            this.grpFolders = new System.Windows.Forms.GroupBox();
            this.grpLogging = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.clbSelected = new System.Windows.Forms.CheckedListBox();
            this.btnProcess = new System.Windows.Forms.Button();
            this.lvLog = new System.Windows.Forms.ListView();
            this.grpFolders.SuspendLayout();
            this.grpLogging.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpFolders
            // 
            this.grpFolders.Controls.Add(this.btnProcess);
            this.grpFolders.Controls.Add(this.clbSelected);
            this.grpFolders.Controls.Add(this.txtFolder);
            this.grpFolders.Controls.Add(this.label1);
            this.grpFolders.Location = new System.Drawing.Point(12, 12);
            this.grpFolders.Name = "grpFolders";
            this.grpFolders.Size = new System.Drawing.Size(299, 366);
            this.grpFolders.TabIndex = 0;
            this.grpFolders.TabStop = false;
            // 
            // grpLogging
            // 
            this.grpLogging.Controls.Add(this.lvLog);
            this.grpLogging.Location = new System.Drawing.Point(317, 12);
            this.grpLogging.Name = "grpLogging";
            this.grpLogging.Size = new System.Drawing.Size(299, 366);
            this.grpLogging.TabIndex = 1;
            this.grpLogging.TabStop = false;
            this.grpLogging.Text = "Logging";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Folder";
            // 
            // txtFolder
            // 
            this.txtFolder.Location = new System.Drawing.Point(76, 17);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(217, 20);
            this.txtFolder.TabIndex = 1;
            this.txtFolder.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtFolder_MouseDoubleClick);
            // 
            // clbSelected
            // 
            this.clbSelected.FormattingEnabled = true;
            this.clbSelected.Location = new System.Drawing.Point(10, 43);
            this.clbSelected.Name = "clbSelected";
            this.clbSelected.Size = new System.Drawing.Size(283, 274);
            this.clbSelected.TabIndex = 2;
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(10, 324);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(75, 23);
            this.btnProcess.TabIndex = 3;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // lvLog
            // 
            this.lvLog.Location = new System.Drawing.Point(7, 20);
            this.lvLog.Name = "lvLog";
            this.lvLog.Size = new System.Drawing.Size(286, 297);
            this.lvLog.TabIndex = 0;
            this.lvLog.UseCompatibleStateImageBehavior = false;
            this.lvLog.View = System.Windows.Forms.View.Details;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 390);
            this.Controls.Add(this.grpLogging);
            this.Controls.Add(this.grpFolders);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(638, 429);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(638, 429);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Interface";
            this.Load += new System.EventHandler(this.Main_Load);
            this.grpFolders.ResumeLayout(false);
            this.grpFolders.PerformLayout();
            this.grpLogging.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpFolders;
        private System.Windows.Forms.CheckedListBox clbSelected;
        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpLogging;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.ListView lvLog;
    }
}

