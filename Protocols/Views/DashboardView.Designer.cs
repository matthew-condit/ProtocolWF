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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.RequestDataGridView = new System.Windows.Forms.DataGridView();
            this.RequestedDateCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RequestedByCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SponsorCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusCol = new System.Windows.Forms.DataGridViewImageColumn();
            this.CommentsCol = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.RequestDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SlateGray;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "DASHBOARD";
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
            this.StatusCol,
            this.CommentsCol});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.RequestDataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.RequestDataGridView.Location = new System.Drawing.Point(7, 25);
            this.RequestDataGridView.MultiSelect = false;
            this.RequestDataGridView.Name = "RequestDataGridView";
            this.RequestDataGridView.ReadOnly = true;
            this.RequestDataGridView.RowTemplate.Height = 30;
            this.RequestDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.RequestDataGridView.Size = new System.Drawing.Size(560, 212);
            this.RequestDataGridView.TabIndex = 1;
            this.RequestDataGridView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RequestDataGridView_CellContentDoubleClick);
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
            // StatusCol
            // 
            this.StatusCol.HeaderText = "Status";
            this.StatusCol.Name = "StatusCol";
            this.StatusCol.ReadOnly = true;
            this.StatusCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.StatusCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // CommentsCol
            // 
            this.CommentsCol.HeaderText = "Comments";
            this.CommentsCol.LinkColor = System.Drawing.SystemColors.Highlight;
            this.CommentsCol.Name = "CommentsCol";
            this.CommentsCol.ReadOnly = true;
            this.CommentsCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CommentsCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.CommentsCol.VisitedLinkColor = System.Drawing.Color.SlateGray;
            // 
            // DashboardView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.RequestDataGridView);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DashboardView";
            this.Size = new System.Drawing.Size(570, 240);
            ((System.ComponentModel.ISupportInitialize)(this.RequestDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView RequestDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn RequestedDateCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn RequestedByCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SponsorCol;
        private System.Windows.Forms.DataGridViewImageColumn StatusCol;
        private System.Windows.Forms.DataGridViewLinkColumn CommentsCol;
    }
}
