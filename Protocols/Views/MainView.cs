using Protocols.Controllers;
using Protocols.Interfaces;
using Protocols.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Protocols.Views
{
    public partial class MainView : Form, IMainView
    {
        MainViewController controller;
        public delegate void LoadProtocolRequestEditView(Sponsor sponsor);
        public LoadProtocolRequestEditView LoadProtocolRequestViewDelegate;

        public MainView()
        {
            InitializeComponent();
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
    }
}
