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
using Toxikon.ProtocolManager.Models.Admin;

namespace Toxikon.ProtocolManager.Controllers.Admin
{
    public class ListItemsController
    {
        IListItemsView view;
        IList listNames;
        IList listItems;
        Item selectedItem;
        string selectedListName;
        private List<AuditItem> auditItems;

        public ListItemsController(IListItemsView view)
        {
            this.view = view;
            this.view.SetController(this);
            listNames = new ArrayList();
            listItems = new ArrayList();
            this.selectedItem = null;
            this.selectedListName = "";
            this.auditItems = new List<AuditItem>();
        }

        public void LoadView()
        {
            listNames = QListNames.SelectItems();
            foreach(Item listName in listNames)
            {
                this.view.AddListNameToView(listName.Name);
            }
        }

        public void ListNameComboBoxSelectedIndexChanged(int selectedIndex)
        {
            if(selectedIndex > -1 && selectedIndex < this.listNames.Count)
            {
                Item selectedListName = listNames[selectedIndex] as Item;
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
            foreach(Item item in listItems)
            {
                view.AddListItemToView(item);
            }
        }

        public void ListViewSelectedIndexChanged(int selectedIndex)
        {
            if(selectedIndex > -1 && selectedIndex < this.listItems.Count)
            {
                this.selectedItem = listItems[selectedIndex] as Item;
            }
        }

        public void AddButtonClicked()
        {
            if(this.selectedListName != "" && view.ItemName.Trim() != "")
            {
                CreateAndInsertNewListItem();
            }
            else
            {
                MessageBox.Show("List Name and Item Name are required!");
            }
        }

        private void CreateAndInsertNewListItem()
        {
            Item item = new Item(this.selectedListName, view.ItemName, view.ItemName, true);
            LoginInfo loginInfo = LoginInfo.GetInstance();
            QListItems.InsertItem(item, loginInfo.UserName);
            view.ClearNewItemTextBox();
            LoadSelectedListNameItems();
        }

        public void UpdateButtonClicked()
        {
            if(this.selectedItem != null)
            {
                string oldItemValue = selectedItem.Value;
                Item result = ShowPopup();
                if(result.Value.Trim() != String.Empty)
                {
                    SubmitAuditItem(result);
                    UpdateSelectedItem(oldItemValue, result);
                    LoadSelectedListNameItems();
                }
                this.selectedItem = null;
            }
            else
            {
                MessageBox.Show("Please select at least one item.");
            }
        }

        private void UpdateSelectedItem(string oldItemValue, Item result)
        {
            this.selectedItem.Text = result.Value;
            this.selectedItem.Value = result.Value;
            this.selectedItem.IsActive = result.IsActive;
            LoginInfo loginInfo = LoginInfo.GetInstance();
            QListItems.UpdateItem(this.selectedItem, oldItemValue, loginInfo.UserName);
        }

        private Item ShowPopup()
        {
            Item textBoxItem = new Item("Item Value: ", this.selectedItem.Text);
            Item trueFalseItem = new Item("Active: ", this.selectedItem.IsActive.ToString());
            Item result = TemplatesController.ShowOneTextBoxTrueFalseForm(textBoxItem, trueFalseItem, 
                               view.ParentControl);
            return result;
        }

        private void SubmitAuditItem(Item item)
        {
            CreateAuditItems(item);
            if (this.auditItems.Count != 0)
            {
                AuditHandler.InsertAuditItems(this.auditItems);
                this.auditItems.Clear();
            }
        }

        private void CreateAuditItems(Item item)
        {
            CheckAndAddToAuditItems("ItemName", this.selectedItem.Text, item.Value);
            CheckAndAddToAuditItems("IsActive", this.selectedItem.IsActive.ToString(),
                                    item.IsActive.ToString());
        }

        private void CheckAndAddToAuditItems(string fieldName, string oldValue, string newValue)
        {
            if (oldValue.Trim() != newValue.Trim())
            {
                AuditItem item = CreateAuditItem(fieldName, oldValue, newValue);
                this.auditItems.Add(item);
            }
        }

        private AuditItem CreateAuditItem(string fieldName, string oldValue, string newValue)
        {
            LoginInfo loginInfo = LoginInfo.GetInstance();
            AuditItem item = new AuditItem();
            item.TableName = "ListItems";
            item.Type = "U";
            item.PK = "ListName,ItemName";
            item.PKValue = this.selectedListName + "," + this.selectedItem.Text;
            item.FieldName = fieldName;
            item.OldValue = oldValue.Trim() == String.Empty ? "N/A" : oldValue;
            item.NewValue = newValue;
            item.UpdatedBy = loginInfo.UserName;
            item.Reason = "Admin List Item Update.";

            return item;
        }
    }
}
