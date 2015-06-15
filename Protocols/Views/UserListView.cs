using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Protocols.Interfaces;
using Protocols.Controllers;
using Protocols.Models;

namespace Protocols.Views
{
    public partial class UserListView : UserControl, IUserListView
    {
        UserListController controller;

        public UserListView()
        {
            InitializeComponent();
        }

        public void SetController(UserListController controller)
        {
            this.controller = controller;
        }

        public void ClearView()
        {
            this.MainListView.Items.Clear();
        }

        public void AddItemToListView(User user)
        {
            ListViewItem item = this.MainListView.Items.Add(user.UserName);
            item.SubItems.Add(user.Department.DepartmentName);
            item.SubItems.Add(user.Role.RoleName);
            item.SubItems.Add(user.IsActive.ToString());
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
