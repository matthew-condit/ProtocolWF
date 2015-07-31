namespace Toxikon.ProtocolManager.Views
{
    partial class HistoryView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistoryView));
            this.MainTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.LeftPanel = new System.Windows.Forms.Panel();
            this.RequestListView = new System.Windows.Forms.ListView();
            this.DateCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RequestedByCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AssignedToCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.SearchButton = new System.Windows.Forms.ToolStripButton();
            this.ResetButton = new System.Windows.Forms.ToolStripButton();
            this.ProtocolRequestDetail = new Toxikon.ProtocolManager.Views.Protocols.ProtocolRequestReadOnlyView();
            this.MainTablePanel.SuspendLayout();
            this.LeftPanel.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTablePanel
            // 
            this.MainTablePanel.BackColor = System.Drawing.Color.White;
            this.MainTablePanel.ColumnCount = 2;
            this.MainTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.MainTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.MainTablePanel.Controls.Add(this.LeftPanel, 0, 0);
            this.MainTablePanel.Controls.Add(this.ProtocolRequestDetail, 1, 0);
            this.MainTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTablePanel.Location = new System.Drawing.Point(0, 0);
            this.MainTablePanel.Name = "MainTablePanel";
            this.MainTablePanel.RowCount = 1;
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTablePanel.Size = new System.Drawing.Size(1150, 770);
            this.MainTablePanel.TabIndex = 1;
            // 
            // LeftPanel
            // 
            this.LeftPanel.Controls.Add(this.RequestListView);
            this.LeftPanel.Controls.Add(this.toolStrip1);
            this.LeftPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LeftPanel.Location = new System.Drawing.Point(3, 3);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Size = new System.Drawing.Size(339, 764);
            this.LeftPanel.TabIndex = 0;
            // 
            // RequestListView
            // 
            this.RequestListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RequestListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.DateCol,
            this.RequestedByCol,
            this.AssignedToCol});
            this.RequestListView.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RequestListView.FullRowSelect = true;
            this.RequestListView.GridLines = true;
            this.RequestListView.Location = new System.Drawing.Point(0, 48);
            this.RequestListView.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.RequestListView.Name = "RequestListView";
            this.RequestListView.Size = new System.Drawing.Size(339, 712);
            this.RequestListView.TabIndex = 1;
            this.RequestListView.UseCompatibleStateImageBehavior = false;
            this.RequestListView.View = System.Windows.Forms.View.Details;
            this.RequestListView.SelectedIndexChanged += new System.EventHandler(this.RequestListView_SelectedIndexChanged);
            // 
            // DateCol
            // 
            this.DateCol.Text = "Date";
            this.DateCol.Width = 98;
            // 
            // RequestedByCol
            // 
            this.RequestedByCol.Text = "Requested By";
            this.RequestedByCol.Width = 112;
            // 
            // AssignedToCol
            // 
            this.AssignedToCol.Text = "Assigned To";
            this.AssignedToCol.Width = 108;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SearchButton,
            this.ResetButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(339, 38);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // SearchButton
            // 
            this.SearchButton.Image = global::Toxikon.ProtocolManager.Properties.Resources.ZoomNeutral_16xlG;
            this.SearchButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(80, 35);
            this.SearchButton.Text = "Find Sponsor";
            this.SearchButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.Image = ((System.Drawing.Image)(resources.GetObject("ResetButton.Image")));
            this.ResetButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(84, 35);
            this.ResetButton.Text = "Reset Request";
            this.ResetButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ResetButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // ProtocolRequestDetail
            // 
            this.ProtocolRequestDetail.BackColor = System.Drawing.Color.White;
            this.ProtocolRequestDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProtocolRequestDetail.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProtocolRequestDetail.Location = new System.Drawing.Point(348, 4);
            this.ProtocolRequestDetail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ProtocolRequestDetail.Name = "ProtocolRequestDetail";
            this.ProtocolRequestDetail.Size = new System.Drawing.Size(799, 762);
            this.ProtocolRequestDetail.TabIndex = 1;
            // 
            // HistoryView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MainTablePanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "HistoryView";
            this.Size = new System.Drawing.Size(1150, 770);
            this.MainTablePanel.ResumeLayout(false);
            this.LeftPanel.ResumeLayout(false);
            this.LeftPanel.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainTablePanel;
        private System.Windows.Forms.Panel LeftPanel;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton SearchButton;
        private System.Windows.Forms.ListView RequestListView;
        private System.Windows.Forms.ColumnHeader DateCol;
        private System.Windows.Forms.ColumnHeader RequestedByCol;
        private Protocols.ProtocolRequestReadOnlyView ProtocolRequestDetail;
        private System.Windows.Forms.ColumnHeader AssignedToCol;
        private System.Windows.Forms.ToolStripButton ResetButton;

    }
}
