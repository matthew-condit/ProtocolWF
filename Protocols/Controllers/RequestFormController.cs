using Toxikon.ProtocolManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toxikon.ProtocolManager.Models;
using Toxikon.ProtocolManager.Views.Templates;
using Toxikon.ProtocolManager.Controllers.Templates;
using System.Windows.Forms;
using System.Collections;
using Toxikon.ProtocolManager.Queries;
using System.Diagnostics;
using Toxikon.ProtocolManager.Models.Admin;

namespace Toxikon.ProtocolManager.Controllers
{
    public class RequestFormController
    {
        protected IRequestForm view;
        protected ProtocolRequest request;
        private List<AuditItem> auditItems;
        LoginInfo loginInfo;

        enum OptionFields { Guidelines, Compliance, ProtocolType, AssignedTo, Contact };

        public RequestFormController(IRequestForm view)
        {
            this.view = view;
            this.view.SetController(this);
            this.request = new ProtocolRequest();
            loginInfo = LoginInfo.GetInstance();
            this.auditItems = new List<AuditItem>();
        }

        public void LoadView(ProtocolRequest protocolRequest)
        {
            this.request = protocolRequest;
            UpdateViewWithRequestValues();
        }

        protected void UpdateViewWithRequestValues()
        {
            this.view.RequestedBy = request.RequestedBy;
            this.view.RequestedDate = request.RequestedDate.ToString("MM/dd/yyyy");
            this.view.Guidelines = request.Guidelines;
            this.view.Compliance = request.Compliance;
            this.view.ProtocolType = request.ProtocolType;
            this.view.BillTo = request.BillTo;
            this.view.Cost = request.Cost;
            this.view.PONumber = request.PO;
            this.view.SendVia = request.SendVia;
            this.view.DueDate = request.DueDate;
            this.view.Comments = request.Comments;
            this.view.AssignedTo = request.AssignedTo.FullName;

            UpdateViewWithSponsorContact();
        }

        protected void UpdateViewWithSponsorContact()
        {
            this.view.ContactName = request.Contact.ContactName;
            this.view.SponsorName = request.Contact.SponsorName;
            this.view.Email = request.Contact.Email;
            this.view.Address = request.Contact.Address;
            this.view.City = request.Contact.City;
            this.view.State = request.Contact.State;
            this.view.ZipCode = request.Contact.ZipCode;
            this.view.PhoneNumber = request.Contact.PhoneNumber;
            this.view.FaxNumber = request.Contact.FaxNumber;
            this.view.PONumber = request.Contact.PONumber;
        }

        public void UpdateRequestWithViewValues()
        {
            CreateTextBoxAuditItems();
            this.request.DueDate = this.view.DueDate;
            this.request.SendVia = this.view.SendVia;
            this.request.BillTo = this.view.BillTo;
            this.request.Cost = this.view.Cost;
            this.request.PO = this.view.PONumber;
            this.request.Comments = this.view.Comments;
        }

        private void CheckAndAddToAuditItems(string fieldName, string oldValue, string newValue)
        {
            if(oldValue.Trim() != newValue.Trim())
            {
                AuditItem item = CreateAuditItem(fieldName, oldValue, newValue);
                this.auditItems.Add(item);
            }
        }

        private void CreateTextBoxAuditItems()
        {
            CheckAndAddToAuditItems("DueDate", this.request.DueDate.ToString("MM/dd/yyyy"), 
                                    this.view.DueDate.ToString("MM/dd/yyyy"));
            CheckAndAddToAuditItems("SendVia", this.request.SendVia, this.view.SendVia);
            CheckAndAddToAuditItems("BillTo", this.request.BillTo, this.view.BillTo);
            CheckAndAddToAuditItems("Cost", this.request.Cost, this.view.Cost);
            CheckAndAddToAuditItems("PO", this.request.PO, this.view.PONumber);
        }

        public void GuidelinesButtonClicked()
        {
            IList items = QListItems.SelectItems(OptionFields.Guidelines.ToString());
            List<string> selectedItems = TemplatesController.ShowCheckBoxOptionsForm(items, view.ParentControl);
            if (selectedItems.Count != 0)
            {
                string itemsString = String.Join(", ", selectedItems);
                CheckAndAddToAuditItems("Guidelines", this.request.Guidelines, itemsString);
                this.request.Guidelines = itemsString;
                this.view.Guidelines = itemsString;
            }
        }

