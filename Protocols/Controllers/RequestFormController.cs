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

            this.view.ContactName = request.Sponsor.SponsorContact;
            this.view.SponsorName = request.Sponsor.SponsorName;
            this.view.Email = request.Sponsor.Email;
            this.view.Address = request.Sponsor.Address;
            this.view.City = request.Sponsor.City;
            this.view.State = request.Sponsor.State;
            this.view.ZipCode = request.Sponsor.ZipCode;
            this.view.PhoneNumber = request.Sponsor.PhoneNumber;
            this.view.FaxNumber = request.Sponsor.FaxNumber;
            this.view.PONumber = request.Sponsor.PONumber;
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
                    string[] splits = items.Split('-');
                    this.request.AssignedTo = splits[1];
                    this.view.AssignedTo = this.request.AssignedTo;
                    break;
                default:
                    break;
            }
        }

        public void SubmitRequest()
        {
            UpdateRequestWithViewValues();
            //this.request.ID = QProtocolRequests.InsertProtocolRequest(this.request, loginInfo.UserName);
        }

        public void UpdateRequest()
        {
            UpdateRequestWithViewValues();
            QProtocolRequests.Update(this.request, loginInfo.UserName);
        }

        public void ClearForm()
        {
            this.request.Refresh();
            this.view.ClearView();
        }
    }
}
