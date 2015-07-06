namespace Toxikon.ProtocolManager.Views
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
            this.HomeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ProtocolRequestMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HistoryMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AdminMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AdminDepartmentsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AdminRolesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AdminUsersMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ListNamesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ListItemsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AdminProtocolEventsButton = new System.Windows.Forms.ToolStripMenuItem();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HomeMenuItem,
            this.ProtocolRequestMenuItem,
            this.HistoryMenuItem,
            this.AdminMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 10, 0, 10);
            this.menuStrip1.Size = new System.Drawing.Size(1184, 41);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // HomeMenuItem
            // 
            this.HomeMenuItem.ForeColor = System.Drawing.Color.White;
            this.HomeMenuItem.Name = "HomeMenuItem";
            this.HomeMenuItem.Size = new System.Drawing.Size(58, 21);
            this.HomeMenuItem.Text = "HOME";
            this.HomeMenuItem.Click += new System.EventHandler(this.DashboardMenuItem_Click);
            // 
            // ProtocolRequestMenuItem
            // 
            this.ProtocolRequestMenuItem.ForeColor = System.Drawing.Color.White;
            this.ProtocolRequestMenuItem.Name = "ProtocolRequestMenuItem";
            this.ProtocolRequestMenuItem.Size = new System.Drawing.Size(145, 21);
            this.ProtocolRequestMenuItem.Text = "PROTOCOL REQUEST";
            this.ProtocolRequestMenuItem.Click += new System.EventHandler(this.ProtocolRequestMenuItem_Click);
            // 
            // HistoryMenuItem
            // 
            this.HistoryMenuItem.ForeColor = System.Drawing.Color.White;
            this.HistoryMenuItem.Name = "HistoryMenuItem";
            this.HistoryMenuItem.Size = new System.Drawing.Size(71, 21);
            this.HistoryMenuItem.Text = "HISTORY";
            this.HistoryMenuItem.Click += new System.EventHandler(this.HistoryMenuItem_Click);
            // 
            // AdminMenuItem
            // 
            this.AdminMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AdminDepartmentsMenuItem,
            this.AdminRolesMenuItem,
            this.AdminUsersMenuItem,
            this.ListNamesMenuItem,
            this.ListItemsMenuItem,
            this.AdminProtocolEventsButton});
            this.AdminMenuItem.ForeColor = System.Drawing.Color.White;
            this.AdminMenuItem.Name = "AdminMenuItem";
            this.AdminMenuItem.Size = new System.Drawing.Size(62, 21);
            this.AdminMenuItem.Text = "ADMIN";
            // 
            // AdminDepartmentsMenuItem
            // 
            this.AdminDepartmentsMenuItem.Name = "AdminDepartmentsMenuItem";
            this.AdminDepartmentsMenuItem.Size = new System.Drawing.Size(166, 22);
            this.AdminDepartmentsMenuItem.Text = "Departments";
            this.AdminDepartmentsMenuItem.Click += new System.EventHandler(this.AdminDepartmentsMenuItem_Click);
            // 
            // AdminRolesMenuItem
            // 
            this.AdminRolesMenuItem.Name = "AdminRolesMenuItem";
            this.AdminRolesMenuItem.Size = new System.Drawing.Size(166, 22);
            this.AdminRolesMenuItem.Text = "Roles";
            this.AdminRolesMenuItem.Click += new System.EventHandler(this.AdminRolesMenuItem_Click);
            // 
            // AdminUsersMenuItem
            // 
            this.AdminUsersMenuItem.Name = "AdminUsersMenuItem";
            this.AdminUsersMenuItem.Size = new System.Drawing.Size(166, 22);
            this.AdminUsersMenuItem.Text = "Users";
            this.AdminUsersMenuItem.Click += new System.EventHandler(this.AdminUsersMenuItem_Click);
            // 
            // ListNamesMenuItem
            // 
            this.ListNamesMenuItem.Name = "ListNamesMenuItem";
            this.ListNamesMenuItem.Size = new System.Drawing.Size(166, 22);
            this.ListNamesMenuItem.Text = "List Names";
            this.ListNamesMenuItem.Click += new System.EventHandler(this.ListNamesMenuItem_Click);
            // 
            // ListItemsMenuItem
            // 
            this.ListItemsMenuItem.Name = "ListItemsMenuItem";
            this.ListItemsMenuItem.Size = new System.Drawing.Size(166, 22);
            this.ListItemsMenuItem.Text = "List Items";
            this.ListItemsMenuItem.Click += new System.EventHandler(this.ListItemsMenuItem_Click);
            // 
            // AdminProtocolEventsButton
            // 
            this.AdminProtocolEventsButton.Name = "AdminProtocolEventsButton";
            this.AdminProtocolEventsButton.Size = new System.Drawing.Size(166, 22);
            this.AdminProtocolEventsButton.Text = "Protocol Events";
            this.AdminProtocolEventsButton.Click += new System.EventHandler(this.AdminProtocolEventsButton_Click);
            // 
            // MainPanel
            // 
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 41);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1184, 771);
            this.MainPanel.TabIndex = 1;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 812);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1150, 850);
            this.Name = "MainView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TPM - Toxikon Protocol Manager";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem HomeMenuItem;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.ToolStripMenuItem ProtocolRequestMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AdminMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AdminDepartmentsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AdminRolesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AdminUsersMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ListItemsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AdminProtocolEventsButton;
        private System.Windows.Forms.ToolStripMenuItem HistoryMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ListNamesMenuItem;
    }
}

