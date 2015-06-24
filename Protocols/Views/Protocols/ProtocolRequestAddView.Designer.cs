using Toxikon.ProtocolManager.Models;
namespace Toxikon.ProtocolManager.Views.Protocols
{
    partial class ProtocolRequestAddView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProtocolRequestAddView));
            this.MainPanel = new System.Windows.Forms.Panel();
            this.MainFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.SearchTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.SearchButton = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.SponsorListView = new System.Windows.Forms.ListView();
            this.SponsorNameCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ContactNameCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EmailCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.SubmitButton = new System.Windows.Forms.ToolStripButton();
            this.RequestForm = new Toxikon.ProtocolManager.Views.RequestForms.RequestFormAdd();
            this.TitleDataGridView = new System.Windows.Forms.DataGridView();
            this.TitleCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MainPanel.SuspendLayout();
            this.MainFlowLayoutPanel.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TitleDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.MainFlowLayoutPanel);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 45);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(800, 715);
            this.MainPanel.TabIndex = 2;
            // 
            // MainFlowLayoutPanel
            // 
            this.MainFlowLayoutPanel.Controls.Add(this.SponsorListView);
            this.MainFlowLayoutPanel.Controls.Add(this.toolStrip2);
            this.MainFlowLayoutPanel.Controls.Add(this.RequestForm);
            this.MainFlowLayoutPanel.Controls.Add(this.TitleDataGridView);
            this.MainFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.MainFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.MainFlowLayoutPanel.Name = "MainFlowLayoutPanel";
            this.MainFlowLayoutPanel.Size = new System.Drawing.Size(800, 715);
            this.MainFlowLayoutPanel.TabIndex = 0;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(91, 22);
            this.toolStripLabel1.Text = "Sponsor Name: ";
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.SearchTextBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(200, 25);
            // 
            // SearchButton
            // 
            this.SearchButton.Image = ((System.Drawing.Image)(resources.GetObject("SearchButton.Image")));
            this.SearchButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(62, 22);
            this.SearchButton.Text = "Search";
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.White;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.SearchTextBox,
            this.SearchButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 10, 1, 10);
            this.toolStrip1.Size = new System.Drawing.Size(800, 45);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // SponsorListView
            // 
            this.SponsorListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SponsorNameCol,
            this.ContactNameCol,
            this.EmailCol});
            this.SponsorListView.FullRowSelect = true;
            this.SponsorListView.GridLines = true;
            this.SponsorListView.Location = new System.Drawing.Point(3, 3);
            this.SponsorListView.MultiSelect = false;
            this.SponsorListView.Name = "SponsorListView";
            this.SponsorListView.Size = new System.Drawing.Size(792, 135);
            this.SponsorListView.TabIndex = 1;
            this.SponsorListView.UseCompatibleStateImageBehavior = false;
            this.SponsorListView.View = System.Windows.Forms.View.Details;
            this.SponsorListView.SelectedIndexChanged += new System.EventHandler(this.SponsorListView_SelectedIndexChanged);
            // 
            // SponsorNameCol
            // 
            this.SponsorNameCol.Text = "Sponsor Name";
            this.SponsorNameCol.Width = 348;
            // 
            // ContactNameCol
            // 
            this.ContactNameCol.Text = "Contact Name";
            this.ContactNameCol.Width = 187;
            // 
            // EmailCol
            // 
            this.EmailCol.Text = "Email";
            this.EmailCol.Width = 226;
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.White;
            this.toolStrip2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SubmitButton});
            this.toolStrip2.Location = new System.Drawing.Point(0, 141);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Padding = new System.Windows.Forms.Padding(10, 0, 1, 0);
            this.toolStrip2.Size = new System.Drawing.Size(800, 38);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // SubmitButton
            // 
            this.SubmitButton.Image = global::Toxikon.ProtocolManager.Properties.Resources.StatusAnnotations_Complete_and_ok_16xLG_color;
            this.SubmitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(49, 35);
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
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
            this.RequestForm.Comments = "";
            this.RequestForm.Compliance = "";
            this.RequestForm.ContactName = "Contact";
            this.RequestForm.DueDate = new System.DateTime(2015, 6, 24, 16, 22, 58, 736);
            this.RequestForm.Email = "Email";
            this.RequestForm.FaxNumber = "Fax";
            this.RequestForm.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RequestForm.Guidelines = "";
            this.RequestForm.Location = new System.Drawing.Point(3, 183);
            this.RequestForm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RequestForm.Name = "RequestForm";
            this.RequestForm.PhoneNumber = "Phone Number";
            this.RequestForm.PONumber = "PO";
            this.RequestForm.ProtocolType = "";
            this.RequestForm.RequestedBy = "Requested By";
            this.RequestForm.RequestedDate = "Requested Date";
            this.RequestForm.SendVia = "";
            this.RequestForm.Size = new System.Drawing.Size(794, 325);
            this.RequestForm.SponsorName = "Sponsor";
            this.RequestForm.State = "State";
            this.RequestForm.TabIndex = 3;
            this.RequestForm.ZipCode = "Zip Code";
            // 
            // TitleDataGridView
            // 
            this.TitleDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.TitleDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.TitleDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.TitleDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TitleDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TitleDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TitleCol});
            this.TitleDataGridView.Location = new System.Drawing.Point(3, 515);
            this.TitleDataGridView.MultiSelect = false;
            this.TitleDataGridView.Name = "TitleDataGridView";
            this.TitleDataGridView.Size = new System.Drawing.Size(794, 197);
            this.TitleDataGridView.TabIndex = 42;
            // 
            // TitleCol
            // 
            this.TitleCol.HeaderText = "Titles";
            this.TitleCol.Name = "TitleCol";
            // 
            // ProtocolRequestAddView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ProtocolRequestAddView";
            this.Size = new System.Drawing.Size(800, 760);
            this.MainPanel.ResumeLayout(false);
            this.MainFlowLayoutPanel.ResumeLayout(false);
            this.MainFlowLayoutPanel.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TitleDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.FlowLayoutPanel MainFlowLayoutPanel;
        private System.Windows.Forms.ListView SponsorListView;
        private System.Windows.Forms.ColumnHeader SponsorNameCol;
        private System.Windows.Forms.ColumnHeader ContactNameCol;
        private System.Windows.Forms.ColumnHeader EmailCol;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton SubmitButton;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox SearchTextBox;
        private System.Windows.Forms.ToolStripButton SearchButton;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private RequestForms.RequestFormAdd RequestForm;
        private System.Windows.Forms.DataGridView TitleDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn TitleCol;
    }
}
