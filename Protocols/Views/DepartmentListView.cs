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
    public partial class DepartmentListView : UserControl, IDepartmentListView
    {
        DepartmentListController controller;

        public DepartmentListView()
        {
            InitializeComponent();
        }

        public void SetController(DepartmentListController controller)
        {
            this.controller = controller;
        }

        public void ClearView()
        {
            this.MainListView.Items.Clear();
        }

        public void AddItemToListView(Department department)
        {
            ListViewItem item = this.MainListView.Items.Add(department.DepartmentID.ToString());
            item.SubItems.Add(department.DepartmentName);
            item.SubItems.Add(department.IsActive.ToString());
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
