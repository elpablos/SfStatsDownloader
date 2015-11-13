namespace SfSStatsDownloader
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
            this.listStats = new System.Windows.Forms.ListView();
            this.columnHeaderID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderHome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderHomeScore = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderScore = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderAwayScore = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderAway = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderX = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnProcess = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.lblUrl = new System.Windows.Forms.Label();
            this.saveExportDialog = new System.Windows.Forms.SaveFileDialog();
            this.columnHeaderSport = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAjax = new System.Windows.Forms.Button();
            this.columnHeaderScoreWithout = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderScoreRaw = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chkSkip = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // listStats
            // 
            this.listStats.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listStats.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderID,
            this.columnHeaderDate,
            this.columnHeaderHome,
            this.columnHeaderHomeScore,
            this.columnHeaderScore,
            this.columnHeaderAwayScore,
            this.columnHeaderAway,
            this.columnHeader1,
            this.columnHeaderX,
            this.columnHeader2,
            this.columnHeaderSport,
            this.columnHeaderScoreWithout,
            this.columnHeaderScoreRaw});
            this.listStats.FullRowSelect = true;
            this.listStats.GridLines = true;
            this.listStats.Location = new System.Drawing.Point(12, 59);
            this.listStats.Name = "listStats";
            this.listStats.Size = new System.Drawing.Size(940, 469);
            this.listStats.TabIndex = 0;
            this.listStats.UseCompatibleStateImageBehavior = false;
            this.listStats.View = System.Windows.Forms.View.Details;
            this.listStats.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listStats_KeyDown);
            // 
            // columnHeaderID
            // 
            this.columnHeaderID.Tag = "ID";
            this.columnHeaderID.Text = "ID";
            this.columnHeaderID.Width = 30;
            // 
            // columnHeaderDate
            // 
            this.columnHeaderDate.Tag = "Date";
            this.columnHeaderDate.Text = "Date";
            this.columnHeaderDate.Width = 80;
            // 
            // columnHeaderHome
            // 
            this.columnHeaderHome.DisplayIndex = 3;
            this.columnHeaderHome.Tag = "Home";
            this.columnHeaderHome.Text = "Home";
            this.columnHeaderHome.Width = 120;
            // 
            // columnHeaderHomeScore
            // 
            this.columnHeaderHomeScore.DisplayIndex = 4;
            this.columnHeaderHomeScore.Tag = "Home score";
            this.columnHeaderHomeScore.Text = "Home score";
            this.columnHeaderHomeScore.Width = 80;
            // 
            // columnHeaderScore
            // 
            this.columnHeaderScore.DisplayIndex = 5;
            this.columnHeaderScore.Tag = "Score";
            this.columnHeaderScore.Text = "Score";
            // 
            // columnHeaderAwayScore
            // 
            this.columnHeaderAwayScore.DisplayIndex = 6;
            this.columnHeaderAwayScore.Tag = "Away score";
            this.columnHeaderAwayScore.Text = "Away score";
            this.columnHeaderAwayScore.Width = 80;
            // 
            // columnHeaderAway
            // 
            this.columnHeaderAway.DisplayIndex = 7;
            this.columnHeaderAway.Tag = "Away";
            this.columnHeaderAway.Text = "Away";
            this.columnHeaderAway.Width = 120;
            // 
            // columnHeader1
            // 
            this.columnHeader1.DisplayIndex = 8;
            this.columnHeader1.Tag = "1";
            this.columnHeader1.Text = "1";
            // 
            // columnHeaderX
            // 
            this.columnHeaderX.DisplayIndex = 9;
            this.columnHeaderX.Tag = "X";
            this.columnHeaderX.Text = "X";
            // 
            // columnHeader2
            // 
            this.columnHeader2.DisplayIndex = 10;
            this.columnHeader2.Tag = "2";
            this.columnHeader2.Text = "2";
            // 
            // btnProcess
            // 
            this.btnProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcess.Location = new System.Drawing.Point(709, 12);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(75, 23);
            this.btnProcess.TabIndex = 1;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Enabled = false;
            this.btnExport.Location = new System.Drawing.Point(871, 12);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // txtUrl
            // 
            this.txtUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUrl.Location = new System.Drawing.Point(170, 14);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(533, 20);
            this.txtUrl.TabIndex = 3;
            this.txtUrl.Click += new System.EventHandler(this.txtUrl_Click);
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(12, 17);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(58, 13);
            this.lblUrl.TabIndex = 4;
            this.lblUrl.Text = "Url adresa:";
            // 
            // saveExportDialog
            // 
            this.saveExportDialog.DefaultExt = "csv";
            this.saveExportDialog.Filter = "CSV file|*.csv";
            // 
            // columnHeaderSport
            // 
            this.columnHeaderSport.DisplayIndex = 2;
            this.columnHeaderSport.Tag = "Sport";
            this.columnHeaderSport.Text = "Sport";
            // 
            // btnAjax
            // 
            this.btnAjax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAjax.Enabled = false;
            this.btnAjax.Location = new System.Drawing.Point(790, 12);
            this.btnAjax.Name = "btnAjax";
            this.btnAjax.Size = new System.Drawing.Size(75, 23);
            this.btnAjax.TabIndex = 5;
            this.btnAjax.Text = "Extend";
            this.btnAjax.UseVisualStyleBackColor = true;
            this.btnAjax.Click += new System.EventHandler(this.btnAjax_Click);
            // 
            // columnHeaderScoreWithout
            // 
            this.columnHeaderScoreWithout.Tag = "Score without OT";
            this.columnHeaderScoreWithout.Text = "Score without OT";
            // 
            // columnHeaderScoreRaw
            // 
            this.columnHeaderScoreRaw.Tag = "Score raw";
            this.columnHeaderScoreRaw.Text = "RAW";
            this.columnHeaderScoreRaw.Width = 100;
            // 
            // chkSkip
            // 
            this.chkSkip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSkip.AutoSize = true;
            this.chkSkip.Checked = true;
            this.chkSkip.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSkip.Location = new System.Drawing.Point(790, 36);
            this.chkSkip.Name = "chkSkip";
            this.chkSkip.Size = new System.Drawing.Size(47, 17);
            this.chkSkip.TabIndex = 6;
            this.chkSkip.Text = "Skip";
            this.chkSkip.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 540);
            this.Controls.Add(this.chkSkip);
            this.Controls.Add(this.btnAjax);
            this.Controls.Add(this.lblUrl);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.listStats);
            this.Name = "Form1";
            this.Text = "SFS Stats Downloader";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listStats;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.ColumnHeader columnHeaderDate;
        private System.Windows.Forms.ColumnHeader columnHeaderHome;
        private System.Windows.Forms.ColumnHeader columnHeaderScore;
        private System.Windows.Forms.ColumnHeader columnHeaderAway;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeaderX;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.SaveFileDialog saveExportDialog;
        private System.Windows.Forms.ColumnHeader columnHeaderHomeScore;
        private System.Windows.Forms.ColumnHeader columnHeaderAwayScore;
        private System.Windows.Forms.ColumnHeader columnHeaderID;
        private System.Windows.Forms.ColumnHeader columnHeaderSport;
        private System.Windows.Forms.Button btnAjax;
        private System.Windows.Forms.ColumnHeader columnHeaderScoreWithout;
        private System.Windows.Forms.ColumnHeader columnHeaderScoreRaw;
        private System.Windows.Forms.CheckBox chkSkip;
    }
}

