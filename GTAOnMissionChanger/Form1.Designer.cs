namespace GTAOnMissionChanger
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblGame = new System.Windows.Forms.Label();
            this.lblValue = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.tmrGameVersion = new System.Windows.Forms.Timer(this.components);
            this.tmrOnMission = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showDebugInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblisAdmin = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiForceState = new System.Windows.Forms.ToolStripMenuItem();
            this.playBeepWhenOMChangesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.useNewAddressesForGTASAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiChangeKey = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCheckUpdatesOnStartup = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCheckForUpdates = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.viewSourceCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblGame
            // 
            this.lblGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGame.Location = new System.Drawing.Point(-2, 48);
            this.lblGame.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGame.Name = "lblGame";
            this.lblGame.Size = new System.Drawing.Size(538, 25);
            this.lblGame.TabIndex = 0;
            this.lblGame.Text = "- No game running or unrecognized version -";
            this.lblGame.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblValue
            // 
            this.lblValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValue.Location = new System.Drawing.Point(-4, 88);
            this.lblValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(542, 37);
            this.lblValue.TabIndex = 1;
            this.lblValue.Text = "Loading...";
            this.lblValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInfo
            // 
            this.lblInfo.Location = new System.Drawing.Point(2, 137);
            this.lblInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(536, 28);
            this.lblInfo.TabIndex = 2;
            this.lblInfo.Text = "Press F6 to toggle the \'On Mission\' variable";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tmrGameVersion
            // 
            this.tmrGameVersion.Enabled = true;
            this.tmrGameVersion.Interval = 1000;
            this.tmrGameVersion.Tick += new System.EventHandler(this.tmrGameVersion_Tick);
            // 
            // tmrOnMission
            // 
            this.tmrOnMission.Enabled = true;
            this.tmrOnMission.Tick += new System.EventHandler(this.tmrOnMission_Tick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDebugInformationToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(284, 34);
            // 
            // showDebugInformationToolStripMenuItem
            // 
            this.showDebugInformationToolStripMenuItem.Name = "showDebugInformationToolStripMenuItem";
            this.showDebugInformationToolStripMenuItem.Size = new System.Drawing.Size(283, 30);
            this.showDebugInformationToolStripMenuItem.Text = "Show debug information";
            this.showDebugInformationToolStripMenuItem.Click += new System.EventHandler(this.showDebugInformationToolStripMenuItem_Click);
            // 
            // lblisAdmin
            // 
            this.lblisAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblisAdmin.ForeColor = System.Drawing.Color.DarkRed;
            this.lblisAdmin.Location = new System.Drawing.Point(2, 166);
            this.lblisAdmin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblisAdmin.Name = "lblisAdmin";
            this.lblisAdmin.Size = new System.Drawing.Size(536, 28);
            this.lblisAdmin.TabIndex = 4;
            this.lblisAdmin.Text = "Press F6 to toggle the \'On Mission\' variable";
            this.lblisAdmin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(536, 35);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(50, 29);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.tsmiExit.Size = new System.Drawing.Size(188, 30);
            this.tsmiExit.Text = "&Exit";
            this.tsmiExit.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiForceState,
            this.playBeepWhenOMChangesToolStripMenuItem,
            this.toolStripSeparator1,
            this.useNewAddressesForGTASAToolStripMenuItem,
            this.tsmiChangeKey});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(88, 29);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // tsmiForceState
            // 
            this.tsmiForceState.Name = "tsmiForceState";
            this.tsmiForceState.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.tsmiForceState.Size = new System.Drawing.Size(470, 30);
            this.tsmiForceState.Text = "&Force \'All Mission\' state to 0 all the time";
            this.tsmiForceState.Click += new System.EventHandler(this.forceAllMissionStateTo0ToolStripMenuItem_Click);
            // 
            // playBeepWhenOMChangesToolStripMenuItem
            // 
            this.playBeepWhenOMChangesToolStripMenuItem.Name = "playBeepWhenOMChangesToolStripMenuItem";
            this.playBeepWhenOMChangesToolStripMenuItem.Size = new System.Drawing.Size(470, 30);
            this.playBeepWhenOMChangesToolStripMenuItem.Text = "Play sound &effect when OM state changes";
            this.playBeepWhenOMChangesToolStripMenuItem.Click += new System.EventHandler(this.playBeepWhenOMChangesToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(467, 6);
            // 
            // useNewAddressesForGTASAToolStripMenuItem
            // 
            this.useNewAddressesForGTASAToolStripMenuItem.Checked = true;
            this.useNewAddressesForGTASAToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.useNewAddressesForGTASAToolStripMenuItem.Name = "useNewAddressesForGTASAToolStripMenuItem";
            this.useNewAddressesForGTASAToolStripMenuItem.Size = new System.Drawing.Size(470, 30);
            this.useNewAddressesForGTASAToolStripMenuItem.Text = "Use new addresses for GTA: SA (w.i.p.)";
            this.useNewAddressesForGTASAToolStripMenuItem.Click += new System.EventHandler(this.useNewAddressesForGTASAToolStripMenuItem_Click);
            // 
            // tsmiChangeKey
            // 
            this.tsmiChangeKey.Name = "tsmiChangeKey";
            this.tsmiChangeKey.Size = new System.Drawing.Size(470, 30);
            this.tsmiChangeKey.Text = "&Set key to change OM flag";
            this.tsmiChangeKey.Click += new System.EventHandler(this.changeKeyToChangeFlagToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripSeparator2,
            this.viewSourceCodeToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(61, 29);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCheckUpdatesOnStartup,
            this.tsmiCheckForUpdates});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(239, 30);
            this.toolStripMenuItem1.Text = "&Updates";
            // 
            // tsmiCheckUpdatesOnStartup
            // 
            this.tsmiCheckUpdatesOnStartup.Checked = true;
            this.tsmiCheckUpdatesOnStartup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiCheckUpdatesOnStartup.Name = "tsmiCheckUpdatesOnStartup";
            this.tsmiCheckUpdatesOnStartup.Size = new System.Drawing.Size(327, 30);
            this.tsmiCheckUpdatesOnStartup.Text = "Check for updates on &startup";
            this.tsmiCheckUpdatesOnStartup.Click += new System.EventHandler(this.checkForUpdatesOnStartupToolStripMenuItem1_Click_1);
            // 
            // tsmiCheckForUpdates
            // 
            this.tsmiCheckForUpdates.Name = "tsmiCheckForUpdates";
            this.tsmiCheckForUpdates.Size = new System.Drawing.Size(327, 30);
            this.tsmiCheckForUpdates.Text = "&Check for updates...";
            this.tsmiCheckForUpdates.Click += new System.EventHandler(this.checkforUpdatesToolStripMenuItem_Click_1);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(236, 6);
            // 
            // viewSourceCodeToolStripMenuItem
            // 
            this.viewSourceCodeToolStripMenuItem.Name = "viewSourceCodeToolStripMenuItem";
            this.viewSourceCodeToolStripMenuItem.Size = new System.Drawing.Size(239, 30);
            this.viewSourceCodeToolStripMenuItem.Text = "View Source Code";
            this.viewSourceCodeToolStripMenuItem.Click += new System.EventHandler(this.viewSourceCodeToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(239, 30);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 203);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.lblisAdmin);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.lblGame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GTA On Mission Changer 1.3.2";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGame;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Timer tmrGameVersion;
        private System.Windows.Forms.Timer tmrOnMission;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showDebugInformationToolStripMenuItem;
        private System.Windows.Forms.Label lblisAdmin;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiForceState;
        private System.Windows.Forms.ToolStripMenuItem tsmiChangeKey;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsmiCheckUpdatesOnStartup;
        private System.Windows.Forms.ToolStripMenuItem tsmiCheckForUpdates;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playBeepWhenOMChangesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem viewSourceCodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem useNewAddressesForGTASAToolStripMenuItem;
    }
}

