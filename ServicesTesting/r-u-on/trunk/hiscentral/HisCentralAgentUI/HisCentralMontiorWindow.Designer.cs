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
            this.StatusGraphic = new System.Windows.Forms.PictureBox();
            this.Chk_AgentRun = new System.Windows.Forms.CheckBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.Status = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.hisCentralServerListBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endpointDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.StatusGraphic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hisCentralServerListBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // StatusGraphic
            // 
            this.StatusGraphic.Location = new System.Drawing.Point(33, 37);
            this.StatusGraphic.Name = "StatusGraphic";
            this.StatusGraphic.Size = new System.Drawing.Size(65, 52);
            this.StatusGraphic.TabIndex = 0;
            this.StatusGraphic.TabStop = false;
            // 
            // Chk_AgentRun
            // 
            this.Chk_AgentRun.AutoSize = true;
            this.Chk_AgentRun.Location = new System.Drawing.Point(33, 14);
            this.Chk_AgentRun.Name = "Chk_AgentRun";
            this.Chk_AgentRun.Size = new System.Drawing.Size(77, 17);
            this.Chk_AgentRun.TabIndex = 1;
            this.Chk_AgentRun.Text = "Run Agent";
            this.Chk_AgentRun.UseVisualStyleBackColor = true;
            this.Chk_AgentRun.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(33, 98);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Status";
            // 
            // Status
            // 
            this.Status.Location = new System.Drawing.Point(87, 95);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(100, 20);
            this.Status.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.endpointDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.hisCentralServerListBindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(33, 133);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(240, 103);
            this.dataGridView1.TabIndex = 4;
            // 
            // hisCentralServerListBindingSource1
            // 
            this.hisCentralServerListBindingSource1.DataMember = "Servers";
            this.hisCentralServerListBindingSource1.DataSource = typeof(Cuahsi.His.Ruon.HisCentralServerList);
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
            // HisCentralMontiorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 262);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.Chk_AgentRun);
            this.Controls.Add(this.StatusGraphic);
            this.Name = "HisCentralMontiorWindow";
            this.Text = "HisCentralMontiorWindow";
            ((System.ComponentModel.ISupportInitialize)(this.StatusGraphic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hisCentralServerListBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox StatusGraphic;
        private System.Windows.Forms.CheckBox Chk_AgentRun;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox Status;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn endpointDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource hisCentralServerListBindingSource1;
    }
}