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
    public partial class ListNameView : UserControl, IListNameView
    {
        ListNameController controller;

        public ListNameView()
        {
            InitializeComponent();
        }

        public void SetController(ListNameController controller)
        {
            this.controller = controller;
        }
        
        public void AddItemToListView(ListName item)
        {
            ListViewItem listViewItem = this.MainListView.Items.Add(item.Name);
            listViewItem.SubItems.Add(item.IsActive.ToString());
        }
        public void ClearView()
        {
            this.MainListView.Items.Clear();
        }

        public Control ParentControl
        {
            get { return this.ParentForm; }
        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            this.controller.NewButtonClicked();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            this.controller.RemoveButtonClicked();
        }

        private void MainListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.MainListView.SelectedIndices.Count > 0)
            {
                this.controller.ListViewSelectedIndexChanged(this.MainListView.SelectedIndices[0]);
            }
        }
    }
}
