namespace Toxikon.ProtocolManager.Views.Admin
{
    partial class DepartmentDirectorsView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DepartmentDirectorsView));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.DepartmentsComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.DirectorsComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.AddButton = new System.Windows.Forms.ToolStripButton();
            this.ItemsListView = new System.Windows.Forms.ListView();
            this.IDCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DepartmentIDCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DepartmentNameCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UserNameCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FullNameCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.White;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.DepartmentsComboBox,
            this.toolStripLabel2,
            this.DirectorsComboBox,
            this.AddButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(10, 0, 1, 0);
            this.toolStrip1.Size = new System.Drawing.Size(750, 38);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(78, 35);
            this.toolStripLabel1.Text = "Departments:";
            // 
            // DepartmentsComboBox
            // 
            this.DepartmentsComboBox.BackColor = System.Drawing.SystemColors.Info;
            this.DepartmentsComboBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DepartmentsComboBox.Name = "DepartmentsComboBox";
            this.DepartmentsComboBox.Size = new System.Drawing.Size(250, 38);
            this.DepartmentsComboBox.SelectedIndexChanged += new System.EventHandler(this.DepartmentsComboBox_SelectedIndexChanged);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(57, 35);
            this.toolStripLabel2.Text = "Directors:";
            // 
            // DirectorsComboBox
            // 
            this.DirectorsComboBox.BackColor = System.Drawing.SystemColors.Info;
            this.DirectorsComboBox.Name = "DirectorsComboBox";
            this.DirectorsComboBox.Size = new System.Drawing.Size(200, 38);
            this.DirectorsComboBox.SelectedIndexChanged += new System.EventHandler(this.DirectorsComboBox_SelectedIndexChanged);
            // 
            // AddButton
            // 
            this.AddButton.Image = ((System.Drawing.Image)(resources.GetObject("AddButton.Image")));
            this.AddButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(33, 35);
            this.AddButton.Text = "Add";
            this.AddButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // ItemsListView
            // 
            this.ItemsListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ItemsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IDCol,
            this.DepartmentIDCol,
            this.DepartmentNameCol,
            this.UserNameCol,
            this.FullNameCol});
            this.ItemsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ItemsListView.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemsListView.FullRowSelect = true;
            this.ItemsListView.GridLines = true;
            this.ItemsListView.Location = new System.Drawing.Point(0, 38);
            this.ItemsListView.MultiSelect = false;
            this.ItemsListView.Name = "ItemsListView";
            this.ItemsListView.Size = new System.Drawing.Size(750, 112);
            this.ItemsListView.TabIndex = 2;
            this.ItemsListView.UseCompatibleStateImageBehavior = false;
            this.ItemsListView.View = System.Windows.Forms.View.Details;
            // 
            // IDCol
            // 
            this.IDCol.Text = "ID";
            this.IDCol.Width = 53;
            // 
            // DepartmentIDCol
            // 
            this.DepartmentIDCol.Text = "Department ID";
            this.DepartmentIDCol.Width = 91;
            // 
            // DepartmentNameCol
            // 
            this.DepartmentNameCol.Text = "Department Name";
            this.DepartmentNameCol.Width = 216;
            // 
            // UserNameCol
            // 
            this.UserNameCol.Text = "UserName";
            this.UserNameCol.Width = 110;
            // 
            // FullNameCol
            // 
            this.FullNameCol.Text = "Full Name";
            this.FullNameCol.Width = 188;
            // 
            // DepartmentDirectorsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ItemsListView);
            this.Controls.Add(this.toolStrip1);
            this.Name = "DepartmentDirectorsView";
            this.Size = new System.Drawing.Size(750, 150);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox DepartmentsComboBox;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton AddButton;
        private System.Windows.Forms.ToolStripComboBox DirectorsComboBox;
        private System.Windows.Forms.ListView ItemsListView;
        private System.Windows.Forms.ColumnHeader IDCol;
        private System.Windows.Forms.ColumnHeader DepartmentIDCol;
        private System.Windows.Forms.ColumnHeader DepartmentNameCol;
        private System.Windows.Forms.ColumnHeader UserNameCol;
        private System.Windows.Forms.ColumnHeader FullNameCol;
    }
}
