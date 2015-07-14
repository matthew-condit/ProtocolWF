﻿namespace Toxikon.ProtocolManager.Views.Protocols
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
            this.EditTitleButton = new System.Windows.Forms.ToolStripButton();
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
            this.RequestForm = new Toxikon.ProtocolManager.Views.RequestForms.RequestFormEdit();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.SaveChangesButton = new System.Windows.Forms.ToolStripButton();
            this.CloseRequestButton = new System.Windows.Forms.ToolStripButton();
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
            this.AddTitleButton,
            this.EditTitleButton,
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
            this.toolStrip1.Size = new System.Drawing.Size(999, 38);
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
            // EditTitleButton
            // 
            this.EditTitleButton.Image = global::Toxikon.ProtocolManager.Properties.Resources.PencilAngled_16xLG_color;
            this.EditTitleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditTitleButton.Name = "EditTitleButton";
            this.EditTitleButton.Size = new System.Drawing.Size(57, 35);
            this.EditTitleButton.Text = "Edit Title";
            this.EditTitleButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.EditTitleButton.ToolTipText = "Edit selected title";
            this.EditTitleButton.Click += new System.EventHandler(this.EditTitleButton_Click);
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
            this.TitlesListView.Size = new System.Drawing.Size(993, 258);
            this.TitlesListView.TabIndex = 45;
            this.TitlesListView.UseCompatibleStateImageBehavior = false;
            this.TitlesListView.View = System.Windows.Forms.View.Details;
            this.TitlesListView.Leave += new System.EventHandler(this.TitlesListView_Leave);
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
            this.MainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTableLayoutPanel.Location = new System.Drawing.Point(0, 38);
            this.MainTableLayoutPanel.Name = "MainTableLayoutPanel";
            this.MainTableLayoutPanel.RowCount = 2;
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.MainTableLayoutPanel.Size = new System.Drawing.Size(999, 662);
            this.MainTableLayoutPanel.TabIndex = 46;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.RequestForm);
            this.panel2.Controls.Add(this.toolStrip2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 267);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(993, 392);
            this.panel2.TabIndex = 46;
            // 
            // RequestForm
            // 
            this.RequestForm.Address = "Address";
            this.RequestForm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RequestForm.AssignedTo = "";
            this.RequestForm.BackColor = System.Drawing.Color.White;
            this.RequestForm.BillTo = "";
            this.RequestForm.City = "City";
            this.RequestForm.Comments = "Comments";
            this.RequestForm.Compliance = "";
            this.RequestForm.ContactName = "Contact";
            this.RequestForm.Cost = "";
            this.RequestForm.DueDate = new System.DateTime(2015, 7, 6, 17, 11, 19, 859);
            this.RequestForm.Email = "Email";
            this.RequestForm.FaxNumber = "Fax";
            this.RequestForm.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RequestForm.Guidelines = "";
            this.RequestForm.Location = new System.Drawing.Point(0, 42);
            this.RequestForm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RequestForm.Name = "RequestForm";
            this.RequestForm.PhoneNumber = "Phone Number";
            this.RequestForm.PONumber = "PO";
            this.RequestForm.ProtocolType = "";
            this.RequestForm.RequestedBy = "Requested By";
            this.RequestForm.RequestedDate = "Requested Date";
            this.RequestForm.SendVia = "";
            this.RequestForm.Size = new System.Drawing.Size(993, 346);
            this.RequestForm.SponsorName = "Sponsor";
            this.RequestForm.State = "State";
            this.RequestForm.TabIndex = 2;
            this.RequestForm.ZipCode = "Zip Code";
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
            this.toolStrip2.Size = new System.Drawing.Size(993, 38);
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
            // ProtocolRequestEditView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MainTableLayoutPanel);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ProtocolRequestEditView";
            this.Size = new System.Drawing.Size(999, 700);
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
        private System.Windows.Forms.ToolStripButton AddCommentButton;
        private System.Windows.Forms.ToolStripButton AddEventButton;
        private System.Windows.Forms.ToolStripButton AddTitleButton;
        private System.Windows.Forms.ToolStripButton EditTitleButton;
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
        private RequestForms.RequestFormEdit RequestForm;
    }
}
