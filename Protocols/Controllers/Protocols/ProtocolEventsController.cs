using Toxikon.ProtocolManager.Interfaces.Protocols;
using Toxikon.ProtocolManager.Models;
using Toxikon.ProtocolManager.Queries;
using Toxikon.ProtocolManager.Views;
using Toxikon.ProtocolManager.Views.Protocols;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Toxikon.ProtocolManager.Controllers.Protocols
{
    public class ProtocolEventsController
    {
        IProtocolEventsView view;
        IList items;
        ProtocolEvent selectedItem;
        LoginInfo loginInfo;

        public ProtocolEventsController(IProtocolEventsView view)
        {
            this.view = view;
            this.view.SetController(this);
            this.items = new ArrayList();
            selectedItem = null;
            loginInfo = LoginInfo.GetInstance();
        }

        public void LoadView()
        {
            this.items.Clear();
            this.view.ClearView();
            items = QProtocolEvents.SelectItems();
            AddItemsToView();
        }

        private void AddItemsToView()
        {
            foreach(ProtocolEvent item in items)
            {
                this.view.AddItemToListView(item);
            }
        }

        public void ListViewSelectedIndexChanged(int selectedIndex)
        {
            if(selectedIndex > -1 && selectedIndex < this.items.Count)
            {
                this.selectedItem = (ProtocolEvent)this.items[selectedIndex];
            }
        }

        public void NewButtonClicked()
        {
            ProtocolEvent item = new ProtocolEvent();
            DialogResult dialogResult = ShowPopup(item);
            if (dialogResult == DialogResult.OK)
            {
                DoInsert(item);
            }
        }
        
        public void UpdateButtonClicked()
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
