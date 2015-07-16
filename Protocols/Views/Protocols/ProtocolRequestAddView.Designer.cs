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
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.SearchTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.SearchButton = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.SubmitButton = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.RequestForm = new Toxikon.ProtocolManager.Views.RequestForms.RequestFormAdd();
            this.TitleDataGridView = new System.Windows.Forms.DataGridView();
            this.IDCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TitleCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.FindTemplateButton = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TitleDataGridView)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(91, 22);
            this.toolStripLabel1.Text = "Sponsor Name: ";
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.BackColor = System.Drawing.Color.LemonChiffon;
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
            this.SearchButton,
            this.SubmitButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 4, 1, 4);
            this.toolStrip1.Size = new System.Drawing.Size(1024, 33);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // SubmitButton
            // 
            this.SubmitButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.SubmitButton.Image = global::Toxikon.ProtocolManager.Properties.Resources.StatusAnnotations_Complete_and_ok_16xLG_color;
            this.SubmitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(65, 22);
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.RequestForm, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.TitleDataGridView, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 33);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 345F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1024, 567);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // RequestForm
            // 
            this.RequestForm.Address = "Address";
            this.RequestForm.AssignedTo = "";
            this.RequestForm.BackColor = System.Drawing.Color.White;
            this.RequestForm.BillTo = "";
            this.RequestForm.City = "City";
            this.RequestForm.Comments = "";
            this.RequestForm.Compliance = "";
            this.RequestForm.ContactName = "Contact";
            this.RequestForm.Cost = "";
            this.RequestForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RequestForm.DueDate = new System.DateTime(2015, 7, 14, 15, 15, 39, 261);
            this.RequestForm.Email = "Email";
            this.RequestForm.FaxNumber = "Fax";
            this.RequestForm.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.RequestForm.Guidelines = "";
            this.RequestForm.Location = new System.Drawing.Point(3, 4);
            this.RequestForm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RequestForm.Name = "RequestForm";
            this.RequestForm.PhoneNumber = "Phone Number";
            this.RequestForm.PONumber = "";
            this.RequestForm.ProtocolType = "";
            this.RequestForm.RequestedBy = "Requested By";
            this.RequestForm.RequestedDate = "Requested Date";
            this.RequestForm.SendVia = "";
            this.RequestForm.Size = new System.Drawing.Size(1018, 337);
            this.RequestForm.SponsorName = "Sponsor";
            this.RequestForm.State = "State";
            this.RequestForm.TabIndex = 49;
            this.RequestForm.ZipCode = "Zip Code";
            // 
            // TitleDataGridView
            // 
            this.TitleDataGridView.AllowUserToAddRows = false;
            this.TitleDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.TitleDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.TitleDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TitleDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TitleDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDCol,
            this.TitleCol});
            this.TitleDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TitleDataGridView.Location = new System.Drawing.Point(3, 376);
            this.TitleDataGridView.MultiSelect = false;
            this.TitleDataGridView.Name = "TitleDataGridView";
            this.TitleDataGridView.ReadOnly = true;
            this.TitleDataGridView.Size = new System.Drawing.Size(1018, 188);
            this.TitleDataGridView.TabIndex = 48;
            this.TitleDataGridView.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.TitleDataGridView_RowsRemoved);
            // 
            // IDCol
            // 
            this.IDCol.FillWeight = 20.30457F;
            this.IDCol.HeaderText = "ID";
            this.IDCol.Name = "IDCol";
            this.IDCol.ReadOnly = true;
            // 
            // TitleCol
            // 
            this.TitleCol.FillWeight = 179.6954F;
            this.TitleCol.HeaderText = "Titles";
            this.TitleCol.Name = "TitleCol";
            this.TitleCol.ReadOnly = true;
            // 
            // toolStrip2
            // 
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FindTemplateButton});
            this.toolStrip2.Location = new System.Drawing.Point(0, 345);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1024, 25);
            this.toolStrip2.TabIndex = 50;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // FindTemplateButton
            // 
            this.FindTemplateButton.Image = global::Toxikon.ProtocolManager.Properties.Resources.ZoomNeutral_16xlG;
            this.FindTemplateButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FindTemplateButton.Name = "FindTemplateButton";
            this.FindTemplateButton.Size = new System.Drawing.Size(103, 22);
            this.FindTemplateButton.Text = "Find Template";
            this.FindTemplateButton.Click += new System.EventHandler(this.FindTemplateButton_Click);
            // 
            // ProtocolRequestAddView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(1024, 600);
            this.Name = "ProtocolRequestAddView";
            this.Size = new System.Drawing.Size(1024, 600);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TitleDataGridView)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox SearchTextBox;
        private System.Windows.Forms.ToolStripButton SearchButton;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView TitleDataGridView;
        private RequestForms.RequestFormAdd RequestForm;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton FindTemplateButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn TitleCol;
        private System.Windows.Forms.ToolStripButton SubmitButton;
    }
}
