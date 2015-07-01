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
        Item selectedItem;
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
            foreach (Item item in items)
            {
                view.AddItemToListView(item);
            }
        }

        public void ListViewSelectedIndexChanged(int selectedIndex)
        {
            if (selectedIndex > -1 && selectedIndex < items.Count)
            {
                selectedItem = (Item)items[selectedIndex];
            }
        }

        public void NewButtonClicked()
        {
            string result = TemplatesController.ShowOneTextBoxForm("List Name: ", "", this.view.ParentControl);
            if (result != String.Empty)
            {
                InsertNewItem(result);
                LoadView();
            }
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
