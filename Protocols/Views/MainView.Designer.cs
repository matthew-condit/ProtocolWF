namespace Protocols.Views
{
    partial class MainView
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mENUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.pROTOCOLREQUESTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AdminMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AdminDepartmentsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AdminRolesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AdminUsersMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mENUToolStripMenuItem,
            this.pROTOCOLREQUESTToolStripMenuItem,
            this.AdminMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 10, 0, 10);
            this.menuStrip1.Size = new System.Drawing.Size(809, 41);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mENUToolStripMenuItem
            // 
            this.mENUToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.mENUToolStripMenuItem.Name = "mENUToolStripMenuItem";
            this.mENUToolStripMenuItem.Size = new System.Drawing.Size(95, 21);
            this.mENUToolStripMenuItem.Text = "DASHBOARD";
            // 
            // MainPanel
            // 
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 41);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(809, 771);
            this.MainPanel.TabIndex = 1;
            // 
            // pROTOCOLREQUESTToolStripMenuItem
            // 
            this.pROTOCOLREQUESTToolStripMenuItem.Name = "pROTOCOLREQUESTToolStripMenuItem";
            this.pROTOCOLREQUESTToolStripMenuItem.Size = new System.Drawing.Size(145, 21);
            this.pROTOCOLREQUESTToolStripMenuItem.Text = "PROTOCOL REQUEST";
            // 
            // AdminMenuItem
            // 
            this.AdminMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AdminDepartmentsMenuItem,
            this.AdminRolesMenuItem,
            this.AdminUsersMenuItem});
            this.AdminMenuItem.Name = "AdminMenuItem";
            this.AdminMenuItem.Size = new System.Drawing.Size(62, 21);
            this.AdminMenuItem.Text = "ADMIN";
            // 
            // AdminDepartmentsMenuItem
            // 
            this.AdminDepartmentsMenuItem.Name = "AdminDepartmentsMenuItem";
            this.AdminDepartmentsMenuItem.Size = new System.Drawing.Size(152, 22);
            this.AdminDepartmentsMenuItem.Text = "Departments";
            this.AdminDepartmentsMenuItem.Click += new System.EventHandler(this.AdminDepartmentsMenuItem_Click);
            // 
            // AdminRolesMenuItem
            // 
            this.AdminRolesMenuItem.Name = "AdminRolesMenuItem";
            this.AdminRolesMenuItem.Size = new System.Drawing.Size(152, 22);
            this.AdminRolesMenuItem.Text = "Roles";
            this.AdminRolesMenuItem.Click += new System.EventHandler(this.AdminRolesMenuItem_Click);
            // 
            // AdminUsersMenuItem
            // 
            this.AdminUsersMenuItem.Name = "AdminUsersMenuItem";
            this.AdminUsersMenuItem.Size = new System.Drawing.Size(152, 22);
            this.AdminUsersMenuItem.Text = "Users";
            this.AdminUsersMenuItem.Click += new System.EventHandler(this.AdminUsersMenuItem_Click);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 812);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(825, 850);
            this.MinimumSize = new System.Drawing.Size(825, 850);
            this.Name = "MainView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Protocols";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mENUToolStripMenuItem;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.ToolStripMenuItem pROTOCOLREQUESTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AdminMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AdminDepartmentsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AdminRolesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AdminUsersMenuItem;
    }
}

