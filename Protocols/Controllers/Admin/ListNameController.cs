using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.ProtocolManager.Controllers.Templates;
using Toxikon.ProtocolManager.Interfaces.Admin;
using Toxikon.ProtocolManager.Interfaces.Templates;
using Toxikon.ProtocolManager.Models;
using Toxikon.ProtocolManager.Models.Admin;
using Toxikon.ProtocolManager.Queries;
using Toxikon.ProtocolManager.Views.Templates;

namespace Toxikon.ProtocolManager.Controllers.Admin
{
    public class ListNameController : UCToolStripListView1Controller
    {
        IUCToolStripListView1 view;
        IList items;
        Item selectedItem;
        LoginInfo loginInfo;
        private List<AuditItem> auditItems;

        public ListNameController(IUCToolStripListView1 view)
        {
            this.view = view;
            this.view.SetController(this);
            loginInfo = LoginInfo.GetInstance();
            items = new ArrayList();
            auditItems = new List<AuditItem>();
        }

        public override void LoadView()
        {
            items.Clear();
            view.ClearView();
            IList columns = new ArrayList() { "Name", "Active" };
            this.view.AddListViewColumns(columns);
            this.view.ListTitle = "List Names";
            items = QListNames.SelectItems();
            AddItemsToView();
            SetColumnsHeaderSize();
        }

        private void AddItemsToView()
        {
            foreach (Item item in items)
            {
                view.AddItemToListView(item);
            }
        }

        private void SetColumnsHeaderSize()
        {
            this.view.SetListViewAutoResizeColumns(0, ColumnHeaderAutoResizeStyle.ColumnContent);
            this.view.SetListViewAutoResizeColumns(1, ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        public override void ListViewSelectedIndexChanged(int selectedIndex)
        {
            if (selectedIndex > -1 && selectedIndex < items.Count)
            {
                selectedItem = (Item)items[selectedIndex];
            }
        }

        public override void NewButtonClicked()
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

        public override void UpdateButtonClicked()
        {
            if (this.selectedItem == null)
            {
                MessageBox.Show("Please select one item and try it again.");
            }
            else
            {
                Item result = ShowPopup(this.selectedItem);
                if (result.Value != String.Empty)
                {
                    SubmitAuditItem(result);
                    QListNames.UpdateItem(this.selectedItem, result, loginInfo.UserName);
                    LoadView();
                }
            }
        }

        private Item ShowPopup(Item item)
        {
            Item textBoxItem = new Item("List Name: ", item.Name);
            Item trueFalseItem = new Item("Active: ", item.IsActive.ToString());
            Item result = TemplatesController.ShowOneTextBoxTrueFalseForm(textBoxItem, trueFalseItem,
                               this.view.ParentControl);
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
            CheckAndAddToAuditItems("RoleName", this.selectedItem.Name, item.Value);
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
            AuditItem item = new AuditItem();
            item.TableName = "ListNames";
            item.Type = "U";
            item.PK = "Name";
            item.PKValue = this.selectedItem.Name;
            item.FieldName = fieldName;
            item.OldValue = oldValue.Trim() == String.Empty ? "N/A" : oldValue;
            item.NewValue = newValue;
            item.UpdatedBy = loginInfo.UserName;
            item.Reason = "Admin List Name Update.";

            return item;
        }
    }
}
