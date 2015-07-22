using Toxikon.ProtocolManager.Interfaces.Admin;
using Toxikon.ProtocolManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.ProtocolManager.Models.Admin;

namespace Toxikon.ProtocolManager.Controllers.Admin
{
    public class ProtocolEventEditController
    {
        IProtocolEventEditView view;

        public ProtocolEvent ProtocolEvent{get; private set;}
        private List<AuditItem> auditItems;

        public ProtocolEventEditController(IProtocolEventEditView view)
        {
            this.view = view;
            this.view.SetController(this);
            this.ProtocolEvent = new ProtocolEvent();
            this.auditItems = new List<AuditItem>();
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
            this.auditItems = new List<AuditItem>();
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
            SubmitAuditItems();
            this.ProtocolEvent.Type = view.EventType;
            this.ProtocolEvent.Description = view.EventDescription;
            this.ProtocolEvent.IsActive = view.IsActive;
            view.SetDialogResult(DialogResult.OK);
        }

        private void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        private void SubmitAuditItems()
        {
            CreateAuditItems();
            if (this.auditItems.Count != 0)
            {
                AuditHandler.InsertAuditItems(this.auditItems);
                this.auditItems.Clear();
            }
        }

        private void CreateAuditItems()
        {
            CheckAndAddToAuditItems("EventType", this.ProtocolEvent.Type, view.EventType);
            CheckAndAddToAuditItems("EventDescription", this.ProtocolEvent.Description, view.EventDescription);
            CheckAndAddToAuditItems("IsActive", this.ProtocolEvent.IsActive.ToString(), view.IsActive.ToString());
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
            LoginInfo loginInfo = LoginInfo.GetInstance();
            AuditItem item = new AuditItem();
            item.TableName = "ProtocolEvents";
            item.Type = "U";
            item.PK = "ID";
            item.PKValue = this.ProtocolEvent.ID.ToString();
            item.FieldName = fieldName;
            item.OldValue = oldValue.Trim() == String.Empty ? "N/A" : oldValue;
            item.NewValue = newValue;
            item.UpdatedBy = loginInfo.UserName;
            item.Reason = "Admin Protocol Event Update.";

            return item;
        }
    }
}
