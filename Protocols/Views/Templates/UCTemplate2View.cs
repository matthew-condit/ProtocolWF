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
using Toxikon.ProtocolManager.Models;
using System.Collections;
using Toxikon.ProtocolManager.Controllers.Admin;

namespace Toxikon.ProtocolManager.Views.Templates
{
    public partial class UCTemplate2View : UserControl, IUCTemplate2
    {
        private Controller controller;

        public UCTemplate2View()
        {
            InitializeComponent();
        }

        public void SetController(Controller controller)
        {
            this.controller = controller;
        }

        public void AddItemToComboBox(Item item)
        {
            this.MainComboBox.Items.Add(item);
        }

        public void SetComboBoxDisplayMember(string displayMember)
        {
            this.MainComboBox.ComboBox.DisplayMember = displayMember;
        }

        public void SetComboBoxSelectedIndex(int selectedIndex)
        {
            this.MainComboBox.SelectedIndex = selectedIndex;
        }

        public void AddListViewColumns(IList columns)
        {
            foreach (string columnName in columns)
            {
                this.ItemsListView.Columns.Add(columnName);
            }
        }

        public void AddItemToListView(string[] values)
        {
            ListViewItem item = this.ItemsListView.Items.Add(values[0]);
            for(int i = 1; i < values.Length; i++)
            {
                item.SubItems.Add(values[i]);
            }
        }

        public void SetListViewAutoResizeColumns(int columnIndex, ColumnHeaderAutoResizeStyle style)
        {
            this.ItemsListView.Columns[columnIndex].AutoResize(style);
        }

        public void ClearListView()
        {
            this.ItemsListView.Items.Clear();
        }

        public void ClearTextBox()
        {
            this.ItemNameTextBox.Text = "";
        }

        public string TextBoxValue
        {
            get { return this.ItemNameTextBox.Text; }
            set { this.ItemNameTextBox.Text = value; }
        }

        public Control ParentControl
        {
            get { return this.ParentForm; }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if(this.controller is TemplateListController)
            {
                ((TemplateListController)this.controller).AddButtonClicked();
            }
        }

        private void MainComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.controller is TemplateListController)
            {
                ((TemplateListController)this.controller).ComboBoxSelectedIndexChanged(this.MainComboBox.SelectedIndex);
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if(this.controller is TemplateListController)
            {
                ((TemplateListController)this.controller).UpdateButtonClicked();
            }
        }

        private void ItemsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.ItemsListView.SelectedIndices.Count > 0)
            {
                if (this.controller is TemplateListController)
                {
                    ((TemplateListController)this.controller).ListViewSelectedIndexChanged(this.ItemsListView.SelectedIndices[0]);
                }
            }
        }
    }
}
