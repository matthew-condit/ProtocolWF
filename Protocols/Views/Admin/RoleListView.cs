using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.ProtocolManager.Interfaces.Admin;
using Toxikon.ProtocolManager.Controllers.Admin;
using Toxikon.ProtocolManager.Models;

namespace Toxikon.ProtocolManager.Views.Admin
{
    public partial class RoleListView : UserControl, IRoleListView
    {
        RoleListController controller;

        public RoleListView()
        {
            InitializeComponent();
        }

        public void SetController(RoleListController controller)
        {
            this.controller = controller;
        }

        public void AddItemToListView(Role role)
        {
            ListViewItem item = this.MainListView.Items.Add(role.RoleID.ToString());
            item.SubItems.Add(role.RoleName);
            item.SubItems.Add(role.IsActive.ToString());
        }

        public void ClearView()
        {
            this.MainListView.Items.Clear();
        }

        public Control ParentControl
        {
            get { return this.Parent; }
        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            this.controller.NewButtonClicked();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            this.controller.UpdateButtonClicked();
        }

        private void MainListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.MainListView.SelectedIndices.Count > 0)
            {
                this.controller.ListViewSelectedIndexChanged(this.MainListView.SelectedIndices[0]);
            }
        }
    }
}
