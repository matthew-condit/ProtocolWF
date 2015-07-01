using Toxikon.ProtocolManager.Interfaces.Admin;
using Toxikon.ProtocolManager.Models;
using Toxikon.ProtocolManager.Queries;
using Toxikon.ProtocolManager.Views;
using Toxikon.ProtocolManager.Views.Admin;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.ProtocolManager.Interfaces.Templates;
using Toxikon.ProtocolManager.Controllers.Templates;
using Toxikon.ProtocolManager.Views.Protocols;
using Toxikon.ProtocolManager.Controllers.Admin;

namespace Toxikon.ProtocolManager.Controllers.Protocols
{
    public class ProtocolEventsController : UCToolStripListView1Controller
    {
        IUCToolStripListView1 view;
        IList items;
        ProtocolEvent selectedItem;
        LoginInfo loginInfo;

        public ProtocolEventsController(IUCToolStripListView1 view)
        {
            this.view = view;
            this.view.SetController(this);
            this.items = new ArrayList();
            selectedItem = null;
            loginInfo = LoginInfo.GetInstance();
        }

        public override void LoadView()
        {
            this.items.Clear();
            this.view.ClearView();
            IList columns = new ArrayList() { "ID", "Event Type", "Description", "Active" };
            this.view.AddListViewColumns(columns);
            this.view.ListTitle = "Protocol Events";
            items = QProtocolEvents.SelectItems();
            AddItemsToView();
            SetColumnsHeaderSize();
        }

        private void AddItemsToView()
        {
            foreach(ProtocolEvent item in items)
            {
                this.view.AddItemToListView(item);
            }
        }

        private void SetColumnsHeaderSize()
        {
            this.view.SetListViewAutoResizeColumns(0, ColumnHeaderAutoResizeStyle.ColumnContent);
            this.view.SetListViewAutoResizeColumns(1, ColumnHeaderAutoResizeStyle.ColumnContent);
            this.view.SetListViewAutoResizeColumns(2, ColumnHeaderAutoResizeStyle.ColumnContent);
            this.view.SetListViewAutoResizeColumns(3, ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        public override void ListViewSelectedIndexChanged(int selectedIndex)
        {
            if(selectedIndex > -1 && selectedIndex < this.items.Count)
            {
                this.selectedItem = (ProtocolEvent)this.items[selectedIndex];
            }
        }

        public override void NewButtonClicked()
        {
            ProtocolEvent item = new ProtocolEvent();
            DialogResult dialogResult = ShowPopup(item);
            if (dialogResult == DialogResult.OK)
            {
                DoInsert(item);
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
                DialogResult dialogResult = ShowPopup(this.selectedItem);
                if (dialogResult == DialogResult.OK)
                {
                    DoUpdate(this.selectedItem);
                }
            }
        }

        private DialogResult ShowPopup(ProtocolEvent item)
        {
            ProtocolEventEditView popup = new ProtocolEventEditView();
            ProtocolEventEditController popupController = new ProtocolEventEditController(popup, item);
            DialogResult dialogResult = popup.ShowDialog(view.ParentControl);
            popup.Dispose();
            return dialogResult;
        }

        private void DoUpdate(ProtocolEvent item)
        {
            QProtocolEvents.UpdateItem(item, loginInfo.UserName);
            MessageBox.Show("Updated!");
            LoadView();
        }

        private void DoInsert(ProtocolEvent item)
        {
            QProtocolEvents.InsertItem(item, loginInfo.UserName);
            MessageBox.Show("New event is added.");
            LoadView();
        }
    }
}
