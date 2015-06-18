namespace Protocols.Views
{
    partial class DashboardView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.RequestDataGridView = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.RequestedDateCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RequestedByCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SponsorCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubmittedCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ReceivedCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.InProcessCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CompletedCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CancelledCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.RequestDataGridView)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // RequestDataGridView
            // 
            this.RequestDataGridView.AllowUserToAddRows = false;
            this.RequestDataGridView.AllowUserToDeleteRows = false;
            this.RequestDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RequestDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.RequestDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.RequestDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RequestDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RequestedDateCol,
            this.RequestedByCol,
            this.SponsorCol,
            this.SubmittedCol,
            this.ReceivedCol,
            this.InProcessCol,
            this.CompletedCol,
            this.CancelledCol});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.RequestDataGridView.DefaultCellStyle = dataGridViewCellStyle6;
            this.RequestDataGridView.Location = new System.Drawing.Point(4, 38);
            this.RequestDataGridView.Name = "RequestDataGridView";
            this.RequestDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.RequestDataGridView.Size = new System.Drawing.Size(654, 469);
            this.RequestDataGridView.TabIndex = 6;
            this.RequestDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.RequestDataGridView_CellValueChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 10);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(661, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.ForeColor = System.Drawing.Color.SlateGray;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(188, 22);
            this.toolStripLabel1.Text = "Protocol Requests Dashboard";
            // 
            // RequestedDateCol
            // 
            this.RequestedDateCol.HeaderText = "Requested Date";
            this.RequestedDateCol.Name = "RequestedDateCol";
            this.RequestedDateCol.ReadOnly = true;
            // 
            // RequestedByCol
            // 
            this.RequestedByCol.HeaderText = "Requested By";
            this.RequestedByCol.Name = "RequestedByCol";
            this.RequestedByCol.ReadOnly = true;
            // 
            // SponsorCol
            // 
            this.SponsorCol.HeaderText = "Sponsor";
            this.SponsorCol.Name = "SponsorCol";
            this.SponsorCol.ReadOnly = true;
            // 
            // SubmittedCol
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.NullValue = false;
            this.SubmittedCol.DefaultCellStyle = dataGridViewCellStyle1;
            this.SubmittedCol.HeaderText = "Submitted";
            this.SubmittedCol.Name = "SubmittedCol";
            this.SubmittedCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ReceivedCol
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.NullValue = false;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.ReceivedCol.DefaultCellStyle = dataGridViewCellStyle2;
            this.ReceivedCol.HeaderText = "Received";
            this.ReceivedCol.Name = "ReceivedCol";
            // 
            // InProcessCol
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.NullValue = false;
            this.InProcessCol.DefaultCellStyle = dataGridViewCellStyle3;
            this.InProcessCol.HeaderText = "In Process";
            this.InProcessCol.Name = "InProcessCol";
            // 
            // CompletedCol
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.NullValue = false;
            this.CompletedCol.DefaultCellStyle = dataGridViewCellStyle4;
            this.CompletedCol.HeaderText = "Completed";
            this.CompletedCol.Name = "CompletedCol";
            // 
            // CancelledCol
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.NullValue = false;
            this.CancelledCol.DefaultCellStyle = dataGridViewCellStyle5;
            this.CancelledCol.HeaderText = "Cancelled";
            this.CancelledCol.Name = "CancelledCol";
            // 
            // DashboardView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.RequestDataGridView);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DashboardView";
            this.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.Size = new System.Drawing.Size(661, 510);
            ((System.ComponentModel.ISupportInitialize)(this.RequestDataGridView)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView RequestDataGridView;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn RequestedDateCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn RequestedByCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SponsorCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SubmittedCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ReceivedCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn InProcessCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CompletedCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CancelledCol;
    }
}
