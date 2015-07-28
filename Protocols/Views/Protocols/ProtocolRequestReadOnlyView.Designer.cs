namespace Toxikon.ProtocolManager.Views.Protocols
{
    partial class ProtocolRequestReadOnlyView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProtocolRequestReadOnlyView));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ViewEventsButton = new System.Windows.Forms.ToolStripButton();
            this.ViewCommentsButton = new System.Windows.Forms.ToolStripButton();
            this.OpenFileButton = new System.Windows.Forms.ToolStripButton();
            this.DownloadReportButton = new System.Windows.Forms.ToolStripButton();
            this.RequestFormReadOnly = new Toxikon.ProtocolManager.Views.RequestForms.RequestFormReadOnly();
            this.TitlesListView = new System.Windows.Forms.ListView();
            this.IDCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TitleCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StatusCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StatusDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UserNameCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CommentsCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProtocolNumberCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FileNameCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PNCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DepartmentCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.White;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ViewEventsButton,
            this.ViewCommentsButton,
            this.OpenFileButton,
            this.DownloadReportButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1024, 38);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ViewEventsButton
            // 
            this.ViewEventsButton.Image = ((System.Drawing.Image)(resources.GetObject("ViewEventsButton.Image")));
            this.ViewEventsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ViewEventsButton.Name = "ViewEventsButton";
            this.ViewEventsButton.Size = new System.Drawing.Size(73, 35);
            this.ViewEventsButton.Text = "View Events";
            this.ViewEventsButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ViewEventsButton.ToolTipText = "View All Events of Selected Protocol";
            this.ViewEventsButton.Click += new System.EventHandler(this.ViewEventsButton_Click);
            // 
            // ViewCommentsButton
            // 
            this.ViewCommentsButton.Image = ((System.Drawing.Image)(resources.GetObject("ViewCommentsButton.Image")));
            this.ViewCommentsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ViewCommentsButton.Name = "ViewCommentsButton";
            this.ViewCommentsButton.Size = new System.Drawing.Size(98, 35);
            this.ViewCommentsButton.Text = "View Comments";
            this.ViewCommentsButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ViewCommentsButton.ToolTipText = "View All Comments of Selected Protocol";
            this.ViewCommentsButton.Click += new System.EventHandler(this.ViewCommentsButton_Click);
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.Image = global::Toxikon.ProtocolManager.Properties.Resources.Open_6296;
            this.OpenFileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpenFileButton.Name = "OpenFileButton";
            this.OpenFileButton.Size = new System.Drawing.Size(61, 35);
            this.OpenFileButton.Text = "Open File";
            this.OpenFileButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.OpenFileButton.Click += new System.EventHandler(this.OpenFileButton_Click);
            // 
            // DownloadReportButton
            // 
            this.DownloadReportButton.Image = global::Toxikon.ProtocolManager.Properties.Resources.move_to_bottom;
            this.DownloadReportButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DownloadReportButton.Name = "DownloadReportButton";
            this.DownloadReportButton.Size = new System.Drawing.Size(103, 35);
            this.DownloadReportButton.Text = "Download Report";
            this.DownloadReportButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.DownloadReportButton.Click += new System.EventHandler(this.DownloadReportButton_Click);
            // 
            // RequestFormReadOnly
            // 
            this.RequestFormReadOnly.Address = "Address";
            this.RequestFormReadOnly.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RequestFormReadOnly.AssignedTo = "Assigned To";
            this.RequestFormReadOnly.BackColor = System.Drawing.Color.White;
            this.RequestFormReadOnly.BillTo = "Bill To";
            this.RequestFormReadOnly.City = "City";
            this.RequestFormReadOnly.Comments = "Comments";
            this.RequestFormReadOnly.Compliance = "Compliance";
            this.RequestFormReadOnly.ContactName = "Contact";
            this.RequestFormReadOnly.Cost = "Cost";
            this.RequestFormReadOnly.DueDate = new System.DateTime(2015, 6, 25, 0, 0, 0, 0);
            this.RequestFormReadOnly.Email = "Email";
            this.RequestFormReadOnly.FaxNumber = "Fax";
            this.RequestFormReadOnly.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RequestFormReadOnly.Guidelines = "Guidelines";
            this.RequestFormReadOnly.Location = new System.Drawing.Point(3, 228);
            this.RequestFormReadOnly.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RequestFormReadOnly.Name = "RequestFormReadOnly";
            this.RequestFormReadOnly.PhoneNumber = "Phone Number";
            this.RequestFormReadOnly.PONumber = "PO";
            this.RequestFormReadOnly.ProtocolType = "Protocol Type";
            this.RequestFormReadOnly.RequestedBy = "Requested By";
            this.RequestFormReadOnly.RequestedDate = "Requested Date";
            this.RequestFormReadOnly.SendVia = "Via";
            this.RequestFormReadOnly.Size = new System.Drawing.Size(1018, 330);
            this.RequestFormReadOnly.SponsorName = "Sponsor";
            this.RequestFormReadOnly.State = "State";
            this.RequestFormReadOnly.TabIndex = 0;
            this.RequestFormReadOnly.ZipCode = "Zip Code";
            // 
            // TitlesListView
            // 
            this.TitlesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IDCol,
            this.TitleCol,
            this.StatusCol,
            this.StatusDate,
            this.UserNameCol,
            this.CommentsCol,
            this.ProtocolNumberCol,
            this.FileNameCol,
            this.PNCol,
            this.DepartmentCol});
            this.TitlesListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TitlesListView.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitlesListView.FullRowSelect = true;
            this.TitlesListView.GridLines = true;
            this.TitlesListView.Location = new System.Drawing.Point(3, 3);
            this.TitlesListView.Name = "TitlesListView";
            this.TitlesListView.Size = new System.Drawing.Size(1018, 218);
            this.TitlesListView.TabIndex = 45;
            this.TitlesListView.UseCompatibleStateImageBehavior = false;
            this.TitlesListView.View = System.Windows.Forms.View.Details;
            this.TitlesListView.Leave += new System.EventHandler(this.TitlesListView_Leave);
            // 
            // IDCol
            // 
            this.IDCol.Text = "ID";
            // 
            // TitleCol
            // 
            this.TitleCol.Text = "Titles";
            this.TitleCol.Width = 107;
            // 
            // StatusCol
            // 
            this.StatusCol.Text = "Latest Status";
            this.StatusCol.Width = 195;
            // 
            // StatusDate
            // 
            this.StatusDate.Text = "Latest Status Date";
            this.StatusDate.Width = 131;
            // 
            // UserNameCol
            // 
            this.UserNameCol.Text = "Added By";
            this.UserNameCol.Width = 105;
            // 
            // CommentsCol
            // 
            this.CommentsCol.Text = "Total Comments";
            // 
            // ProtocolNumberCol
            // 
            this.ProtocolNumberCol.Text = "Protocol Number";
            // 
            // FileNameCol
            // 
            this.FileNameCol.Text = "File Name";
            this.FileNameCol.Width = 121;
            // 
            // PNCol
            // 
            this.PNCol.Text = "Project Number";
            // 
            // DepartmentCol
            // 
            this.DepartmentCol.Text = "Department";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.RequestFormReadOnly, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.TitlesListView, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 38);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1024, 562);
            this.tableLayoutPanel1.TabIndex = 47;
            // 
            // ProtocolRequestReadOnlyView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ProtocolRequestReadOnlyView";
            this.Size = new System.Drawing.Size(1024, 600);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton ViewEventsButton;
        private System.Windows.Forms.ToolStripButton ViewCommentsButton;
        private System.Windows.Forms.ToolStripButton DownloadReportButton;
        private RequestForms.RequestFormReadOnly RequestFormReadOnly;
        private System.Windows.Forms.ListView TitlesListView;
        private System.Windows.Forms.ColumnHeader TitleCol;
        private System.Windows.Forms.ColumnHeader StatusCol;
        private System.Windows.Forms.ColumnHeader StatusDate;
        private System.Windows.Forms.ColumnHeader UserNameCol;
        private System.Windows.Forms.ColumnHeader CommentsCol;
        private System.Windows.Forms.ColumnHeader ProtocolNumberCol;
        private System.Windows.Forms.ToolStripButton OpenFileButton;
        private System.Windows.Forms.ColumnHeader FileNameCol;
        private System.Windows.Forms.ColumnHeader PNCol;
        private System.Windows.Forms.ColumnHeader DepartmentCol;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ColumnHeader IDCol;
    }
}
