using Protocols.Interfaces;
using Protocols.Models;
using Protocols.Queries;
using Protocols.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Protocols.Controllers
{
    public class ProtocolEventsController
    {
        IProtocolEventsView view;
        IList protocolEvents;
        ProtocolEvent selectedProtocolEvent;

        public ProtocolEventsController(IProtocolEventsView view)
        {
            this.view = view;
            this.view.SetController(this);
            this.protocolEvents = new ArrayList();
            selectedProtocolEvent = null;
        }

        public void LoadView()
        {
            this.protocolEvents.Clear();
            this.view.ClearView();
            protocolEvents = QProtocolEvents.SelectProtocolEvents();
            AddProtocolEventsToView();
        }
        private void AddProtocolEventsToView()
        {
            foreach(ProtocolEvent item in protocolEvents)
            {
                this.view.AddItemToListView(item);
            }
        }

        public void ListViewSelectedIndexChanged(int selectedIndex)
        {
            this.selectedProtocolEvent = (ProtocolEvent)this.protocolEvents[selectedIndex];
        }

        public void NewButtonClicked()
        {
            ProtocolEventEditView popup = new ProtocolEventEditView();
            ProtocolEventEditController popupController = new ProtocolEventEditController(popup);

            DialogResult dialogResult = popup.ShowDialog(view.ParentControl);
            if (dialogResult == DialogResult.OK)
            {
                ProtocolEvent item = popupController.ProtocolEvent;
                InsertNewItem(item);
                LoadView();
            }
            popup.Dispose();
        }
        private void InsertNewItem(ProtocolEvent item)
        {
            LoginInfo loginInfo = LoginInfo.GetInstance();
            QProtocolEvents.InsertProtocolEvent(item, loginInfo.UserName);
            MessageBox.Show("New event is added.");
        }
        public void UpdateButtonClicked()
        {
            if (this.selectedProtocolEvent == null)
            {
                MessageBox.Show("Please select one item and try it again.");
            }
            else
            {
                ProtocolEventEditView popup = new ProtocolEventEditView();
                ProtocolEventEditController popupController = new ProtocolEventEditController(
                                            popup, this.selectedProtocolEvent);

                DialogResult dialogResult = popup.ShowDialog(view.ParentControl);
                if (dialogResult == DialogResult.OK)
                {
                    UpdateSelectedItem();
                    LoadView();
                }
                popup.Dispose();
            }
        }
        private void UpdateSelectedItem()
        {
            LoginInfo loginInfo = LoginInfo.GetInstance();
            QProtocolEvents.UpdateProtocolEvent(this.selectedProtocolEvent, loginInfo.UserName);
        }
    }
}
