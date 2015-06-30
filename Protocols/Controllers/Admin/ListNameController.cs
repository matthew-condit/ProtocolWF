using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.ProtocolManager.Controllers.Templates;
using Toxikon.ProtocolManager.Interfaces.Admin;
using Toxikon.ProtocolManager.Models;
using Toxikon.ProtocolManager.Queries;
using Toxikon.ProtocolManager.Views.Templates;

namespace Toxikon.ProtocolManager.Controllers.Admin
{
    public class ListNameController
    {
        IListNameView view;
        IList items;
        ListName selectedItem;
        LoginInfo loginInfo;

        public ListNameController(IListNameView view)
        {
            this.view = view;
            this.view.SetController(this);
            loginInfo = LoginInfo.GetInstance();
            items = new ArrayList();
        }

        public void LoadView()
        {
            LoadItems();
            AddItemsToView();
        }

        public void LoadItems()
        {
            items.Clear();
            items = QListNames.SelectItems();
        }

        private void AddItemsToView()
        {
            view.ClearView();
            foreach (ListName item in items)
            {
                view.AddItemToListView(item);
            }
        }

        public void ListViewSelectedIndexChanged(int selectedIndex)
        {
            if (selectedIndex > -1 && selectedIndex < items.Count)
            {
                selectedItem = (ListName)items[selectedIndex];
            }
            else
            {
                selectedItem = null;
            }
        }

        public void NewButtonClicked()
        {
            OneTextBoxFormView popup = new OneTextBoxFormView();
            OneTextBoxFormController popupController = new OneTextBoxFormController(popup, "List Name: ");

            DialogResult dialogResult = popup.ShowDialog(view.ParentControl);
            if (dialogResult == DialogResult.OK)
            {
                InsertNewItem(popupController.TextBoxValue);
                LoadView();
            }
            popup.Dispose();
        }

        private void InsertNewItem(string item)
        {
            LoginInfo loginInfo = LoginInfo.GetInstance();
            QListNames.InsertItem(item, loginInfo.UserName);
            MessageBox.Show("New item is added.");
        }

        public void RemoveButtonClicked()
        {
            if (this.selectedItem == null)
            {
                MessageBox.Show("Please select one item and try it again.");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure?", "Inactivate Item",
                                            MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    this.selectedItem.IsActive = false;
                    QListNames.UpdateIsActive(this.selectedItem, loginInfo.UserName);
                    LoadView();
                }
            }
        }
    }
}
