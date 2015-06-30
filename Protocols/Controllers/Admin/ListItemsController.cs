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
                ListItem item = new ListItem();
                item.Name = this.selectedListName;
                item.Text = view.ItemName;
                item.IsActive = true;

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
                ShowUpdateWindow();
                if(this.selectedItem.Value.Trim() != String.Empty)
                {
                    LoginInfo loginInfo = LoginInfo.GetInstance();
                    QListItems.UpdateItem(this.selectedItem, oldItemValue, loginInfo.UserName);
                    LoadSelectedListNameItems();
                }
            }
            else
            {
                MessageBox.Show("Please select at least one item.");
            }
        }

        public void ShowUpdateWindow()
        {
            OneTextBoxTrueFalseForm popup = new OneTextBoxTrueFalseForm();
            OneTextBoxTrueFalseFormController popupController = new OneTextBoxTrueFalseFormController(popup);
            popupController.SetTextBoxItem("Item Value: ", this.selectedItem.Text);
            popupController.SetTrueFalseItem("Active: ", this.selectedItem.IsActive);

            DialogResult dialogResult = popup.ShowDialog(this.view.ParentControl);
            popup.Dispose();

            this.selectedItem.IsActive = popupController.TrueFalseValue;
            this.selectedItem.Text = popupController.TextBoxValue;
            this.selectedItem.Value = popupController.TextBoxValue;
        }
    }
}
