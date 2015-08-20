namespace Toxikon.ProtocolManager.Views.Protocols
{
    partial class ProtocolRequestEditView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProtocolRequestEditView));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.AddTitleButton = new System.Windows.Forms.ToolStripButton();
            this.RemoveTemplateButton = new System.Windows.Forms.ToolStripButton();
            this.AddEventButton = new System.Windows.Forms.ToolStripButton();
            this.ViewEventsButton = new System.Windows.Forms.ToolStripButton();
            this.AddCommentButton = new System.Windows.Forms.ToolStripButton();
            this.ViewCommentsButton = new System.Windows.Forms.ToolStripButton();
            this.AddProtocolNumber = new System.Windows.Forms.ToolStripButton();
            this.ReviseProtocolButton = new System.Windows.Forms.ToolStripButton();
            this.DepartmentButton = new System.Windows.Forms.ToolStripButton();
            this.UpdateProjectNumberButton = new System.Windows.Forms.ToolStripButton();
            this.UpdateFilePathButton = new System.Windows.Forms.ToolStripButton();
            this.OpenFileButton = new System.Windows.Forms.ToolStripButton();
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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.MainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.RequestFormEditView = new Toxikon.ProtocolManager.Views.RequestForms.RequestFormEdit();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.SaveChangesButton = new System.Windows.Forms.ToolStripButton();
            this.CloseRequestButton = new System.Windows.Forms.ToolStripButton();
            this.DownloadReportButton = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.titleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addTitleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeTitleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.protocolEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewAllEventsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewCommentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewAllCommentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.protocolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateProtocolButton = new System.Windows.Forms.ToolStripMenuItem();
            this.updateFilePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.protocolNumberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.assignProtocolNumberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reviseProtocolNumberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.othersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.assignDepartmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.assignProjectNumberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.MainTableLayoutPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.White;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddTitleButton,
            this.RemoveTemplateButton,
            this.AddEventButton,
            this.ViewEventsButton,
            this.AddCommentButton,
            this.ViewCommentsButton,
            this.AddProtocolNumber,
            this.ReviseProtocolButton,
            this.DepartmentButton,
            this.UpdateProjectNumberButton,
            this.UpdateFilePathButton,
            this.OpenFileButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1024, 38);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // AddTitleButton
            // 
            this.AddTitleButton.Image = global::Toxikon.ProtocolManager.Properties.Resources.action_add_16xLG;
            this.AddTitleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddTitleButton.Name = "AddTitleButton";
            this.AddTitleButton.Size = new System.Drawing.Size(59, 35);
            this.AddTitleButton.Text = "Add Title";
            this.AddTitleButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.AddTitleButton.ToolTipText = "Add new title";
            this.AddTitleButton.Click += new System.EventHandler(this.AddTitleButton_Click);
            // 
            // RemoveTemplateButton
            // 
            this.RemoveTemplateButton.Image = ((System.Drawing.Image)(resources.GetObject("RemoveTemplateButton.Image")));
            this.RemoveTemplateButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RemoveTemplateButton.Name = "RemoveTemplateButton";
            this.RemoveTemplateButton.Size = new System.Drawing.Size(80, 35);
            this.RemoveTemplateButton.Text = "Remove Title";
            this.RemoveTemplateButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.RemoveTemplateButton.ToolTipText = "Edit selected title";
            this.RemoveTemplateButton.Click += new System.EventHandler(this.RemoveTitleButton_Click);
            // 
            // AddEventButton
            // 
            this.AddEventButton.Image = ((System.Drawing.Image)(resources.GetObject("AddEventButton.Image")));
            this.AddEventButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddEventButton.Name = "AddEventButton";
            this.AddEventButton.Size = new System.Drawing.Size(65, 35);
            this.AddEventButton.Text = "Add Event";
            this.AddEventButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.AddEventButton.ToolTipText = "Add new event to selected title";
            this.AddEventButton.Click += new System.EventHandler(this.AddEventButton_Click);
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
            // AddCommentButton
            // 
            this.AddCommentButton.Image = ((System.Drawing.Image)(resources.GetObject("AddCommentButton.Image")));
            this.AddCommentButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddCommentButton.Name = "AddCommentButton";
            this.AddCommentButton.Size = new System.Drawing.Size(95, 35);
            this.AddCommentButton.Text = "Add Comments";
            this.AddCommentButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.AddCommentButton.ToolTipText = "Add new comments";
            this.AddCommentButton.Click += new System.EventHandler(this.AddCommentButton_Click);
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
            // AddProtocolNumber
            // 
            this.AddProtocolNumber.Image = ((System.Drawing.Image)(resources.GetObject("AddProtocolNumber.Image")));
            this.AddProtocolNumber.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddProtocolNumber.Name = "AddProtocolNumber";
            this.AddProtocolNumber.Size = new System.Drawing.Size(103, 35);
            this.AddProtocolNumber.Text = "Protocol Number";
            this.AddProtocolNumber.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.AddProtocolNumber.ToolTipText = "Assign new protocol number";
            this.AddProtocolNumber.Click += new System.EventHandler(this.AddProtocolNumber_Click);
            // 
            // ReviseProtocolButton
            // 
            this.ReviseProtocolButton.Image = ((System.Drawing.Image)(resources.GetObject("ReviseProtocolButton.Image")));
            this.ReviseProtocolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ReviseProtocolButton.Name = "ReviseProtocolButton";
            this.ReviseProtocolButton.Size = new System.Drawing.Size(92, 35);
            this.ReviseProtocolButton.Text = "Revise Protocol";
            this.ReviseProtocolButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ReviseProtocolButton.ToolTipText = "Update protocol number";
            this.ReviseProtocolButton.Click += new System.EventHandler(this.RevisedProtocolButton_Click);
            // 
            // DepartmentButton
            // 
            this.DepartmentButton.Image = ((System.Drawing.Image)(resources.GetObject("DepartmentButton.Image")));
            this.DepartmentButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DepartmentButton.Name = "DepartmentButton";
            this.DepartmentButton.Size = new System.Drawing.Size(74, 35);
            this.DepartmentButton.Text = "Department";
            this.DepartmentButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.DepartmentButton.ToolTipText = "Assign department to selected title";
            this.DepartmentButton.Click += new System.EventHandler(this.DepartmentButton_Click);
            // 
            // UpdateProjectNumberButton
            // 
            this.UpdateProjectNumberButton.Image = ((System.Drawing.Image)(resources.GetObject("UpdateProjectNumberButton.Image")));
            this.UpdateProjectNumberButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UpdateProjectNumberButton.Name = "UpdateProjectNumberButton";
            this.UpdateProjectNumberButton.Size = new System.Drawing.Size(95, 35);
            this.UpdateProjectNumberButton.Text = "Project Number";
            this.UpdateProjectNumberButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.UpdateProjectNumberButton.ToolTipText = "Assign Project Number to selected title";
            this.UpdateProjectNumberButton.Click += new System.EventHandler(this.UpdateProjectNumberButton_Click);
            // 
            // UpdateFilePathButton
            // 
            this.UpdateFilePathButton.Image = ((System.Drawing.Image)(resources.GetObject("UpdateFilePathButton.Image")));
            this.UpdateFilePathButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UpdateFilePathButton.Name = "UpdateFilePathButton";
            this.UpdateFilePathButton.Size = new System.Drawing.Size(97, 35);
            this.UpdateFilePathButton.Text = "Update File Path";
            this.UpdateFilePathButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.UpdateFilePathButton.ToolTipText = "Update Protocol file location";
            this.UpdateFilePathButton.Click += new System.EventHandler(this.UpdateFilePathButton_Click);
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
            this.TitlesListView.Size = new System.Drawing.Size(1018, 123);
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
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // MainTableLayoutPanel
            // 
            this.MainTableLayoutPanel.ColumnCount = 1;
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutPanel.Controls.Add(this.TitlesListView, 0, 0);
            this.MainTableLayoutPanel.Controls.Add(this.panel2, 0, 1);
            this.MainTableLayoutPanel.Controls.Add(this.menuStrip1, 0, 2);
            this.MainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTableLayoutPanel.Location = new System.Drawing.Point(0, 38);
            this.MainTableLayoutPanel.Name = "MainTableLayoutPanel";
            this.MainTableLayoutPanel.RowCount = 3;
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.54159F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 72.45841F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 91F));
            this.MainTableLayoutPanel.Size = new System.Drawing.Size(1024, 562);
            this.MainTableLayoutPanel.TabIndex = 46;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.RequestFormEditView);
            this.panel2.Controls.Add(this.toolStrip2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 132);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1018, 335);
            this.panel2.TabIndex = 46;
            // 
            // RequestFormEditView
            // 
            this.RequestFormEditView.Address = "Address";
            this.RequestFormEditView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RequestFormEditView.AssignedTo = "";
            this.RequestFormEditView.BackColor = System.Drawing.Color.White;
            this.RequestFormEditView.BillTo = "";
            this.RequestFormEditView.City = "City";
            this.RequestFormEditView.Comments = "Comments";
            this.RequestFormEditView.Compliance = "";
            this.RequestFormEditView.ContactName = "Contact";
            this.RequestFormEditView.Cost = "";
            this.RequestFormEditView.DueDate = new System.DateTime(2015, 7, 6, 17, 11, 19, 859);
            this.RequestFormEditView.Email = "Email";
            this.RequestFormEditView.FaxNumber = "Fax";
            this.RequestFormEditView.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RequestFormEditView.Guidelines = "";
            this.RequestFormEditView.Location = new System.Drawing.Point(0, 42);
            this.RequestFormEditView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RequestFormEditView.Name = "RequestFormEditView";
            this.RequestFormEditView.PhoneNumber = "Phone Number";
            this.RequestFormEditView.PONumber = "PO";
            this.RequestFormEditView.ProtocolType = "";
            this.RequestFormEditView.RequestedBy = "Requested By";
            this.RequestFormEditView.RequestedDate = "Requested Date";
            this.RequestFormEditView.SendVia = "";
            this.RequestFormEditView.Size = new System.Drawing.Size(1018, 268);
            this.RequestFormEditView.SponsorName = "Sponsor";
            this.RequestFormEditView.State = "State";
            this.RequestFormEditView.TabIndex = 2;
            this.RequestFormEditView.ZipCode = "Zip Code";
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.White;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveChangesButton,
            this.CloseRequestButton,
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
            // CloseRequestButton
            // 
            this.CloseRequestButton.Image = global::Toxikon.ProtocolManager.Properties.Resources.StatusAnnotations_Complete_and_ok_16xLG_color;
            this.CloseRequestButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CloseRequestButton.Name = "CloseRequestButton";
            this.CloseRequestButton.Size = new System.Drawing.Size(85, 35);
            this.CloseRequestButton.Text = "Close Request";
            this.CloseRequestButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.CloseRequestButton.Click += new System.EventHandler(this.CloseRequestButton_Click);
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
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Window;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.titleToolStripMenuItem,
            this.protocolEventToolStripMenuItem,
            this.commentsToolStripMenuItem,
            this.protocolNumberToolStripMenuItem,
            this.protocolsToolStripMenuItem,
            this.othersToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 470);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1024, 24);
            this.menuStrip1.TabIndex = 47;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // titleToolStripMenuItem
            // 
            this.titleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addTitleToolStripMenuItem,
            this.removeTitleToolStripMenuItem});
            this.titleToolStripMenuItem.Name = "titleToolStripMenuItem";
            this.titleToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.titleToolStripMenuItem.Text = "Title";
            // 
            // addTitleToolStripMenuItem
            // 
            this.addTitleToolStripMenuItem.Image = global::Toxikon.ProtocolManager.Properties.Resources.action_add_16xLG;
            this.addTitleToolStripMenuItem.Name = "addTitleToolStripMenuItem";
            this.addTitleToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addTitleToolStripMenuItem.Text = "Add Title";
            this.addTitleToolStripMenuItem.Click += new System.EventHandler(this.AddTitleButton_Click);
            // 
            // removeTitleToolStripMenuItem
            // 
            this.removeTitleToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("removeTitleToolStripMenuItem.Image")));
            this.removeTitleToolStripMenuItem.Name = "removeTitleToolStripMenuItem";
            this.removeTitleToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.removeTitleToolStripMenuItem.Text = "Remove Title";
            this.removeTitleToolStripMenuItem.Click += new System.EventHandler(this.RemoveTitleButton_Click);
            // 
            // protocolEventToolStripMenuItem
            // 
            this.protocolEventToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewEventToolStripMenuItem,
            this.viewAllEventsToolStripMenuItem});
            this.protocolEventToolStripMenuItem.Name = "protocolEventToolStripMenuItem";
            this.protocolEventToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.protocolEventToolStripMenuItem.Text = "Protocol Event";
            // 
            // addNewEventToolStripMenuItem
            // 
            this.addNewEventToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addNewEventToolStripMenuItem.Image")));
            this.addNewEventToolStripMenuItem.Name = "addNewEventToolStripMenuItem";
            this.addNewEventToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.addNewEventToolStripMenuItem.Text = "Add New Event";
            this.addNewEventToolStripMenuItem.Click += new System.EventHandler(this.AddEventButton_Click);
            // 
            // viewAllEventsToolStripMenuItem
            // 
            this.viewAllEventsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("viewAllEventsToolStripMenuItem.Image")));
            this.viewAllEventsToolStripMenuItem.Name = "viewAllEventsToolStripMenuItem";
            this.viewAllEventsToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.viewAllEventsToolStripMenuItem.Text = "View All Events";
            this.viewAllEventsToolStripMenuItem.Click += new System.EventHandler(this.ViewEventsButton_Click);
            // 
            // commentsToolStripMenuItem
            // 
            this.commentsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewCommentsToolStripMenuItem,
            this.viewAllCommentsToolStripMenuItem});
            this.commentsToolStripMenuItem.Name = "commentsToolStripMenuItem";
            this.commentsToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.commentsToolStripMenuItem.Text = "Comments";
            // 
            // addNewCommentsToolStripMenuItem
            // 
            this.addNewCommentsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addNewCommentsToolStripMenuItem.Image")));
            this.addNewCommentsToolStripMenuItem.Name = "addNewCommentsToolStripMenuItem";
            this.addNewCommentsToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.addNewCommentsToolStripMenuItem.Text = "Add New Comments";
            this.addNewCommentsToolStripMenuItem.Click += new System.EventHandler(this.AddCommentButton_Click);
            // 
            // viewAllCommentsToolStripMenuItem
            // 
            this.viewAllCommentsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("viewAllCommentsToolStripMenuItem.Image")));
            this.viewAllCommentsToolStripMenuItem.Name = "viewAllCommentsToolStripMenuItem";
            this.viewAllCommentsToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.viewAllCommentsToolStripMenuItem.Text = "View All Comments";
            this.viewAllCommentsToolStripMenuItem.Click += new System.EventHandler(this.ViewCommentsButton_Click);
            // 
            // protocolsToolStripMenuItem
            // 
            this.protocolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateProtocolButton,
            this.updateFilePathToolStripMenuItem,
            this.openFileToolStripMenuItem});
            this.protocolsToolStripMenuItem.Name = "protocolsToolStripMenuItem";
            this.protocolsToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.protocolsToolStripMenuItem.Text = "Protocol";
            // 
            // CreateProtocolButton
            // 
            this.CreateProtocolButton.Image = global::Toxikon.ProtocolManager.Properties.Resources.RSReport_16xLG;
            this.CreateProtocolButton.Name = "CreateProtocolButton";
            this.CreateProtocolButton.Size = new System.Drawing.Size(160, 22);
            this.CreateProtocolButton.Text = "Create Protocol";
            this.CreateProtocolButton.Click += new System.EventHandler(this.CreateProtocolButton_Click);
            // 
            // updateFilePathToolStripMenuItem
            // 
            this.updateFilePathToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("updateFilePathToolStripMenuItem.Image")));
            this.updateFilePathToolStripMenuItem.Name = "updateFilePathToolStripMenuItem";
            this.updateFilePathToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.updateFilePathToolStripMenuItem.Text = "Update File Path";
            this.updateFilePathToolStripMenuItem.Click += new System.EventHandler(this.UpdateFilePathButton_Click);
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openFileToolStripMenuItem.Image")));
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.openFileToolStripMenuItem.Text = "Open File";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.OpenFileButton_Click);
            // 
            // protocolNumberToolStripMenuItem
            // 
            this.protocolNumberToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.assignProtocolNumberToolStripMenuItem,
            this.reviseProtocolNumberToolStripMenuItem});
            this.protocolNumberToolStripMenuItem.Name = "protocolNumberToolStripMenuItem";
            this.protocolNumberToolStripMenuItem.Size = new System.Drawing.Size(111, 20);
            this.protocolNumberToolStripMenuItem.Text = "Protocol Number";
            // 
            // assignProtocolNumberToolStripMenuItem
            // 
            this.assignProtocolNumberToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("assignProtocolNumberToolStripMenuItem.Image")));
            this.assignProtocolNumberToolStripMenuItem.Name = "assignProtocolNumberToolStripMenuItem";
            this.assignProtocolNumberToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.assignProtocolNumberToolStripMenuItem.Text = "Assign Protocol Number";
            // 
            // reviseProtocolNumberToolStripMenuItem
            // 
            this.reviseProtocolNumberToolStripMenuItem.Image = global::Toxikon.ProtocolManager.Properties.Resources.PencilAngled_16xLG_color;
            this.reviseProtocolNumberToolStripMenuItem.Name = "reviseProtocolNumberToolStripMenuItem";
            this.reviseProtocolNumberToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.reviseProtocolNumberToolStripMenuItem.Text = "Revise Protocol Number";
            // 
            // othersToolStripMenuItem
            // 
            this.othersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.assignDepartmentToolStripMenuItem,
            this.assignProjectNumberToolStripMenuItem});
            this.othersToolStripMenuItem.Name = "othersToolStripMenuItem";
            this.othersToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.othersToolStripMenuItem.Text = "Others";
            // 
            // assignDepartmentToolStripMenuItem
            // 
            this.assignDepartmentToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("assignDepartmentToolStripMenuItem.Image")));
            this.assignDepartmentToolStripMenuItem.Name = "assignDepartmentToolStripMenuItem";
            this.assignDepartmentToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.assignDepartmentToolStripMenuItem.Text = "Assign Department";
            // 
            // assignProjectNumberToolStripMenuItem
            // 
            this.assignProjectNumberToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("assignProjectNumberToolStripMenuItem.Image")));
            this.assignProjectNumberToolStripMenuItem.Name = "assignProjectNumberToolStripMenuItem";
            this.assignProjectNumberToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.assignProjectNumberToolStripMenuItem.Text = "Update Project Number";
            // 
            // ProtocolRequestEditView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MainTableLayoutPanel);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ProtocolRequestEditView";
            this.Size = new System.Drawing.Size(1024, 600);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.MainTableLayoutPanel.ResumeLayout(false);
            this.MainTableLayoutPanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton AddCommentButton;
        private System.Windows.Forms.ToolStripButton AddEventButton;
        private System.Windows.Forms.ToolStripButton AddTitleButton;
        private System.Windows.Forms.ToolStripButton RemoveTemplateButton;
        private System.Windows.Forms.ListView TitlesListView;
        private System.Windows.Forms.ColumnHeader TitleCol;
        private System.Windows.Forms.ColumnHeader StatusCol;
        private System.Windows.Forms.ColumnHeader StatusDate;
        private System.Windows.Forms.ColumnHeader UserNameCol;
        private System.Windows.Forms.ToolStripButton ViewEventsButton;
        private System.Windows.Forms.ToolStripButton ViewCommentsButton;
        private System.Windows.Forms.ColumnHeader CommentsCol;
        private System.Windows.Forms.ToolStripButton AddProtocolNumber;
        private System.Windows.Forms.ColumnHeader ProtocolNumberCol;
        private System.Windows.Forms.ToolStripButton ReviseProtocolButton;
        private System.Windows.Forms.ToolStripButton UpdateFilePathButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ColumnHeader FileNameCol;
        private System.Windows.Forms.ToolStripButton OpenFileButton;
        private System.Windows.Forms.ToolStripButton UpdateProjectNumberButton;
        private System.Windows.Forms.ColumnHeader PNCol;
        private System.Windows.Forms.ToolStripButton DepartmentButton;
        private System.Windows.Forms.ColumnHeader DepartmentCol;
        private System.Windows.Forms.TableLayoutPanel MainTableLayoutPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton SaveChangesButton;
        private System.Windows.Forms.ToolStripButton CloseRequestButton;
        private System.Windows.Forms.ToolStripButton DownloadReportButton;
        private RequestForms.RequestFormEdit RequestFormEditView;
        private System.Windows.Forms.ColumnHeader IDCol;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem titleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addTitleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeTitleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem protocolEventToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewEventToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewAllEventsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewCommentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewAllCommentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem protocolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CreateProtocolButton;
        private System.Windows.Forms.ToolStripMenuItem updateFilePathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem protocolNumberToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem assignProtocolNumberToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reviseProtocolNumberToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem othersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem assignDepartmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem assignProjectNumberToolStripMenuItem;
    }
}
