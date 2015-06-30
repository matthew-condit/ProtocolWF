using Toxikon.ProtocolManager.Interfaces.Admin;
using Toxikon.ProtocolManager.Models;
using Toxikon.ProtocolManager.Queries;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.ProtocolManager.Views.Templates;
using Toxikon.ProtocolManager.Controllers.Templates;

namespace Toxikon.ProtocolManager.Controllers.Admin
{
    public class ListItemsController
    {
        IListItemsView view;
        IList listNames;
        IList listItems;
        ListItem selectedItem;
        string selectedListName;

        public ListItemsController(IListItemsView view)
        {
            this.view = view;
            this.view.SetController(this);
            listNames = new ArrayList();
            listItems = new ArrayList();
            this.selectedItem = null;
            this.selectedListName = "";
        }

        public void LoadView()
        {
            listNames = QListNames.SelectItems();
            foreach(ListName listName in listNames)
            {
                this.view.AddListNameToView(listName.Name);
            }
        }

        public void ListNameComboBoxSelectedIndexChanged(int selectedIndex)
        {
            if(selectedIndex > -1 && selectedIndex < this.listNames.Count)
            {
                ListName selectedListName = listNames[selectedIndex] as ListName;
                this.selectedListName =  selectedListName.Name;
                LoadSelectedListNameItems();
            }
        }

        private void LoadSelectedListNameItems()
        {
            view.ClearListItems();
            listItems = QListItems.SelectItems(this.selectedListName);
            AddListItemsToView();
        }

        private void AddListItemsToView()
        {
            foreach(ListItem item in listItems)
            {
                view.AddListItemToView(item);
            }
        }

        public void ListViewSelectedIndexChanged(int selectedIndex)
        {
            if(selectedIndex > -1 && selectedIndex < this.listItems.Count)
            {
                this.selectedItem = listItems[selectedIndex] as ListItem;
            }
        }

        public void AddButtonClicked()
        {
            if(this.selectedListName != "" && view.ItemName.Trim() != "")
            {
                ListItem item = new ListItem(this.selectedListName, view.ItemName, view.ItemName, true);
                LoginInfo loginInfo = LoginInfo.GetInstance();
                QListItems.InsertItem(item, loginInfo.UserName);
                view.ClearNewItemTextBox();
                LoadSelectedListNameItems();
            }
        }

        public void UpdateButtonClicked()
        {
            if(this.selectedItem != null)
            {
                string oldItemValue = selectedItem.Value;
                ListItem result = ShowPopup();
                if(result.Value.Trim() != String.Empty)
                {
                    UpdateSelectedItem(oldItemValue, result);
                    LoadSelectedListNameItems();
                }
            }
            else
            {
                MessageBox.Show("Please select at least one item.");
            }
        }

        private void UpdateSelectedItem(string oldItemValue, ListItem result)
        {
            this.selectedItem.Text = result.Value;
            this.selectedItem.Value = result.IsActive.ToString();
            this.selectedItem.IsActive = result.IsActive;
            LoginInfo loginInfo = LoginInfo.GetInstance();
            QListItems.UpdateItem(this.selectedItem, oldItemValue, loginInfo.UserName);
        }

        public ListItem ShowPopup()
        {
            ListItem textBoxItem = new ListItem("Item Value: ", this.selectedItem.Text);
            ListItem trueFalseItem = new ListItem("Active: ", this.selectedItem.IsActive.ToString());
            ListItem result = TemplatesController.ShowOneTextBoxTrueFalseForm(textBoxItem, trueFalseItem, 
                               view.ParentControl);
            return result;
        }
    }
}
