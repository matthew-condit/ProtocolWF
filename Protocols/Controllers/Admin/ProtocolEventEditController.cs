﻿using Toxikon.ProtocolManager.Interfaces.Admin;
using Toxikon.ProtocolManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Toxikon.ProtocolManager.Controllers.Admin
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
                    CancelSubmitEvent();
                }
                else
                {
                    SubmitForm();
                }
            }
            catch (Exception e)
            {
                ShowMessage(e.Message);
            }
        }

        private void CancelSubmitEvent()
        {
            view.SetDialogResult(DialogResult.Retry);
            ShowMessage("All fields are required.");
        }

        private void SubmitForm()
        {
            this.ProtocolEvent.Type = view.EventType;
            this.ProtocolEvent.Description = view.EventDescription;
            this.ProtocolEvent.IsActive = view.IsActive;
            view.SetDialogResult(DialogResult.OK);
        }

        private void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
