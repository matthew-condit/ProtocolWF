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
using Toxikon.ProtocolManager.Models.Admin;

namespace Toxikon.ProtocolManager.Views.Admin
{
    public partial class DepartmentDirectorsView : UserControl, IDepartmentDirectorsView
    {
        public DepartmentDirectorsView()
        {
            InitializeComponent();
            this.DepartmentsComboBox.ComboBox.DisplayMember = "Name";
            this.DirectorsComboBox.ComboBox.DisplayMember = "Text";
        }

        private DepartmentDirectorsController controller;

        public void SetController(DepartmentDirectorsController controller)
        {
            this.controller = controller;
        }

        public void AddDepartmentToView(Department department)
        {
            this.DepartmentsComboBox.Items.Add(department);
        }

        public void AddDirectorsToView(Item director)
        {
            this.DirectorsComboBox.Items.Add(director);
        }

        public void AddItemToListView(DepartmentDirector item)
        {
            ListViewItem lvItem = this.ItemsListView.Items.Add(item.ID.ToString());
            lvItem.SubItems.Add(item.DepartmentID.ToString());
            lvItem.SubItems.Add(item.DepartmentName);
            lvItem.SubItems.Add(item.UserName);
            lvItem.SubItems.Add(item.FullName);
        }

        public void ClearView()
        {
            this.DepartmentsComboBox.SelectedIndex = -1;
            this.DirectorsComboBox.SelectedIndex = -1;
            this.ItemsListView.Items.Clear();
        }

        public Control UCParentForm
        {
            get { return this.ParentForm; }
        }

        private void DepartmentsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.controller.DepartmentsComboBox_SelectedIndexChanged(this.DepartmentsComboBox.SelectedIndex);
        }

        private void DirectorsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.controller.DirectorsComboBox_SelectedIndexChanged(this.DirectorsComboBox.SelectedIndex);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            this.controller.AddButtonClicked();
        }
    }
}
