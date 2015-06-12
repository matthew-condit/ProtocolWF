using Protocols.Interfaces;
using Protocols.Models;
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

        public delegate void SubmitButtonClick();
        public SubmitButtonClick SubmitButtonClickDelegate;

        public ProtocolRequestDetailController(IProtocolRequestDetailView view)
        {
            this.view = view;
            this.view.SetController(this);
            InitProtocolRequest();
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

    }
}
