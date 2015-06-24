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
        public void AddListNameToView(string listName)
        {
            this.ListNameComboBox.Items.Add(listName);
        }
        public void AddListItemToView(string listItem)
        {
            ListViewItem item = this.ItemsListView.Items.Add(listItem);
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
    }
}
