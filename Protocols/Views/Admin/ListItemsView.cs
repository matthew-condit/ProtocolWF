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
    public partial class ListItemsView : UserControl, IListItemsView
    {
        ListItemsController controller;

        public ListItemsView()
        {
            InitializeComponent();
        }

        public void SetController(ListItemsController controller)
        {
            this.controller = controller;
        }
        public Control ParentControl
        {
            get { return this.ParentForm; }
        }
        public void AddListNameToView(string listName)
        {
            this.ListNameComboBox.Items.Add(listName);
        }
        public void AddListItemToView(Item listItem)
        {
            ListViewItem item = this.ItemsListView.Items.Add(listItem.Text);
            item.SubItems.Add(listItem.IsActive.ToString());
        }
        public void ClearListItems()
        {
            this.ItemsListView.Items.Clear();
        }
        public void ClearNewItemTextBox()
        {
            this.ItemNameTextBox.Text = "";
        }

        public string ItemName
        {
            get { return this.ItemNameTextBox.Text; }
            set { this.ItemNameTextBox.Text = value; }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            this.controller.AddButtonClicked();
        }

        private void ListNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.controller.ListNameComboBoxSelectedIndexChanged(this.ListNameComboBox.SelectedIndex);
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            this.controller.UpdateButtonClicked();
        }

        private void ItemsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.ItemsListView.SelectedIndices.Count > 0)
            {
                this.controller.ListViewSelectedIndexChanged(this.ItemsListView.SelectedIndices[0]);
            }
        }
    }
}
