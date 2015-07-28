namespace Toxikon.ProtocolManager.Views.Protocols
{
    partial class ProtocolRequestDirectorView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProtocolRequestDirectorView));
            this.MainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.RequestFormDirectorView = new Toxikon.ProtocolManager.Views.RequestForms.RequestFormReadOnly();
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
            this.ViewEventsButton = new System.Windows.Forms.ToolStripButton();
            this.ViewCommentsButton = new System.Windows.Forms.ToolStripButton();
            this.OpenFileButton = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.AddEventButton = new System.Windows.Forms.ToolStripButton();
            this.AddCommentButton = new System.Windows.Forms.ToolStripButton();
            this.MainTableLayoutPanel.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTableLayoutPanel
            // 
            this.MainTableLayoutPanel.ColumnCount = 1;
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutPanel.Controls.Add(this.RequestFormDirectorView, 0, 1);
            this.MainTableLayoutPanel.Controls.Add(this.TitlesListView, 0, 0);
            this.MainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTableLayoutPanel.Location = new System.Drawing.Point(0, 38);
            this.MainTableLayoutPanel.Name = "MainTableLayoutPanel";
            this.MainTableLayoutPanel.RowCount = 2;
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.MainTableLayoutPanel.Size = new System.Drawing.Size(1024, 562);
            this.MainTableLayoutPanel.TabIndex = 48;
            // 
            // RequestFormDirectorView
            // 
            this.RequestFormDirectorView.Address = "Address";
            this.RequestFormDirectorView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RequestFormDirectorView.AssignedTo = "Assigned To";
            this.RequestFormDirectorView.BackColor = System.Drawing.Color.White;
            this.RequestFormDirectorView.BillTo = "Bill To";
            this.RequestFormDirectorView.City = "City";
            this.RequestFormDirectorView.Comments = "Comments";
            this.RequestFormDirectorView.Compliance = "Compliance";
            this.RequestFormDirectorView.ContactName = "Contact";
            this.RequestFormDirectorView.Cost = "Cost";
            this.RequestFormDirectorView.DueDate = new System.DateTime(2015, 7, 28, 0, 0, 0, 0);
            this.RequestFormDirectorView.Email = "Email";
            this.RequestFormDirectorView.FaxNumber = "Fax";
            this.RequestFormDirectorView.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RequestFormDirectorView.Guidelines = "Guidelines";
            this.RequestFormDirectorView.Location = new System.Drawing.Point(3, 172);
            this.RequestFormDirectorView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RequestFormDirectorView.Name = "RequestFormDirectorView";
            this.RequestFormDirectorView.PhoneNumber = "Phone Number";
            this.RequestFormDirectorView.PONumber = "PO";
            this.RequestFormDirectorView.ProtocolType = "Protocol Type";
            this.RequestFormDirectorView.RequestedBy = "Requested By";
            this.RequestFormDirectorView.RequestedDate = "Requested Date";
            this.RequestFormDirectorView.SendVia = "Via";
            this.RequestFormDirectorView.Size = new System.Drawing.Size(1018, 386);
            this.RequestFormDirectorView.SponsorName = "Sponsor";
            this.RequestFormDirectorView.State = "State";
            this.RequestFormDirectorView.TabIndex = 46;
            this.RequestFormDirectorView.ZipCode = "Zip Code";
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
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.White;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddEventButton,
            this.ViewEventsButton,
            this.AddCommentButton,
            this.ViewCommentsButton,
            this.OpenFileButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1024, 38);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // AddEventButton
            // 
            this.AddEventButton.Image = ((System.Drawing.Image)(resources.GetObject("AddEventButton.Image")));
            this.AddEventButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddEventButton.Name = "AddEventButton";
            this.AddEventButton.Size = new System.Drawing.Size(65, 35);
            this.AddEventButton.Text = "Add Event";
            this.AddEventButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.AddEventButton.Click += new System.EventHandler(this.AddEventButton_Click);
            // 
            // AddCommentButton
            // 
            this.AddCommentButton.Image = ((System.Drawing.Image)(resources.GetObject("AddCommentButton.Image")));
            this.AddCommentButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddCommentButton.Name = "AddCommentButton";
            this.AddCommentButton.Size = new System.Drawing.Size(90, 35);
            this.AddCommentButton.Text = "Add Comment";
            this.AddCommentButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.AddCommentButton.Click += new System.EventHandler(this.AddCommentButton_Click);
            // 
            // ProtocolRequestDirectorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MainTableLayoutPanel);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ProtocolRequestDirectorView";
            this.Size = new System.Drawing.Size(1024, 600);
            this.MainTableLayoutPanel.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainTableLayoutPanel;
        private RequestForms.RequestFormReadOnly RequestFormDirectorView;
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
        private System.Windows.Forms.ToolStripButton ViewEventsButton;
        private System.Windows.Forms.ToolStripButton ViewCommentsButton;
        private System.Windows.Forms.ToolStripButton OpenFileButton;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton AddEventButton;
        private System.Windows.Forms.ToolStripButton AddCommentButton;
    }
}
