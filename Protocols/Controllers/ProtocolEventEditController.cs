using Protocols.Interfaces;
using Protocols.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Protocols.Controllers
{
    public class ProtocolEventEditController
    {
        IProtocolEventEditView view;

        public ProtocolEvent ProtocolEvent{get; private set;}

        public ProtocolEventEditController(IProtocolEventEditView view)
        {
            this.view = view;
            this.view.SetController(this);
            this.ProtocolEvent = new ProtocolEvent();
        }

        public ProtocolEventEditController(IProtocolEventEditView view, ProtocolEvent protocolEvent)
        {
            this.view = view;
            this.view.SetController(this);
            this.view.EventType = protocolEvent.Type;
            this.view.EventDescription = protocolEvent.Description;
            this.view.IsActive = protocolEvent.IsActive;
            this.view.SetIsActiveRadioButtonGroup_Enable(true);
            this.ProtocolEvent = protocolEvent;
        }

        public void SubmitButtonClicked()
        {
            try
            {
                if (view.EventDescription.Trim() == "" || view.EventType.Trim() == "")
                {
                    view.SetDialogResult(DialogResult.Retry);
                    ShowMessage("All fields are required.");
                }
                else
                {
                    this.ProtocolEvent.Type = view.EventType;
                    this.ProtocolEvent.Description = view.EventDescription;
                    this.ProtocolEvent.IsActive = view.IsActive;
                    view.SetDialogResult(DialogResult.OK);
                }
            }
            catch (Exception e)
            {
                ShowMessage(e.Message);
            }
        }

        private void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
