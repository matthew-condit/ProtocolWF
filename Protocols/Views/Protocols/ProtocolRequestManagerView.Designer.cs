namespace Toxikon.ProtocolManager.Views.Protocols
{
    partial class ProtocolRequestManagerView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProtocolRequestManagerView));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ViewEventsButton = new System.Windows.Forms.ToolStripButton();
            this.ViewCommentsButton = new System.Windows.Forms.ToolStripButton();
            this.OpenFileButton = new System.Windows.Forms.ToolStripButton();
            this.MainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.RequestFormManagerView = new Toxikon.ProtocolManager.Views.RequestForms.RequestFormManagerView();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.SaveChangesButton = new System.Windows.Forms.ToolStripButton();
            this.DownloadReportButton = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.MainTableLayoutPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.toolStrip2.SuspendLayout();
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
            this.OpenFileButton});
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
            this.ViewEventsButton.ToolTipText = "View all events";
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
            this.ViewCommentsButton.ToolTipText = "View all comments";
            this.ViewCommentsButton.Click += new System.EventHandler(this.ViewCommentsButton_Click);
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.Image = ((System.Drawing.Image)(resources.GetObject("OpenFileButton.Image")));
            this.OpenFileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpenFileButton.Name = "OpenFileButton";
            this.OpenFileButton.Size = new System.Drawing.Size(61, 35);
            this.OpenFileButton.Text = "Open File";
            this.OpenFileButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.OpenFileButton.ToolTipText = "Open selected title protocol file";
            this.OpenFileButton.Click += new System.EventHandler(this.OpenFileButton_Click);
            // 
            // MainTableLayoutPanel
            // 
            this.MainTableLayoutPanel.ColumnCount = 1;
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutPanel.Controls.Add(this.TitlesListView, 0, 0);
            this.MainTableLayoutPanel.Controls.Add(this.panel2, 0, 1);
            this.MainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTableLayoutPanel.Location = new System.Drawing.Point(0, 38);
            this.MainTableLayoutPanel.Name = "MainTableLayoutPanel";
            this.MainTableLayoutPanel.RowCount = 2;
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.MainTableLayoutPanel.Size = new System.Drawing.Size(1024, 562);
            this.MainTableLayoutPanel.TabIndex = 47;
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
            this.TitlesListView.Size = new System.Drawing.Size(1018, 162);
            this.TitlesListView.TabIndex = 45;
            this.TitlesListView.UseCompatibleStateImageBehavior = false;
            this.TitlesListView.View = System.Windows.Forms.View.Details;
            // 
            // IDCol
            // 
            this.IDCol.Text = "ID";
            // 
            // TitleCol
            // 
            this.TitleCol.Text = "Titles";
            this.TitleCol.Width = 318;
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
            // 
            // PNCol
            // 
            this.PNCol.Text = "Project Number";
            // 
            // DepartmentCol
            // 
            this.DepartmentCol.Text = "Department";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.RequestFormManagerView);
            this.panel2.Controls.Add(this.toolStrip2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 171);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1018, 388);
            this.panel2.TabIndex = 46;
            // 
            // RequestFormManagerView
            // 
            this.RequestFormManagerView.Address = "Address";
            this.RequestFormManagerView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RequestFormManagerView.AssignedTo = "";
            this.RequestFormManagerView.BackColor = System.Drawing.Color.White;
            this.RequestFormManagerView.BillTo = "Bill To";
            this.RequestFormManagerView.City = "City";
            this.RequestFormManagerView.Comments = "Comments";
            this.RequestFormManagerView.Compliance = "Compliance";
            this.RequestFormManagerView.ContactName = "Contact";
            this.RequestFormManagerView.Cost = "Cost";
            this.RequestFormManagerView.DueDate = new System.DateTime(2015, 7, 20, 0, 0, 0, 0);
            this.RequestFormManagerView.Email = "Email";
            this.RequestFormManagerView.FaxNumber = "Fax";
            this.RequestFormManagerView.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RequestFormManagerView.Guidelines = "Guidelines";
            this.RequestFormManagerView.Location = new System.Drawing.Point(4, 42);
            this.RequestFormManagerView.Name = "RequestFormManagerView";
            this.RequestFormManagerView.PhoneNumber = "Phone Number";
            this.RequestFormManagerView.PONumber = "PO";
            this.RequestFormManagerView.ProtocolType = "Protocol Type";
            this.RequestFormManagerView.RequestedBy = "Requested By";
            this.RequestFormManagerView.RequestedDate = "Requested Date";
            this.RequestFormManagerView.SendVia = "Via";
            this.RequestFormManagerView.Size = new System.Drawing.Size(1014, 343);
            this.RequestFormManagerView.SponsorName = "Sponsor";
            this.RequestFormManagerView.State = "State";
            this.RequestFormManagerView.TabIndex = 2;
            this.RequestFormManagerView.ZipCode = "Zip Code";
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.White;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveChangesButton,
            this.DownloadReportButton});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1018, 38);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // SaveChangesButton
            // 
            this.SaveChangesButton.Image = global::Toxikon.ProtocolManager.Properties.Resources.save_16xLG;
            this.SaveChangesButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveChangesButton.Name = "SaveChangesButton";
            this.SaveChangesButton.Size = new System.Drawing.Size(84, 35);
            this.SaveChangesButton.Text = "Save Changes";
            this.SaveChangesButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.SaveChangesButton.Click += new System.EventHandler(this.SaveChangesButton_Click);
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
            // ProtocolRequestManagerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MainTableLayoutPanel);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ProtocolRequestManagerView";
            this.Size = new System.Drawing.Size(1024, 600);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.MainTableLayoutPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton ViewEventsButton;
        private System.Windows.Forms.ToolStripButton ViewCommentsButton;
        private System.Windows.Forms.ToolStripButton OpenFileButton;
        private System.Windows.Forms.TableLayoutPanel MainTableLayoutPanel;
        private System.Windows.Forms.ListView TitlesListView;
        private System.Windows.Forms.ColumnHeader IDCol;
        private System.Windows.Forms.ColumnHeader TitleCol;
        private System.Windows.Forms.ColumnHeader StatusCol;
        private System.Windows.Forms.ColumnHeader StatusDate;
        private System.Windows.Forms.ColumnHeader UserNameCol;
        private System.Windows.Forms.ColumnHeader CommentsCol;
        private System.Windows.Forms.ColumnHeader ProtocolNumberCol;
        private System.Windows.Forms.ColumnHeader FileNameCol;
        private System.Windows.Forms.ColumnHeader PNCol;
        private System.Windows.Forms.ColumnHeader DepartmentCol;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton SaveChangesButton;
        private System.Windows.Forms.ToolStripButton DownloadReportButton;
        private RequestForms.RequestFormManagerView RequestFormManagerView;
    }
}
