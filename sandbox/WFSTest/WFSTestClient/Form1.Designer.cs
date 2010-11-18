namespace WFSTest
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
          this.bboxNorth = new System.Windows.Forms.TextBox();
          this.bboxSouth = new System.Windows.Forms.TextBox();
          this.bboxWest = new System.Windows.Forms.TextBox();
          this.bboxEast = new System.Windows.Forms.TextBox();
          this.groupBox1 = new System.Windows.Forms.GroupBox();
          this.pgbQuery = new System.Windows.Forms.ProgressBar();
          this.chkHits = new System.Windows.Forms.CheckBox();
          this.btnExport = new System.Windows.Forms.Button();
          this.label5 = new System.Windows.Forms.Label();
          this.label9 = new System.Windows.Forms.Label();
          this.label7 = new System.Windows.Forms.Label();
          this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
          this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
          this.chkDateRange = new System.Windows.Forms.CheckBox();
          this.txtValCount = new System.Windows.Forms.TextBox();
          this.chkValCount = new System.Windows.Forms.CheckBox();
          this.btnGetFeature = new System.Windows.Forms.Button();
          this.txtSiteCode = new System.Windows.Forms.TextBox();
          this.txtConcept = new System.Windows.Forms.TextBox();
          this.chkSiteCode = new System.Windows.Forms.CheckBox();
          this.chkConcept = new System.Windows.Forms.CheckBox();
          this.chkBBox = new System.Windows.Forms.CheckBox();
          this.label4 = new System.Windows.Forms.Label();
          this.label3 = new System.Windows.Forms.Label();
          this.label2 = new System.Windows.Forms.Label();
          this.label1 = new System.Windows.Forms.Label();
          this.dgvResults = new System.Windows.Forms.DataGridView();
          this.tcResults = new System.Windows.Forms.TabControl();
          this.tabPage1 = new System.Windows.Forms.TabPage();
          this.groupBox3 = new System.Windows.Forms.GroupBox();
          this.chkListServices = new System.Windows.Forms.CheckedListBox();
          this.lblFound = new System.Windows.Forms.Label();
          this.btnGetRecords = new System.Windows.Forms.Button();
          this.txtCSWUrl = new System.Windows.Forms.TextBox();
          this.toolStripContainer2 = new System.Windows.Forms.ToolStripContainer();
          this.statusStrip1 = new System.Windows.Forms.StatusStrip();
          this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
          this.groupBox1.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
          this.tcResults.SuspendLayout();
          this.tabPage1.SuspendLayout();
          this.groupBox3.SuspendLayout();
          this.toolStripContainer2.ContentPanel.SuspendLayout();
          this.toolStripContainer2.SuspendLayout();
          this.statusStrip1.SuspendLayout();
          this.SuspendLayout();
          // 
          // bboxNorth
          // 
          this.bboxNorth.Enabled = false;
          this.bboxNorth.Location = new System.Drawing.Point(105, 23);
          this.bboxNorth.Name = "bboxNorth";
          this.bboxNorth.Size = new System.Drawing.Size(64, 20);
          this.bboxNorth.TabIndex = 1;
          this.bboxNorth.Text = "31.44";
          // 
          // bboxSouth
          // 
          this.bboxSouth.Enabled = false;
          this.bboxSouth.Location = new System.Drawing.Point(178, 23);
          this.bboxSouth.Name = "bboxSouth";
          this.bboxSouth.Size = new System.Drawing.Size(64, 20);
          this.bboxSouth.TabIndex = 2;
          this.bboxSouth.Text = "30.00";
          // 
          // bboxWest
          // 
          this.bboxWest.Enabled = false;
          this.bboxWest.Location = new System.Drawing.Point(105, 62);
          this.bboxWest.Name = "bboxWest";
          this.bboxWest.Size = new System.Drawing.Size(64, 20);
          this.bboxWest.TabIndex = 3;
          this.bboxWest.Text = "-99.66";
          // 
          // bboxEast
          // 
          this.bboxEast.Enabled = false;
          this.bboxEast.Location = new System.Drawing.Point(178, 62);
          this.bboxEast.Name = "bboxEast";
          this.bboxEast.Size = new System.Drawing.Size(64, 20);
          this.bboxEast.TabIndex = 4;
          this.bboxEast.Text = "-98.00";
          // 
          // groupBox1
          // 
          this.groupBox1.Controls.Add(this.pgbQuery);
          this.groupBox1.Controls.Add(this.chkHits);
          this.groupBox1.Controls.Add(this.btnExport);
          this.groupBox1.Controls.Add(this.label5);
          this.groupBox1.Controls.Add(this.label9);
          this.groupBox1.Controls.Add(this.label7);
          this.groupBox1.Controls.Add(this.dtpEndDate);
          this.groupBox1.Controls.Add(this.dtpStartDate);
          this.groupBox1.Controls.Add(this.chkDateRange);
          this.groupBox1.Controls.Add(this.txtValCount);
          this.groupBox1.Controls.Add(this.chkValCount);
          this.groupBox1.Controls.Add(this.btnGetFeature);
          this.groupBox1.Controls.Add(this.txtSiteCode);
          this.groupBox1.Controls.Add(this.txtConcept);
          this.groupBox1.Controls.Add(this.chkSiteCode);
          this.groupBox1.Controls.Add(this.chkConcept);
          this.groupBox1.Controls.Add(this.chkBBox);
          this.groupBox1.Controls.Add(this.label4);
          this.groupBox1.Controls.Add(this.label3);
          this.groupBox1.Controls.Add(this.label2);
          this.groupBox1.Controls.Add(this.label1);
          this.groupBox1.Controls.Add(this.bboxEast);
          this.groupBox1.Controls.Add(this.bboxWest);
          this.groupBox1.Controls.Add(this.bboxSouth);
          this.groupBox1.Controls.Add(this.bboxNorth);
          this.groupBox1.Location = new System.Drawing.Point(12, 202);
          this.groupBox1.Name = "groupBox1";
          this.groupBox1.Size = new System.Drawing.Size(295, 289);
          this.groupBox1.TabIndex = 5;
          this.groupBox1.TabStop = false;
          this.groupBox1.Text = "Filters";
          // 
          // pgbQuery
          // 
          this.pgbQuery.Location = new System.Drawing.Point(5, 266);
          this.pgbQuery.Name = "pgbQuery";
          this.pgbQuery.Size = new System.Drawing.Size(275, 23);
          this.pgbQuery.TabIndex = 24;
          this.pgbQuery.Visible = false;
          // 
          // chkHits
          // 
          this.chkHits.Enabled = false;
          this.chkHits.Location = new System.Drawing.Point(6, 242);
          this.chkHits.Name = "chkHits";
          this.chkHits.Size = new System.Drawing.Size(88, 34);
          this.chkHits.TabIndex = 27;
          this.chkHits.Text = "Just get series count";
          this.chkHits.UseVisualStyleBackColor = true;
          // 
          // btnExport
          // 
          this.btnExport.Enabled = false;
          this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
          this.btnExport.Location = new System.Drawing.Point(244, 247);
          this.btnExport.Name = "btnExport";
          this.btnExport.Size = new System.Drawing.Size(30, 23);
          this.btnExport.TabIndex = 15;
          this.btnExport.UseVisualStyleBackColor = true;
          this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
          // 
          // label5
          // 
          this.label5.AutoSize = true;
          this.label5.Enabled = false;
          this.label5.Location = new System.Drawing.Point(19, 199);
          this.label5.Name = "label5";
          this.label5.Size = new System.Drawing.Size(83, 13);
          this.label5.TabIndex = 26;
          this.label5.Text = "(Client side filter)";
          // 
          // label9
          // 
          this.label9.AutoSize = true;
          this.label9.Location = new System.Drawing.Point(194, 175);
          this.label9.Name = "label9";
          this.label9.Size = new System.Drawing.Size(26, 13);
          this.label9.TabIndex = 23;
          this.label9.Text = "End";
          // 
          // label7
          // 
          this.label7.AutoSize = true;
          this.label7.Location = new System.Drawing.Point(102, 175);
          this.label7.Name = "label7";
          this.label7.Size = new System.Drawing.Size(29, 13);
          this.label7.TabIndex = 22;
          this.label7.Text = "Start";
          // 
          // dtpEndDate
          // 
          this.dtpEndDate.Enabled = false;
          this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
          this.dtpEndDate.Location = new System.Drawing.Point(195, 191);
          this.dtpEndDate.Name = "dtpEndDate";
          this.dtpEndDate.Size = new System.Drawing.Size(85, 20);
          this.dtpEndDate.TabIndex = 21;
          // 
          // dtpStartDate
          // 
          this.dtpStartDate.CustomFormat = "";
          this.dtpStartDate.Enabled = false;
          this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
          this.dtpStartDate.Location = new System.Drawing.Point(105, 191);
          this.dtpStartDate.Name = "dtpStartDate";
          this.dtpStartDate.Size = new System.Drawing.Size(83, 20);
          this.dtpStartDate.TabIndex = 20;
          // 
          // chkDateRange
          // 
          this.chkDateRange.AutoSize = true;
          this.chkDateRange.Enabled = false;
          this.chkDateRange.Location = new System.Drawing.Point(6, 179);
          this.chkDateRange.Name = "chkDateRange";
          this.chkDateRange.Size = new System.Drawing.Size(84, 17);
          this.chkDateRange.TabIndex = 18;
          this.chkDateRange.Text = "Date Range";
          this.chkDateRange.UseVisualStyleBackColor = true;
          this.chkDateRange.CheckedChanged += new System.EventHandler(this.chkDateRange_CheckedChanged);
          // 
          // txtValCount
          // 
          this.txtValCount.Enabled = false;
          this.txtValCount.Location = new System.Drawing.Point(105, 148);
          this.txtValCount.Name = "txtValCount";
          this.txtValCount.Size = new System.Drawing.Size(154, 20);
          this.txtValCount.TabIndex = 16;
          this.txtValCount.Text = "100";
          // 
          // chkValCount
          // 
          this.chkValCount.AutoSize = true;
          this.chkValCount.Enabled = false;
          this.chkValCount.Location = new System.Drawing.Point(6, 151);
          this.chkValCount.Name = "chkValCount";
          this.chkValCount.Size = new System.Drawing.Size(96, 17);
          this.chkValCount.TabIndex = 14;
          this.chkValCount.Text = "Value Count  >";
          this.chkValCount.UseVisualStyleBackColor = true;
          this.chkValCount.CheckedChanged += new System.EventHandler(this.chkValCount_CheckedChanged);
          // 
          // btnGetFeature
          // 
          this.btnGetFeature.Enabled = false;
          this.btnGetFeature.Location = new System.Drawing.Point(107, 246);
          this.btnGetFeature.Name = "btnGetFeature";
          this.btnGetFeature.Size = new System.Drawing.Size(131, 30);
          this.btnGetFeature.TabIndex = 7;
          this.btnGetFeature.Text = "WFS:GetFeature";
          this.btnGetFeature.UseVisualStyleBackColor = true;
          this.btnGetFeature.Click += new System.EventHandler(this.btnGetFeature_Click);
          // 
          // txtSiteCode
          // 
          this.txtSiteCode.Enabled = false;
          this.txtSiteCode.Location = new System.Drawing.Point(105, 122);
          this.txtSiteCode.Name = "txtSiteCode";
          this.txtSiteCode.Size = new System.Drawing.Size(154, 20);
          this.txtSiteCode.TabIndex = 13;
          this.txtSiteCode.Text = "410431";
          // 
          // txtConcept
          // 
          this.txtConcept.Enabled = false;
          this.txtConcept.Location = new System.Drawing.Point(105, 96);
          this.txtConcept.Name = "txtConcept";
          this.txtConcept.Size = new System.Drawing.Size(154, 20);
          this.txtConcept.TabIndex = 12;
          this.txtConcept.Text = "Evaporation, actual";
          // 
          // chkSiteCode
          // 
          this.chkSiteCode.AutoSize = true;
          this.chkSiteCode.Enabled = false;
          this.chkSiteCode.Location = new System.Drawing.Point(6, 125);
          this.chkSiteCode.Name = "chkSiteCode";
          this.chkSiteCode.Size = new System.Drawing.Size(69, 17);
          this.chkSiteCode.TabIndex = 11;
          this.chkSiteCode.Text = "SiteCode";
          this.chkSiteCode.UseVisualStyleBackColor = true;
          this.chkSiteCode.CheckedChanged += new System.EventHandler(this.chkSiteCode_CheckedChanged);
          // 
          // chkConcept
          // 
          this.chkConcept.AutoSize = true;
          this.chkConcept.Enabled = false;
          this.chkConcept.Location = new System.Drawing.Point(6, 98);
          this.chkConcept.Name = "chkConcept";
          this.chkConcept.Size = new System.Drawing.Size(66, 17);
          this.chkConcept.TabIndex = 10;
          this.chkConcept.Text = "Concept";
          this.chkConcept.UseVisualStyleBackColor = true;
          this.chkConcept.CheckedChanged += new System.EventHandler(this.chkConcept_CheckedChanged);
          // 
          // chkBBox
          // 
          this.chkBBox.AutoSize = true;
          this.chkBBox.Enabled = false;
          this.chkBBox.Location = new System.Drawing.Point(6, 42);
          this.chkBBox.Name = "chkBBox";
          this.chkBBox.Size = new System.Drawing.Size(92, 17);
          this.chkBBox.TabIndex = 9;
          this.chkBBox.Text = "Bounding Box";
          this.chkBBox.UseVisualStyleBackColor = true;
          this.chkBBox.CheckedChanged += new System.EventHandler(this.chkBBox_CheckedChanged);
          // 
          // label4
          // 
          this.label4.AutoSize = true;
          this.label4.Location = new System.Drawing.Point(179, 47);
          this.label4.Name = "label4";
          this.label4.Size = new System.Drawing.Size(28, 13);
          this.label4.TabIndex = 8;
          this.label4.Text = "East";
          // 
          // label3
          // 
          this.label3.AutoSize = true;
          this.label3.Location = new System.Drawing.Point(104, 47);
          this.label3.Name = "label3";
          this.label3.Size = new System.Drawing.Size(32, 13);
          this.label3.TabIndex = 7;
          this.label3.Text = "West";
          // 
          // label2
          // 
          this.label2.AutoSize = true;
          this.label2.Location = new System.Drawing.Point(179, 9);
          this.label2.Name = "label2";
          this.label2.Size = new System.Drawing.Size(35, 13);
          this.label2.TabIndex = 6;
          this.label2.Text = "South";
          // 
          // label1
          // 
          this.label1.AutoSize = true;
          this.label1.Location = new System.Drawing.Point(104, 9);
          this.label1.Name = "label1";
          this.label1.Size = new System.Drawing.Size(33, 13);
          this.label1.TabIndex = 5;
          this.label1.Text = "North";
          // 
          // dgvResults
          // 
          this.dgvResults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
          this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
          this.dgvResults.Location = new System.Drawing.Point(3, 3);
          this.dgvResults.Name = "dgvResults";
          this.dgvResults.Size = new System.Drawing.Size(720, 446);
          this.dgvResults.TabIndex = 14;
          // 
          // tcResults
          // 
          this.tcResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                      | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
          this.tcResults.Controls.Add(this.tabPage1);
          this.tcResults.Location = new System.Drawing.Point(313, 12);
          this.tcResults.Name = "tcResults";
          this.tcResults.SelectedIndex = 0;
          this.tcResults.Size = new System.Drawing.Size(734, 479);
          this.tcResults.TabIndex = 15;
          // 
          // tabPage1
          // 
          this.tabPage1.Controls.Add(this.dgvResults);
          this.tabPage1.Location = new System.Drawing.Point(4, 22);
          this.tabPage1.Name = "tabPage1";
          this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
          this.tabPage1.Size = new System.Drawing.Size(726, 453);
          this.tabPage1.TabIndex = 0;
          this.tabPage1.Text = "Results";
          this.tabPage1.UseVisualStyleBackColor = true;
          // 
          // groupBox3
          // 
          this.groupBox3.Controls.Add(this.chkListServices);
          this.groupBox3.Controls.Add(this.lblFound);
          this.groupBox3.Controls.Add(this.btnGetRecords);
          this.groupBox3.Controls.Add(this.txtCSWUrl);
          this.groupBox3.Location = new System.Drawing.Point(12, 12);
          this.groupBox3.Name = "groupBox3";
          this.groupBox3.Size = new System.Drawing.Size(295, 184);
          this.groupBox3.TabIndex = 16;
          this.groupBox3.TabStop = false;
          this.groupBox3.Text = "CSW Endpoint";
          // 
          // chkListServices
          // 
          this.chkListServices.CheckOnClick = true;
          this.chkListServices.FormattingEnabled = true;
          this.chkListServices.Location = new System.Drawing.Point(10, 93);
          this.chkListServices.Name = "chkListServices";
          this.chkListServices.Size = new System.Drawing.Size(271, 79);
          this.chkListServices.TabIndex = 18;
          this.chkListServices.Visible = false;
          // 
          // lblFound
          // 
          this.lblFound.AutoSize = true;
          this.lblFound.Location = new System.Drawing.Point(9, 80);
          this.lblFound.Name = "lblFound";
          this.lblFound.Size = new System.Drawing.Size(0, 13);
          this.lblFound.TabIndex = 2;
          // 
          // btnGetRecords
          // 
          this.btnGetRecords.Location = new System.Drawing.Point(10, 46);
          this.btnGetRecords.Name = "btnGetRecords";
          this.btnGetRecords.Size = new System.Drawing.Size(270, 29);
          this.btnGetRecords.TabIndex = 1;
          this.btnGetRecords.Text = "CSW:GetRecords && WFS:GetCapabilities";
          this.btnGetRecords.UseVisualStyleBackColor = true;
          this.btnGetRecords.Click += new System.EventHandler(this.btnGetRecords_Click);
          // 
          // txtCSWUrl
          // 
          this.txtCSWUrl.Location = new System.Drawing.Point(10, 20);
          this.txtCSWUrl.Name = "txtCSWUrl";
          this.txtCSWUrl.Size = new System.Drawing.Size(270, 20);
          this.txtCSWUrl.TabIndex = 0;
          this.txtCSWUrl.Text = "https://hydroportal.crwr.utexas.edu/geoportal/csw/discovery";
          // 
          // toolStripContainer2
          // 
          this.toolStripContainer2.BottomToolStripPanelVisible = false;
          // 
          // toolStripContainer2.ContentPanel
          // 
          this.toolStripContainer2.ContentPanel.AutoScroll = true;
          this.toolStripContainer2.ContentPanel.Controls.Add(this.statusStrip1);
          this.toolStripContainer2.ContentPanel.Controls.Add(this.tcResults);
          this.toolStripContainer2.ContentPanel.Controls.Add(this.groupBox3);
          this.toolStripContainer2.ContentPanel.Controls.Add(this.groupBox1);
          this.toolStripContainer2.ContentPanel.Size = new System.Drawing.Size(1054, 516);
          this.toolStripContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
          this.toolStripContainer2.LeftToolStripPanelVisible = false;
          this.toolStripContainer2.Location = new System.Drawing.Point(0, 0);
          this.toolStripContainer2.Name = "toolStripContainer2";
          this.toolStripContainer2.RightToolStripPanelVisible = false;
          this.toolStripContainer2.Size = new System.Drawing.Size(1054, 516);
          this.toolStripContainer2.TabIndex = 19;
          this.toolStripContainer2.Text = "toolStripContainer2";
          this.toolStripContainer2.TopToolStripPanelVisible = false;
          // 
          // statusStrip1
          // 
          this.statusStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
          this.statusStrip1.AutoSize = false;
          this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
          this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
          this.statusStrip1.Location = new System.Drawing.Point(0, 494);
          this.statusStrip1.Name = "statusStrip1";
          this.statusStrip1.Size = new System.Drawing.Size(1047, 22);
          this.statusStrip1.TabIndex = 17;
          this.statusStrip1.Text = "statusStrip1";
          // 
          // toolStripStatusLabel1
          // 
          this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
          this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
          this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
          // 
          // Form1
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size(1054, 516);
          this.Controls.Add(this.toolStripContainer2);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
          this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
          this.MaximizeBox = false;
          this.Name = "Form1";
          this.Text = "WFSTest";
          this.Load += new System.EventHandler(this.Form1_Load);
          this.groupBox1.ResumeLayout(false);
          this.groupBox1.PerformLayout();
          ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
          this.tcResults.ResumeLayout(false);
          this.tabPage1.ResumeLayout(false);
          this.groupBox3.ResumeLayout(false);
          this.groupBox3.PerformLayout();
          this.toolStripContainer2.ContentPanel.ResumeLayout(false);
          this.toolStripContainer2.ResumeLayout(false);
          this.toolStripContainer2.PerformLayout();
          this.statusStrip1.ResumeLayout(false);
          this.statusStrip1.PerformLayout();
          this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox bboxNorth;
        private System.Windows.Forms.TextBox bboxSouth;
        private System.Windows.Forms.TextBox bboxWest;
        private System.Windows.Forms.TextBox bboxEast;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGetFeature;
        private System.Windows.Forms.CheckBox chkBBox;
        private System.Windows.Forms.CheckBox chkConcept;
        private System.Windows.Forms.CheckBox chkSiteCode;
        private System.Windows.Forms.TextBox txtSiteCode;
        private System.Windows.Forms.TextBox txtConcept;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.TextBox txtValCount;
        private System.Windows.Forms.CheckBox chkValCount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.CheckBox chkDateRange;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtCSWUrl;
        private System.Windows.Forms.Button btnGetRecords;
        private System.Windows.Forms.Label lblFound;
        private System.Windows.Forms.TabControl tcResults;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ProgressBar pgbQuery;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.CheckedListBox chkListServices;
        private System.Windows.Forms.CheckBox chkHits;
        private System.Windows.Forms.ToolStripContainer toolStripContainer2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}

