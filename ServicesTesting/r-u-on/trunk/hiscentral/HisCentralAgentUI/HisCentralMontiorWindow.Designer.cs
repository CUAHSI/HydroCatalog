namespace Cuahsi.His.Ruon
{
    partial class HisCentralMontiorWindow
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endpointDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hisCentralServerListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.executeMonitor = new System.Windows.Forms.Button();
            this.btn_upload = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hisCentralServerListBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(33, 55);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Status";
            // 
            // Status
            // 
            this.Status.Location = new System.Drawing.Point(87, 52);
            this.Status.Multiline = true;
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(186, 56);
            this.Status.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.endpointDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.hisCentralServerListBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 133);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(607, 101);
            this.dataGridView1.TabIndex = 4;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // endpointDataGridViewTextBoxColumn
            // 
            this.endpointDataGridViewTextBoxColumn.DataPropertyName = "Endpoint";
            this.endpointDataGridViewTextBoxColumn.HeaderText = "Endpoint";
            this.endpointDataGridViewTextBoxColumn.Name = "endpointDataGridViewTextBoxColumn";
            // 
            // hisCentralServerListBindingSource
            // 
            this.hisCentralServerListBindingSource.DataSource = typeof(Cuahsi.His.Ruon.HisCentralServerList);
            // 
            // executeMonitor
            // 
            this.executeMonitor.Location = new System.Drawing.Point(33, 12);
            this.executeMonitor.Name = "executeMonitor";
            this.executeMonitor.Size = new System.Drawing.Size(75, 23);
            this.executeMonitor.TabIndex = 5;
            this.executeMonitor.Text = "Execute Monitor";
            this.executeMonitor.UseVisualStyleBackColor = true;
            this.executeMonitor.Click += new System.EventHandler(this.executeMonitor_Click);
            // 
            // btn_upload
            // 
            this.btn_upload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_upload.Location = new System.Drawing.Point(469, 240);
            this.btn_upload.Name = "btn_upload";
            this.btn_upload.Size = new System.Drawing.Size(132, 23);
            this.btn_upload.TabIndex = 6;
            this.btn_upload.Text = "Publish To Server";
            this.btn_upload.UseVisualStyleBackColor = true;
            this.btn_upload.Click += new System.EventHandler(this.btn_upload_Click);
            // 
            // HisCentralMontiorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 262);
            this.Controls.Add(this.btn_upload);
            this.Controls.Add(this.executeMonitor);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.lblStatus);
            this.Name = "HisCentralMontiorWindow";
            this.Text = "HisCentralMontiorWindow";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hisCentralServerListBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox Status;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn endpointDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource hisCentralServerListBindingSource;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button executeMonitor;
        private System.Windows.Forms.Button btn_upload;
    }
}