namespace Protocols.Views
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.SearchTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.SearchButton = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.SponsorListView = new System.Windows.Forms.ListView();
            this.SponsorNameCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ContactNameCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EmailCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProtocolRequestDetailView = new Protocols.Views.ProtocolRequestDetailView();
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.SearchTextBox,
            this.SearchButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(103, 22);
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
            this.SearchButton.Size = new System.Drawing.Size(67, 22);
            this.SearchButton.Text = "Search";
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.SponsorListView, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ProtocolRequestDetailView, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 735);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // SponsorListView
            // 
            this.SponsorListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SponsorNameCol,
            this.ContactNameCol,
            this.EmailCol});
            this.SponsorListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SponsorListView.FullRowSelect = true;
            this.SponsorListView.GridLines = true;
            this.SponsorListView.Location = new System.Drawing.Point(3, 3);
            this.SponsorListView.MultiSelect = false;
            this.SponsorListView.Name = "SponsorListView";
            this.SponsorListView.Size = new System.Drawing.Size(794, 141);
            this.SponsorListView.TabIndex = 0;
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
            // ProtocolRequestDetailView
            // 
            this.ProtocolRequestDetailView.Address = "Address";
            this.ProtocolRequestDetailView.BillTo = null;
            this.ProtocolRequestDetailView.City = "City";
            this.ProtocolRequestDetailView.Comments = null;
            this.ProtocolRequestDetailView.Compliance = null;
            this.ProtocolRequestDetailView.ContactName = "Contact";
            this.ProtocolRequestDetailView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProtocolRequestDetailView.Email = "Email";
            this.ProtocolRequestDetailView.FaxNumber = "Fax";
            this.ProtocolRequestDetailView.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProtocolRequestDetailView.Guidelines = null;
            this.ProtocolRequestDetailView.Location = new System.Drawing.Point(3, 151);
            this.ProtocolRequestDetailView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ProtocolRequestDetailView.Name = "ProtocolRequestDetailView";
            this.ProtocolRequestDetailView.PhoneNumber = "Phone";
            this.ProtocolRequestDetailView.PONumber = "PO";
            this.ProtocolRequestDetailView.ProtocolType = null;
            this.ProtocolRequestDetailView.RequestedBy = "Requested By";
            this.ProtocolRequestDetailView.RequestedDate = "Requested Date";
            this.ProtocolRequestDetailView.SendVia = null;
            this.ProtocolRequestDetailView.Size = new System.Drawing.Size(794, 580);
            this.ProtocolRequestDetailView.SponsorName = "Sponsor";
            this.ProtocolRequestDetailView.State = "State";
            this.ProtocolRequestDetailView.TabIndex = 1;
            this.ProtocolRequestDetailView.ZipCode = "Zip Code";
            // 
            // ProtocolRequestAddView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ProtocolRequestAddView";
            this.Size = new System.Drawing.Size(800, 760);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox SearchTextBox;
        private System.Windows.Forms.ToolStripButton SearchButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListView SponsorListView;
        private System.Windows.Forms.ColumnHeader SponsorNameCol;
        private System.Windows.Forms.ColumnHeader ContactNameCol;
        private ProtocolRequestDetailView ProtocolRequestDetailView;
        private System.Windows.Forms.ColumnHeader EmailCol;
    }
}
