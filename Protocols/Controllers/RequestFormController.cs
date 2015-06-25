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

namespace Toxikon.ProtocolManager.Controllers
{
    public class RequestFormController
    {
        protected IRequestForm view;
        protected ProtocolRequest request;
        LoginInfo loginInfo;

        public RequestFormController(IRequestForm view)
        {
            this.view = view;
            this.view.SetController(this);
            this.request = new ProtocolRequest();
            loginInfo = LoginInfo.GetInstance();
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
            this.view.SendVia = request.SendVia;
            this.view.DueDate = request.DueDate;
            this.view.Comments = request.Comments;
            this.view.AssignedTo = request.AssignedTo;

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
            this.request.Guidelines = this.view.Guidelines;
            this.request.Compliance = this.view.Compliance;
            this.request.ProtocolType = this.view.ProtocolType;
            this.request.DueDate = this.view.DueDate;
            this.request.SendVia = this.view.SendVia;
            this.request.BillTo = this.view.BillTo;
            this.request.Comments = this.view.Comments;
            this.request.AssignedTo = this.view.AssignedTo;
        }

        public void ChangeContactButtonClicked()
        {
            IList contacts = QMatrix.GetSponsorContacts_NameAndCodeOnly(this.request.Contact.SponsorName);
            OpenListBoxOptions(ListNames.Contact, contacts);
        }

        public void OpenCheckBoxOptions(string listName, IList items)
        {
            CheckBoxOptionsView popup = new CheckBoxOptionsView();
            CheckBoxOptionsController popupController = new CheckBoxOptionsController(popup, items);
            popupController.LoadView();

            DialogResult dialogResult = popup.ShowDialog(this.view.ParentControl);
            if (dialogResult == DialogResult.OK)
            {
                string itemsString = String.Join(", ", popupController.SelectedItems);
                SetListSelectedItems(listName, itemsString);
            }
            popup.Dispose();
        }

        public void OpenListBoxOptions(string listName, IList items)
        {
            ListBoxOptionsView popup = new ListBoxOptionsView();
            ListBoxOptionsController popupController = new ListBoxOptionsController(popup, items);
            popupController.LoadView();

            DialogResult dialogResult = popup.ShowDialog(this.view.ParentControl);
            if (dialogResult == DialogResult.OK)
            {
                SetListSelectedItems(listName, popupController.SelectedItem);
            }
            popup.Dispose();
        }

        private void SetListSelectedItems(string listName, string items)
        {
            switch (listName)
            {
                case ListNames.Guidelines:
                    this.request.Guidelines = items;
                    this.view.Guidelines = items;
                    break;
                case ListNames.Compliance:
                    this.request.Compliance = items;
                    this.view.Compliance = items;
                    break;
                case ListNames.ProtocolType:
                    this.request.ProtocolType = items;
                    this.view.ProtocolType = items;
                    break;
                case ListNames.AssignedTo:
                    string[] splits1 = items.Split('-');
                    this.request.AssignedTo = splits1[1];
                    this.view.AssignedTo = this.request.AssignedTo;
                    break;
                case ListNames.Contact:
                    string[] splits2 = items.Split('-');
                    this.request.SetContact(splits2[1]);
                    UpdateViewWithSponsorContact();
                    break;
                default:
                    break;
            }
        }

        public void SubmitRequest()
        {
            this.request.RequestStatus = RequestStatuses.New;
            Debug.WriteLine(this.request.Titles.Count);
            this.request.ID = QProtocolRequests.InsertProtocolRequest(this.request, loginInfo.UserName);
            if (this.request.Titles.Count > 0)
            {
                QProtocolTitles.InsertFromProtocolRequest(this.request, loginInfo.UserName);
            }
            QProtocolActivities.InsertFromProtocolRequest(this.request, loginInfo.UserName);
        }

        public void UpdateRequest()
        {
            QProtocolRequests.Update(this.request, loginInfo.UserName);
        }

        public void ClearForm()
        {
            this.request.Refresh();
            this.view.ClearView();
        }
    }
}
