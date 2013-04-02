using HisCentralServicesList;

namespace cuahsi.wof.ruon
{
    partial class MontiorWindow
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
            this.lblStatus = new System.Windows.Forms.Label();
            this.Status = new System.Windows.Forms.TextBox();
            this.ServerListGrid = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_executeMonitor = new System.Windows.Forms.Button();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.enabledDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.endpointDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.siteCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.variableCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iSOTimeIntervalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serverListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.ServerListGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serverListBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(30, 55);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Status";
            // 
            // Status
            // 
            this.Status.Location = new System.Drawing.Point(87, 55);
            this.Status.Multiline = true;
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(250, 52);
            this.Status.TabIndex = 3;
            // 
            // ServerListGrid
            // 
            this.ServerListGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ServerListGrid.AutoGenerateColumns = false;
            this.ServerListGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ServerListGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.enabledDataGridViewCheckBoxColumn,
            this.endpointDataGridViewTextBoxColumn,
            this.siteCodeDataGridViewTextBoxColumn,
            this.variableCodeDataGridViewTextBoxColumn,
            this.iSOTimeIntervalDataGridViewTextBoxColumn});
            this.ServerListGrid.DataSource = this.serverListBindingSource;
            this.ServerListGrid.Location = new System.Drawing.Point(12, 133);
            this.ServerListGrid.Name = "ServerListGrid";
            this.ServerListGrid.Size = new System.Drawing.Size(695, 140);
            this.ServerListGrid.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(550, 282);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Publish to Server";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_executeMonitor
            // 
            this.btn_executeMonitor.Location = new System.Drawing.Point(33, 8);
            this.btn_executeMonitor.Name = "btn_executeMonitor";
            this.btn_executeMonitor.Size = new System.Drawing.Size(127, 23);
            this.btn_executeMonitor.TabIndex = 9;
            this.btn_executeMonitor.Text = "Execute Monitor";
            this.btn_executeMonitor.UseVisualStyleBackColor = true;
            this.btn_executeMonitor.Click += new System.EventHandler(this.btn_executeMonitor_Click);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // enabledDataGridViewCheckBoxColumn
            // 
            this.enabledDataGridViewCheckBoxColumn.DataPropertyName = "Enabled";
            this.enabledDataGridViewCheckBoxColumn.HeaderText = "Enabled";
            this.enabledDataGridViewCheckBoxColumn.Name = "enabledDataGridViewCheckBoxColumn";
            // 
            // endpointDataGridViewTextBoxColumn
            // 
            this.endpointDataGridViewTextBoxColumn.DataPropertyName = "Endpoint";
            this.endpointDataGridViewTextBoxColumn.HeaderText = "Endpoint";
            this.endpointDataGridViewTextBoxColumn.Name = "endpointDataGridViewTextBoxColumn";
            // 
            // siteCodeDataGridViewTextBoxColumn
            // 
            this.siteCodeDataGridViewTextBoxColumn.DataPropertyName = "SiteCode";
            this.siteCodeDataGridViewTextBoxColumn.HeaderText = "SiteCode";
            this.siteCodeDataGridViewTextBoxColumn.Name = "siteCodeDataGridViewTextBoxColumn";
            // 
            // variableCodeDataGridViewTextBoxColumn
            // 
            this.variableCodeDataGridViewTextBoxColumn.DataPropertyName = "VariableCode";
            this.variableCodeDataGridViewTextBoxColumn.HeaderText = "VariableCode";
            this.variableCodeDataGridViewTextBoxColumn.Name = "variableCodeDataGridViewTextBoxColumn";
            // 
            // iSOTimeIntervalDataGridViewTextBoxColumn
            // 
            this.iSOTimeIntervalDataGridViewTextBoxColumn.DataPropertyName = "ISOTimeInterval";
            this.iSOTimeIntervalDataGridViewTextBoxColumn.HeaderText = "ISOTimeInterval";
            this.iSOTimeIntervalDataGridViewTextBoxColumn.Name = "iSOTimeIntervalDataGridViewTextBoxColumn";
            // 
            // serverListBindingSource
            // 
            this.serverListBindingSource.DataSource = typeof(ObsSeriesServer);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // MontiorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 317);
            this.Controls.Add(this.btn_executeMonitor);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ServerListGrid);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.lblStatus);
            this.Name = "MontiorWindow";
            this.Text = "HIS Web Services R-U-ON Monitor Config";
            ((System.ComponentModel.ISupportInitialize)(this.ServerListGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serverListBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox Status;
        private System.Windows.Forms.DataGridView ServerListGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn enabledDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn endpointDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn siteCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn variableCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iSOTimeIntervalDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource serverListBindingSource;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_executeMonitor;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}