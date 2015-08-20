namespace Toxikon.ProtocolManager.Views.Protocols
{
    partial class ProtocolRequestEditView2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProtocolRequestEditView2));
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton6 = new System.Windows.Forms.ToolStripDropDownButton();
            this.saveChangesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeRequestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.addTitleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeTitleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.addEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewEventsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton3 = new System.Windows.Forms.ToolStripDropDownButton();
            this.addCommentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewCommentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton4 = new System.Windows.Forms.ToolStripDropDownButton();
            this.createNewProtocolNumberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reviseProtocolNumberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton5 = new System.Windows.Forms.ToolStripDropDownButton();
            this.createProtocolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateFilePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.assignDepartmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.assignProjectNumberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainTableLayoutPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
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
            this.TitlesListView.Size = new System.Drawing.Size(1018, 179);
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
            this.MainTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainTableLayoutPanel.ColumnCount = 1;
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutPanel.Controls.Add(this.panel2, 0, 1);
            this.MainTableLayoutPanel.Controls.Add(this.TitlesListView, 0, 0);
            this.MainTableLayoutPanel.Location = new System.Drawing.Point(0, 35);
            this.MainTableLayoutPanel.Name = "MainTableLayoutPanel";
            this.MainTableLayoutPanel.RowCount = 2;
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.92035F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67.07964F));
            this.MainTableLayoutPanel.Size = new System.Drawing.Size(1024, 565);
            this.MainTableLayoutPanel.TabIndex = 46;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.RequestFormEditView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 188);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1018, 374);
            this.panel2.TabIndex = 46;
            // 
            // RequestFormEditView
            // 
            this.RequestFormEditView.Address = "Address";
            this.RequestFormEditView.AssignedTo = "";
            this.RequestFormEditView.BackColor = System.Drawing.Color.White;
            this.RequestFormEditView.BillTo = "";
            this.RequestFormEditView.City = "City";
            this.RequestFormEditView.Comments = "Comments";
            this.RequestFormEditView.Compliance = "";
            this.RequestFormEditView.ContactName = "Contact";
            this.RequestFormEditView.Cost = "";
            this.RequestFormEditView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RequestFormEditView.DueDate = new System.DateTime(2015, 7, 6, 17, 11, 19, 859);
            this.RequestFormEditView.Email = "Email";
            this.RequestFormEditView.FaxNumber = "Fax";
            this.RequestFormEditView.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RequestFormEditView.Guidelines = "";
            this.RequestFormEditView.Location = new System.Drawing.Point(0, 0);
            this.RequestFormEditView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RequestFormEditView.Name = "RequestFormEditView";
            this.RequestFormEditView.PhoneNumber = "Phone Number";
            this.RequestFormEditView.PONumber = "PO";
            this.RequestFormEditView.ProtocolType = "";
            this.RequestFormEditView.RequestedBy = "Requested By";
            this.RequestFormEditView.RequestedDate = "Requested Date";
            this.RequestFormEditView.SendVia = "";
            this.RequestFormEditView.Size = new System.Drawing.Size(1018, 374);
            this.RequestFormEditView.SponsorName = "Sponsor";
            this.RequestFormEditView.State = "State";
            this.RequestFormEditView.TabIndex = 2;
            this.RequestFormEditView.ZipCode = "Zip Code";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.White;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton6,
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton2,
            this.toolStripDropDownButton3,
            this.toolStripDropDownButton4,
            this.toolStripDropDownButton5});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(5);
            this.toolStrip1.Size = new System.Drawing.Size(1024, 32);
            this.toolStrip1.TabIndex = 47;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton6
            // 
            this.toolStripDropDownButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton6.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveChangesToolStripMenuItem,
            this.closeRequestToolStripMenuItem,
            this.downloadReportToolStripMenuItem});
            this.toolStripDropDownButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton6.Image")));
            this.toolStripDropDownButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton6.Margin = new System.Windows.Forms.Padding(0, 1, 10, 2);
            this.toolStripDropDownButton6.Name = "toolStripDropDownButton6";
            this.toolStripDropDownButton6.Size = new System.Drawing.Size(110, 19);
            this.toolStripDropDownButton6.Text = "Protocol Request";
            // 
            // saveChangesToolStripMenuItem
            // 
            this.saveChangesToolStripMenuItem.Image = global::Toxikon.ProtocolManager.Properties.Resources.save_16xLG;
            this.saveChangesToolStripMenuItem.Name = "saveChangesToolStripMenuItem";
            this.saveChangesToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.saveChangesToolStripMenuItem.Text = "Save Changes";
            this.saveChangesToolStripMenuItem.Click += new System.EventHandler(this.SaveChangesButton_Click);
            // 
            // closeRequestToolStripMenuItem
            // 
            this.closeRequestToolStripMenuItem.Image = global::Toxikon.ProtocolManager.Properties.Resources.StatusAnnotations_Complete_and_ok_16xLG_color;
            this.closeRequestToolStripMenuItem.Name = "closeRequestToolStripMenuItem";
            this.closeRequestToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.closeRequestToolStripMenuItem.Text = "Close Request";
            this.closeRequestToolStripMenuItem.Click += new System.EventHandler(this.CloseRequestButton_Click);
            // 
            // downloadReportToolStripMenuItem
            // 
            this.downloadReportToolStripMenuItem.Image = global::Toxikon.ProtocolManager.Properties.Resources.move_to_bottom;
            this.downloadReportToolStripMenuItem.Name = "downloadReportToolStripMenuItem";
            this.downloadReportToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.downloadReportToolStripMenuItem.Text = "Download Report";
            this.downloadReportToolStripMenuItem.Click += new System.EventHandler(this.DownloadReportButton_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addTitleToolStripMenuItem,
            this.removeTitleToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Margin = new System.Windows.Forms.Padding(0, 1, 10, 2);
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(43, 19);
            this.toolStripDropDownButton1.Text = "Title";
            // 
            // addTitleToolStripMenuItem
            // 
            this.addTitleToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addTitleToolStripMenuItem.Image")));
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
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addEventToolStripMenuItem,
            this.viewEventsToolStripMenuItem});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Margin = new System.Windows.Forms.Padding(0, 1, 10, 2);
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(97, 19);
            this.toolStripDropDownButton2.Text = "Protocol Event";
            // 
            // addEventToolStripMenuItem
            // 
            this.addEventToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addEventToolStripMenuItem.Image")));
            this.addEventToolStripMenuItem.Name = "addEventToolStripMenuItem";
            this.addEventToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addEventToolStripMenuItem.Text = "Add Event";
            this.addEventToolStripMenuItem.Click += new System.EventHandler(this.AddEventButton_Click);
            // 
            // viewEventsToolStripMenuItem
            // 
            this.viewEventsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("viewEventsToolStripMenuItem.Image")));
            this.viewEventsToolStripMenuItem.Name = "viewEventsToolStripMenuItem";
            this.viewEventsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.viewEventsToolStripMenuItem.Text = "View Events";
            this.viewEventsToolStripMenuItem.Click += new System.EventHandler(this.ViewEventsButton_Click);
            // 
            // toolStripDropDownButton3
            // 
            this.toolStripDropDownButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCommentsToolStripMenuItem,
            this.viewCommentsToolStripMenuItem});
            this.toolStripDropDownButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton3.Image")));
            this.toolStripDropDownButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton3.Margin = new System.Windows.Forms.Padding(0, 1, 10, 2);
            this.toolStripDropDownButton3.Name = "toolStripDropDownButton3";
            this.toolStripDropDownButton3.Size = new System.Drawing.Size(79, 19);
            this.toolStripDropDownButton3.Text = "Comments";
            // 
            // addCommentsToolStripMenuItem
            // 
            this.addCommentsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addCommentsToolStripMenuItem.Image")));
            this.addCommentsToolStripMenuItem.Name = "addCommentsToolStripMenuItem";
            this.addCommentsToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.addCommentsToolStripMenuItem.Text = "Add Comments";
            this.addCommentsToolStripMenuItem.Click += new System.EventHandler(this.AddCommentButton_Click);
            // 
            // viewCommentsToolStripMenuItem
            // 
            this.viewCommentsToolStripMenuItem.Image = global::Toxikon.ProtocolManager.Properties.Resources.view_16xMD;
            this.viewCommentsToolStripMenuItem.Name = "viewCommentsToolStripMenuItem";
            this.viewCommentsToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.viewCommentsToolStripMenuItem.Text = "View Comments";
            this.viewCommentsToolStripMenuItem.Click += new System.EventHandler(this.ViewCommentsButton_Click);
            // 
            // toolStripDropDownButton4
            // 
            this.toolStripDropDownButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createNewProtocolNumberToolStripMenuItem,
            this.reviseProtocolNumberToolStripMenuItem});
            this.toolStripDropDownButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton4.Image")));
            this.toolStripDropDownButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton4.Margin = new System.Windows.Forms.Padding(0, 1, 10, 2);
            this.toolStripDropDownButton4.Name = "toolStripDropDownButton4";
            this.toolStripDropDownButton4.Size = new System.Drawing.Size(112, 19);
            this.toolStripDropDownButton4.Text = "Protocol Number";
            // 
            // createNewProtocolNumberToolStripMenuItem
            // 
            this.createNewProtocolNumberToolStripMenuItem.Image = global::Toxikon.ProtocolManager.Properties.Resources.action_add_16xMD;
            this.createNewProtocolNumberToolStripMenuItem.Name = "createNewProtocolNumberToolStripMenuItem";
            this.createNewProtocolNumberToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.createNewProtocolNumberToolStripMenuItem.Text = "Assign Protocol Number";
            this.createNewProtocolNumberToolStripMenuItem.Click += new System.EventHandler(this.AddProtocolNumber_Click);
            // 
            // reviseProtocolNumberToolStripMenuItem
            // 
            this.reviseProtocolNumberToolStripMenuItem.Image = global::Toxikon.ProtocolManager.Properties.Resources.PencilAngled_16xMD_color;
            this.reviseProtocolNumberToolStripMenuItem.Name = "reviseProtocolNumberToolStripMenuItem";
            this.reviseProtocolNumberToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.reviseProtocolNumberToolStripMenuItem.Text = "Revise Protocol Number";
            this.reviseProtocolNumberToolStripMenuItem.Click += new System.EventHandler(this.RevisedProtocolButton_Click);
            // 
            // toolStripDropDownButton5
            // 
            this.toolStripDropDownButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton5.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createProtocolToolStripMenuItem,
            this.updateFilePathToolStripMenuItem,
            this.openFileToolStripMenuItem,
            this.assignDepartmentToolStripMenuItem,
            this.assignProjectNumberToolStripMenuItem});
            this.toolStripDropDownButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton5.Image")));
            this.toolStripDropDownButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton5.Margin = new System.Windows.Forms.Padding(0, 1, 10, 2);
            this.toolStripDropDownButton5.Name = "toolStripDropDownButton5";
            this.toolStripDropDownButton5.Size = new System.Drawing.Size(65, 19);
            this.toolStripDropDownButton5.Text = "Protocol";
            // 
            // createProtocolToolStripMenuItem
            // 
            this.createProtocolToolStripMenuItem.Image = global::Toxikon.ProtocolManager.Properties.Resources.action_create_16xMD;
            this.createProtocolToolStripMenuItem.Name = "createProtocolToolStripMenuItem";
            this.createProtocolToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.createProtocolToolStripMenuItem.Text = "Create Protocol";
            this.createProtocolToolStripMenuItem.Click += new System.EventHandler(this.CreateProtocolButton_Click);
            // 
            // updateFilePathToolStripMenuItem
            // 
            this.updateFilePathToolStripMenuItem.Image = global::Toxikon.ProtocolManager.Properties.Resources.PencilAngled_16xMD_color;
            this.updateFilePathToolStripMenuItem.Name = "updateFilePathToolStripMenuItem";
            this.updateFilePathToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.updateFilePathToolStripMenuItem.Text = "Update File Path";
            this.updateFilePathToolStripMenuItem.Click += new System.EventHandler(this.UpdateFilePathButton_Click);
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Image = global::Toxikon.ProtocolManager.Properties.Resources.Open_6296;
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.openFileToolStripMenuItem.Text = "Open File";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.OpenFileButton_Click);
            // 
            // assignDepartmentToolStripMenuItem
            // 
            this.assignDepartmentToolStripMenuItem.Image = global::Toxikon.ProtocolManager.Properties.Resources.class_16xMD;
            this.assignDepartmentToolStripMenuItem.Name = "assignDepartmentToolStripMenuItem";
            this.assignDepartmentToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.assignDepartmentToolStripMenuItem.Text = "Assign Department";
            this.assignDepartmentToolStripMenuItem.Click += new System.EventHandler(this.DepartmentButton_Click);
            // 
            // assignProjectNumberToolStripMenuItem
            // 
            this.assignProjectNumberToolStripMenuItem.Image = global::Toxikon.ProtocolManager.Properties.Resources.AddIndexer_5546;
            this.assignProjectNumberToolStripMenuItem.Name = "assignProjectNumberToolStripMenuItem";
            this.assignProjectNumberToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.assignProjectNumberToolStripMenuItem.Text = "Assign Project Number";
            this.assignProjectNumberToolStripMenuItem.Click += new System.EventHandler(this.UpdateProjectNumberButton_Click);
            // 
            // ProtocolRequestEditView2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.MainTableLayoutPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ProtocolRequestEditView2";
            this.Size = new System.Drawing.Size(1024, 600);
            this.MainTableLayoutPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView TitlesListView;
        private System.Windows.Forms.ColumnHeader TitleCol;
        private System.Windows.Forms.ColumnHeader StatusCol;
        private System.Windows.Forms.ColumnHeader StatusDate;
        private System.Windows.Forms.ColumnHeader UserNameCol;
        private System.Windows.Forms.ColumnHeader CommentsCol;
        private System.Windows.Forms.ColumnHeader ProtocolNumberCol;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ColumnHeader FileNameCol;
        private System.Windows.Forms.ColumnHeader PNCol;
        private System.Windows.Forms.ColumnHeader DepartmentCol;
        private System.Windows.Forms.TableLayoutPanel MainTableLayoutPanel;
        private System.Windows.Forms.Panel panel2;
        private RequestForms.RequestFormEdit RequestFormEditView;
        private System.Windows.Forms.ColumnHeader IDCol;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem addTitleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeTitleToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem addEventToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewEventsToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton3;
        private System.Windows.Forms.ToolStripMenuItem addCommentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewCommentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton4;
        private System.Windows.Forms.ToolStripMenuItem createNewProtocolNumberToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reviseProtocolNumberToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton5;
        private System.Windows.Forms.ToolStripMenuItem createProtocolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateFilePathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem assignDepartmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem assignProjectNumberToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton6;
        private System.Windows.Forms.ToolStripMenuItem saveChangesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeRequestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadReportToolStripMenuItem;
    }
}
