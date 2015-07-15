using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.ProtocolManager.Interfaces.Templates;
using Toxikon.ProtocolManager.Controllers;
using System.Collections;
using Toxikon.ProtocolManager.Models;
using Toxikon.ProtocolManager.Controllers.Templates;

namespace Toxikon.ProtocolManager.Views.Templates
{
    public partial class UCToolStripListView1 : UserControl, IUCToolStripListView1
    {
        UCToolStripListView1Controller controller;

        public UCToolStripListView1()
        {
            InitializeComponent();
        }

        public void SetController(UCToolStripListView1Controller controller)
        {
            this.controller = controller;
        }

        public string ListTitle
        {
            get { return this.TitleLabel.Text; }
            set { this.TitleLabel.Text = value; }
        }

        public void ClearView()
        {
            this.MainListView.Items.Clear();
            this.MainListView.Columns.Clear();
        }

        public void AddListViewColumns(IList columns)
        {
            foreach (string columnName in columns)
            {
                this.MainListView.Columns.Add(columnName);
            }
        }

        public void AddItemToListView(object item)
        {
            if(item is Department)
            {
                AddDepartmentToListView((Department)item);
            }
            else if(item is Role)
            {
                AddRoleToListView((Role)item);
            }
            else if(item is Item)
            {
                AddItemObjectToView((Item)item);
            }
            else if(item is ProtocolEvent)
            {
                AddProtocolEventToListView((ProtocolEvent)item);
            }
            else if(item is User)
            {
                AddUserToListView((User)item);
            }
        }

        private void AddDepartmentToListView(Department item)
        {
            ListViewItem listViewItem = this.MainListView.Items.Add(item.ID.ToString());
            listViewItem.SubItems.Add(item.Name);
            listViewItem.SubItems.Add(item.IsActive.ToString());
        }

        private void AddRoleToListView(Role role)
        {
            ListViewItem item = this.MainListView.Items.Add(role.RoleID.ToString());
            item.SubItems.Add(role.RoleName);
            item.SubItems.Add(role.IsActive.ToString());
        }

        private void AddItemObjectToView(Item item)
        {
            if(item.ID != 0)
            {
                ListViewItem listViewItem = this.MainListView.Items.Add(item.ID.ToString());
                listViewItem.SubItems.Add(item.Value);
                listViewItem.SubItems.Add(item.IsActive.ToString());
            }
            else
            {
                ListViewItem listViewItem = this.MainListView.Items.Add(item.Value);
                listViewItem.SubItems.Add(item.IsActive.ToString());
            }
        }

        private void AddProtocolEventToListView(ProtocolEvent protocolEvent)
        {
            ListViewItem item = this.MainListView.Items.Add(protocolEvent.ID.ToString());
            item.SubItems.Add(protocolEvent.Type);
            item.SubItems.Add(protocolEvent.Description);
            item.SubItems.Add(protocolEvent.IsActive.ToString());
        }

        private void AddUserToListView(User user)
        {
            ListViewItem item = this.MainListView.Items.Add(user.UserName);
            item.SubItems.Add(user.FullName);
            item.SubItems.Add(user.Department.Name);
            item.SubItems.Add(user.Role.RoleName);
            item.SubItems.Add(user.IsActive.ToString());
        }

        public void SetListViewAutoResizeColumns(int columnIndex, ColumnHeaderAutoResizeStyle style)
        {
            this.MainListView.Columns[columnIndex].AutoResize(style);
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
