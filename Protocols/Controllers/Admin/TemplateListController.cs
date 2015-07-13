using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.ProtocolManager.Controllers.Templates;
using Toxikon.ProtocolManager.Interfaces.Templates;
using Toxikon.ProtocolManager.Models;
using Toxikon.ProtocolManager.Queries;

namespace Toxikon.ProtocolManager.Controllers.Admin
{
    public class TemplateListController : Controller
    {
        private IUCTemplate2 view;
        private IList comboBoxItems;
        private IList listViewItems;
        private Item comboBoxSelectedItem;
        private Item listViewSelectedItem;

        public TemplateListController(IUCTemplate2 view)
        {
            this.view = view;
            this.view.SetController(this);
            this.comboBoxItems = new ArrayList();
            this.listViewItems = new ArrayList();
        }

        public void LoadView()
        {
            IList columns = new ArrayList(){"ID", "Title", "Active"};
            this.view.AddListViewColumns(columns);
            this.comboBoxItems = QTemplateGroups.GetActiveItems();
            if(this.comboBoxItems.Count != 0)
            {
                AddItemsToComboBox();
                this.view.SetComboBoxDisplayMember("Value");
                this.view.SetComboBoxSelectedIndex(0);
            }
        }

        private void AddItemsToComboBox()
        {
            foreach (Item item in comboBoxItems)
            {
                this.view.AddItemToComboBox(item);
            }
        }

        public void ComboBoxSelectedIndexChanged(int selectedIndex)
        {
            if (selectedIndex > -1 && selectedIndex < this.comboBoxItems.Count)
            {
                this.comboBoxSelectedItem = this.comboBoxItems[selectedIndex] as Item;
                LoadListViewItems();
            }
        }

        private void LoadListViewItems()
        {
            this.ClearListView();
            this.listViewItems = QTemplates.GetItemsByGroupID(this.comboBoxSelectedItem.ID);
            AddItemsToListView();
        }

        public void ClearListView()
        {
            this.listViewItems.Clear();
            this.view.ClearListView();
        }

        public void AddItemsToListView()
        {
            foreach (Item item in listViewItems)
            {
                string[] values = new string[] { item.ID.ToString(), item.Value, item.IsActive.ToString() };
                this.view.AddItemToListView(values);
            }
        }

        public void ListViewSelectedIndexChanged(int selectedIndex)
        {
            if (selectedIndex > -1 && selectedIndex < this.listViewItems.Count)
            {
                this.listViewSelectedItem = listViewItems[selectedIndex] as Item;
            }
        }

        public void AddButtonClicked()
        {
            if (this.comboBoxSelectedItem != null && view.TextBoxValue.Trim() != "")
            {
                InsertNewTemplate();
            }
            else
            {
                MessageBox.Show("All fields are required!");
            }
        }

        private void InsertNewTemplate()
        {
            LoginInfo loginInfo = LoginInfo.GetInstance();
            QTemplates.InsertItem(this.comboBoxSelectedItem.ID, this.view.TextBoxValue, loginInfo.UserName);
        }

        public void UpdateButtonClicked()
        {

        }

        private Item ShowPopup()
        {
            Item textBoxItem = new Item("Title: ", this.listViewSelectedItem.Value);
            Item trueFalseItem = new Item("Active: ", this.listViewSelectedItem.IsActive.ToString());
            Item result = TemplatesController.ShowOneTextBoxTrueFalseForm(textBoxItem, trueFalseItem,
                               view.ParentControl);
            return result;
        }
    }
}