        public void ContactButtonClicked()
        {
            IList items = new List<string>();//QMatrix.GetSponsorContacts();
            
        }

        public void ComplianceButtonClicked()
        {
            IList items = QListItems.SelectItems(OptionFields.Compliance.ToString());
            Item selectedItem = TemplatesController.ShowListBoxOptionsForm(items, view.ParentControl);
            if(selectedItem.Name != "")
            {
                CheckAndAddToAuditItems("Compliance", this.request.Guidelines, selectedItem.Value);
                this.request.Compliance = selectedItem.Value;
                this.view.Compliance = selectedItem.Value;
            }
        }

        public void ProtocolTypeButtonClicked()
        {
            IList items = QListItems.SelectItems(OptionFields.ProtocolType.ToString());
            Item selectedItem = TemplatesController.ShowListBoxOptionsForm(items, view.ParentControl);
            if (selectedItem.Value != "")
            {
                CheckAndAddToAuditItems("ProtocolType", this.request.ProtocolType, selectedItem.Value);
                this.request.ProtocolType = selectedItem.Value;
                this.view.ProtocolType = selectedItem.Value;
            }
        }

        public void AssignedToButtonClicked()
        {
            IList items = QUsers.SelectUsersByRoleID(UserRoles.DocControl);
            Item selectedItem = TemplatesController.ShowListBoxOptionsForm(items, view.ParentControl);
            if (selectedItem.Value != "")
            {
                CheckAndAddToAuditItems("AssignedTo", this.request.AssignedTo.FullName, selectedItem.Text);
                this.request.AssignedTo.UserName = selectedItem.Value;
                this.request.AssignedTo.FullName = selectedItem.Text;
                this.view.AssignedTo = selectedItem.Text;
            }
        }

        public void ChangeContactButtonClicked()
        {
            IList items = QMatrix.GetSponsorContacts_NameAndCodeOnly(this.request.Contact.SponsorName);
            Item selectedItem = TemplatesController.ShowListBoxOptionsForm(items, view.ParentControl);
            if (selectedItem.Value != "")
            {
                CheckAndAddToAuditItems("ContactCode", this.request.Contact.ContactCode, selectedItem.Value);
                this.request.SetContact(selectedItem.Value);
                UpdateViewWithSponsorContact();
            }
        }

        public void UpdateCommentsButtonClicked()
        {
            OneTextBoxForm popup = new OneTextBoxForm();
            OneTextBoxFormController popupController = new OneTextBoxFormController(popup);
            popupController.TextBoxLabel = "Comments";
            popupController.TextBoxValue = this.request.Comments;
            popupController.LoadView();
            if(popup.ShowDialog(this.view.ParentControl) == DialogResult.OK)
            {
                this.request.Comments = popupController.TextBoxValue;
                this.view.Comments = popupController.TextBoxValue;
                QProtocolRequests.UpdateRequestComments(request, loginInfo.UserName);
            }
            popup.Dispose();
        }

        public void SubmitRequest()
        {
            this.request.RequestStatus = RequestStatuses.New;
            this.request.ID = QProtocolRequests.InsertItem(this.request, loginInfo.UserName);
        }

        public void UpdateRequest()
        {
            QProtocolRequests.UpdateItem(this.request, loginInfo.UserName);
            SubmitAuditItems();
        }

        private void SubmitAuditItems()
        {
            if (auditItems.Count != 0)
            {
                AuditHandler.InsertAuditItems(auditItems);
                this.auditItems.Clear();
            }
        }

        public void ClearForm()
        {
            this.request.Refresh();
            this.view.ClearView();
        }

        private AuditItem CreateAuditItem(string fieldName, string oldValue, string newValue)
        {
            AuditItem item = new AuditItem();
            item.TableName = "ProtocolRequests";
            item.Type = "U";
            item.PK = "ID";
            item.PKValue = this.request.ID.ToString();
            item.FieldName = fieldName;
            item.OldValue = oldValue.Trim() == String.Empty ? "N/A" : oldValue;
            item.NewValue = newValue;
            item.UpdatedBy = loginInfo.UserName;
            item.Reason = "Update using Save Changes button.";

            return item;
        }
    }
}
