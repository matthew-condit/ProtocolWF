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
using Toxikon.ProtocolManager.Queries;

namespace Toxikon.ProtocolManager.Controllers.Admin
{
    public class TemplateGroupsController : UCToolStripListView1Controller
    {
        private IUCToolStripListView1 view;
        private IList items;
        private Item selectedItem;
        private LoginInfo loginInfo;

        public TemplateGroupsController(IUCToolStripListView1 view)
        {
            this.view = view;
            this.view.SetController(this);
            items = new ArrayList();
            loginInfo = LoginInfo.GetInstance();
        }

        public override void LoadView()
        {
            items.Clear();
            view.ClearView();

            IList columns = new ArrayList() { "ID", "Group Name", "Active" };
            this.view.AddListViewColumns(columns);
            this.view.ListTitle = "Protocol Template Groups";

            items = QTemplateGroups.GetAllItems();
            AddItemsToView();
        }

        private void AddItemsToView()
        {
            foreach(Item item in items)
            {
                this.view.AddItemToListView(item);
            }
        }

        private void SetColumnsHeaderSize()
        {
            this.view.SetListViewAutoResizeColumns(0, ColumnHeaderAutoResizeStyle.HeaderSize);
            this.view.SetListViewAutoResizeColumns(1, ColumnHeaderAutoResizeStyle.ColumnContent);
            this.view.SetListViewAutoResizeColumns(2, ColumnHeaderAutoResizeStyle.HeaderSize);
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
            Item item = new Item();
            Item result = ShowPopup(item);
            if (result.Value != String.Empty)
            {
                QTemplateGroups.InsertItem(result.Value, loginInfo.UserName);
                LoadView();
            }
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
                    LoadView();
                }
            }
        }

        private Item ShowPopup(Item item)
        {
            Item textBoxItem = new Item("Group Name: ", item.Value);
            Item trueFalseItem = new Item("Active: ", item.IsActive.ToString());
            Item result = TemplatesController.ShowOneTextBoxTrueFalseForm(textBoxItem, trueFalseItem,
                               this.view.ParentControl);
            return result;
        }

    }
}
