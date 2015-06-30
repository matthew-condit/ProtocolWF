using Toxikon.ProtocolManager.Interfaces.Protocols;
using Toxikon.ProtocolManager.Models;
using Toxikon.ProtocolManager.Queries;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Toxikon.ProtocolManager.Controllers.Protocols
{
    public class ProtocolEventAddController
    {
        IProtocolEventAddView view;
        IList protocolEvents;
        IList protocolEventTypes;
        string selectedEventType;
        public ProtocolEvent SelectedProtocolEvent { get; private set; }

        public ProtocolEventAddController(IProtocolEventAddView view)
        {
            this.view = view;
            this.view.SetController(this);
            this.protocolEvents = new ArrayList();
            selectedEventType = ProtocolEventTypes.ProtocolRequest;
            this.protocolEventTypes = new ArrayList(ProtocolEventTypes.EventTypeList);
            this.SelectedProtocolEvent = null;
        }

        public void LoadView()
        {
            AddProtocolEventTypesToView();
            this.view.SetSelectedProtocolEventType(0);
        }

        private void AddProtocolEventTypesToView()
        {
            foreach(string eventType in this.protocolEventTypes)
            {
                this.view.AddProtocolEventTypeToView(eventType);
            }
        }
        private void AddProtocolEventsToView()
        {
            this.protocolEvents = QProtocolEvents.SelectItems(this.selectedEventType);
            foreach(ProtocolEvent protocolEvent in protocolEvents)
            {
                this.view.AddProtocolEventToView(protocolEvent);
            }
        }

        public void EventTypeComboBox_SelectedIndexChanged(int selectedIndex)
        {
            if(selectedIndex > -1 && selectedIndex < this.protocolEventTypes.Count)
            {
                this.selectedEventType = this.protocolEventTypes[selectedIndex] as string;
                this.protocolEvents.Clear();
                this.view.ClearListBox();
                AddProtocolEventsToView();
            }
        }

        public void ProtocolEventListBox_SelectedIndexChanged(int selectedIndex)
        {
            if(selectedIndex > -1 && selectedIndex < this.protocolEvents.Count)
            {
                this.SelectedProtocolEvent = this.protocolEvents[selectedIndex] as ProtocolEvent;
            }
        }

        public void SubmitButtonClicked()
        {
            if(this.SelectedProtocolEvent == null)
            {
                MessageBox.Show("Please select an event.");
                this.view.SetDialogResult(DialogResult.Retry);
            }
            else
            {
                this.view.SetDialogResult(DialogResult.OK);
            }
        }
    }
}
