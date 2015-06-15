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
    public class ProtocolRequestDetailController
    {
        IProtocolRequestDetailView view;
        Sponsor sponsor;
        ProtocolRequest protocolRequest;
        IList guildlinesList;
        IList complianceList;
        IList protocolTypeList;

        public delegate void SubmitButtonClick();
        public SubmitButtonClick SubmitButtonClickDelegate;

        public ProtocolRequestDetailController(IProtocolRequestDetailView view)
        {
            this.view = view;
            this.view.SetController(this);
            InitProtocolRequest();

            this.guildlinesList = new ArrayList();
            this.guildlinesList = QListItems.GetListItems(ListNames.Guidelines);
            this.complianceList = new ArrayList();
            this.complianceList = QListItems.GetListItems(ListNames.Compliance);
            this.protocolTypeList = new ArrayList();
            this.protocolTypeList = QListItems.GetListItems(ListNames.ProtocolType);
        }

        private void InitProtocolRequest()
        {
            if(this.protocolRequest == null)
            {
                protocolRequest = new ProtocolRequest();
            }
            else
            {
                protocolRequest.Refresh();
            }
            LoginInfo loginInfo = LoginInfo.GetInstance();
            protocolRequest.RequestedBy = loginInfo.FullName;
            protocolRequest.RequestedDate = DateTime.Now;
        }

        public void LoadView(Sponsor sponsor)
        {
            this.sponsor = new Sponsor(sponsor);
            protocolRequest.MatrixSponsorCode = sponsor.SponsorCode;
            UpdateViewWithProtocolRequest();
            UpdateViewWithSponsor();
        }

        private void UpdateViewWithProtocolRequest()
        {
            this.view.RequestedBy = protocolRequest.RequestedBy;
            this.view.RequestedDate = protocolRequest.RequestedDate.ToString("MM/dd/yyyy");
            this.view.BillTo = protocolRequest.BillTo;
        }

        private void UpdateViewWithSponsor()
        {
            this.view.ContactName = sponsor.SponsorContact;
            this.view.SponsorName = sponsor.SponsorName;
            this.view.Email = sponsor.Email;
            this.view.Address = sponsor.Address;
            this.view.City = sponsor.City;
            this.view.State = sponsor.State;
            this.view.ZipCode = sponsor.ZipCode;
            this.view.PhoneNumber = sponsor.PhoneNumber;
            this.view.FaxNumber = sponsor.FaxNumber;
            this.view.PONumber = sponsor.PONumber;
        }

        public void SubmitButtonClicked()
        {
            if(this.protocolRequest.MatrixSponsorCode == String.Empty)
            {
                MessageBox.Show("No sponsor selected.");
            }
            else
            {
                DialogResult dialogResult = ShowConfirmation();
                if(dialogResult == DialogResult.Yes)
                {
                    SubmitForm();
                    ClearForm();
                }
                
            }
        }

        private DialogResult ShowConfirmation()
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to submit the form?",
                "Confirmation",
                MessageBoxButtons.YesNo);
            return dialogResult;
        }

        private void SubmitForm()
        {
            UpdateProtocolRequestWithViewValues();
            SubmitProtocolRequestToDatabase();
        }

        private void ClearForm()
        {
            InitProtocolRequest();
            if (SubmitButtonClickDelegate != null)
            {
                this.SubmitButtonClickDelegate();
            }
        }

        private void UpdateProtocolRequestWithViewValues()
        {
            this.protocolRequest.RequestStatus = RequestStatuses.New;
            this.protocolRequest.Guidelines = this.view.Guidelines;
            this.protocolRequest.Compliance = this.view.Compliance;
            this.protocolRequest.ProtocolType = this.view.ProtocolType;
            this.protocolRequest.DueDate = this.view.DueDate;
            this.protocolRequest.SendMethod = this.view.SendVia;
            this.protocolRequest.BillTo = this.view.BillTo;
            this.protocolRequest.Comments.Add(this.view.Comments);
            this.protocolRequest.Titles = new List<string>(this.view.Titles);
        }

        private void SubmitProtocolRequestToDatabase()
        {
            
        }

        public void OpenCheckBoxOptions(string listName)
        {
            IList items = QListItems.GetListItems(listName);
            CheckBoxOptionsView popup = new CheckBoxOptionsView();
            CheckBoxOptionsController popupController = new CheckBoxOptionsController(popup, items);
            popupController.LoadView();

            DialogResult dialogResult = popup.ShowDialog(this.view.ParentControl);
            if(dialogResult == DialogResult.OK)
            {
                string itemsString = String.Join(", ", popupController.SelectedItems);
                AssignCheckBoxOptionsSelectedItems(listName, itemsString);
            }
            popup.Dispose();
        }

        private void AssignCheckBoxOptionsSelectedItems(string listName, string items)
        {
            switch(listName)
            {
                case ListNames.Guidelines:
                    this.protocolRequest.Guidelines = items;
                    this.view.Guidelines = items;
                    break;
                case ListNames.Compliance:
                    this.protocolRequest.Compliance = items;
                    this.view.Compliance = items;
                    break;
                case ListNames.ProtocolType:
                    this.protocolRequest.ProtocolType = items;
                    this.view.ProtocolType = items;
                    break;
                default:
                    break;
            }
        }
    }
}
