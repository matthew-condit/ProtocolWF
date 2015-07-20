namespace Toxikon.ProtocolManager.Views.Admin
{
    partial class ListItemsView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListItemsView));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.ListNameComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.ItemNameTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.AddButton = new System.Windows.Forms.ToolStripButton();
            this.UpdateButton = new System.Windows.Forms.ToolStripButton();
            this.ItemsListView = new System.Windows.Forms.ListView();
            this.ItemNameCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ActiveCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.White;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.ListNameComboBox,
            this.toolStripLabel2,
            this.ItemNameTextBox,
            this.AddButton,
            this.UpdateButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(10, 0, 1, 0);
            this.toolStrip1.Size = new System.Drawing.Size(1024, 38);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(36, 35);
            this.toolStripLabel1.Text = "Lists: ";
            // 
            // ListNameComboBox
            // 
            this.ListNameComboBox.BackColor = System.Drawing.SystemColors.Info;
            this.ListNameComboBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListNameComboBox.Name = "ListNameComboBox";
            this.ListNameComboBox.Size = new System.Drawing.Size(250, 38);
            this.ListNameComboBox.SelectedIndexChanged += new System.EventHandler(this.ListNameComboBox_SelectedIndexChanged);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(99, 35);
            this.toolStripLabel2.Text = "New Item Name: ";
            // 
            // ItemNameTextBox
            // 
            this.ItemNameTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.ItemNameTextBox.Name = "ItemNameTextBox";
            this.ItemNameTextBox.Size = new System.Drawing.Size(200, 38);
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
            // UpdateButton
            // 
            this.UpdateButton.Image = global::Toxikon.ProtocolManager.Properties.Resources.PencilAngled_16xLG_color;
            this.UpdateButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(49, 35);
            this.UpdateButton.Text = "Update";
            this.UpdateButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // ItemsListView
            // 
            this.ItemsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemsListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ItemsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ItemNameCol,
            this.ActiveCol});
            this.ItemsListView.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemsListView.FullRowSelect = true;
            this.ItemsListView.GridLines = true;
            this.ItemsListView.Location = new System.Drawing.Point(0, 44);
            this.ItemsListView.MultiSelect = false;
            this.ItemsListView.Name = "ItemsListView";
            this.ItemsListView.Size = new System.Drawing.Size(1024, 193);
            this.ItemsListView.TabIndex = 1;
            this.ItemsListView.UseCompatibleStateImageBehavior = false;
            this.ItemsListView.View = System.Windows.Forms.View.Details;
            this.ItemsListView.SelectedIndexChanged += new System.EventHandler(this.ItemsListView_SelectedIndexChanged);
            // 
            // ItemNameCol
            // 
            this.ItemNameCol.Text = "Item Name";
            this.ItemNameCol.Width = 448;
            // 
            // ActiveCol
            // 
            this.ActiveCol.Text = "Active";
            this.ActiveCol.Width = 94;
            // 
            // ListItemsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ItemsListView);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ListItemsView";
            this.Size = new System.Drawing.Size(1024, 240);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox ListNameComboBox;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox ItemNameTextBox;
        private System.Windows.Forms.ToolStripButton AddButton;
        private System.Windows.Forms.ListView ItemsListView;
        private System.Windows.Forms.ColumnHeader ItemNameCol;
        private System.Windows.Forms.ToolStripButton UpdateButton;
        private System.Windows.Forms.ColumnHeader ActiveCol;
    }
}
