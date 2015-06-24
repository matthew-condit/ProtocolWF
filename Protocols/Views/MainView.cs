using Toxikon.ProtocolManager.Controllers;
using Toxikon.ProtocolManager.Interfaces;
using Toxikon.ProtocolManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Toxikon.ProtocolManager.Views
{
    public partial class MainView : Form, IMainView
    {
        MainViewController controller;
        public delegate void LoadProtocolRequestEditView(ProtocolRequest request);
        public LoadProtocolRequestEditView LoadProtocolRequestViewDelegate;

        public MainView()
        {
            InitializeComponent();
            this.menuStrip1.Renderer = new MyRenderer();
        }

        private class MyRenderer : ToolStripProfessionalRenderer
        {
            public MyRenderer() : base(new MyColors()) { }
        }

        private class MyColors : ProfessionalColorTable
        {
            public override Color MenuItemSelected
            {
                get { return Color.Gray; }
            }
            public override Color MenuItemSelectedGradientBegin
            {
                get { return Color.DarkGray; }
            }
            public override Color MenuItemSelectedGradientEnd
            {
                get { return Color.Gray; }
            }
            public override Color MenuItemBorder
            {
                get { return Color.Gray; }
            }
            public override Color MenuItemPressedGradientBegin
            {
                get { return Color.DarkGray; }
            }
            public override Color MenuItemPressedGradientEnd
            {
                get { return Color.Gray; }
            }
        }

        public void SetMenuStripItemVisibleByUserRole(int roleID)
        {
            switch(roleID)
            {
                case 1:
                    this.HomeMenuItem.Visible = true;
                    this.ProtocolRequestMenuItem.Visible = true;
                    this.AdminMenuItem.Visible = true;
                    break;
                case 2:
                    this.HomeMenuItem.Visible = true;
                    this.ProtocolRequestMenuItem.Visible = true;
                    this.AdminMenuItem.Visible = false;
                    break;
                case 3:
                    this.HomeMenuItem.Visible = true;
                    this.ProtocolRequestMenuItem.Visible = false;
                    this.AdminMenuItem.Visible = false;
                    break;
                default:
                    this.HomeMenuItem.Visible = true;
                    this.ProtocolRequestMenuItem.Visible = false;
                    this.AdminMenuItem.Visible = false;
                    break;
            }
        }

        public void SetController(MainViewController controller)
        {
            this.controller = controller;
            this.LoadProtocolRequestViewDelegate = new LoadProtocolRequestEditView(
                this.controller.LoadProtocolRequestEditView);
        }

        public void AddControlToMainPanel(Control control)
        {
            this.MainPanel.Controls.Clear();
            control.Dock = DockStyle.Fill;
            this.MainPanel.Controls.Add(control);
        }

        private void AdminDepartmentsMenuItem_Click(object sender, EventArgs e)
        {
            this.controller.LoadDepartmentListView();
        }

        private void AdminRolesMenuItem_Click(object sender, EventArgs e)
        {
            this.controller.LoadRoleListView();
        }

        private void AdminUsersMenuItem_Click(object sender, EventArgs e)
        {
            this.controller.LoadUserListView();
        }

        private void ListItemsMenuItem_Click(object sender, EventArgs e)
        {
            this.controller.LoadListItemsView();
        }

        private void DashboardMenuItem_Click(object sender, EventArgs e)
        {
            this.controller.LoadDashboardView();
        }

        private void ProtocolRequestMenuItem_Click(object sender, EventArgs e)
        {
            this.controller.LoadProtocolRequestAddView();
        }

        private void AdminProtocolEventsButton_Click(object sender, EventArgs e)
        {
            this.controller.LoadProtocolEventsView();
        }
    }
}
