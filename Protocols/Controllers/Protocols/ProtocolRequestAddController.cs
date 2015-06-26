using Toxikon.ProtocolManager.Interfaces.Protocols;
using Toxikon.ProtocolManager.Models;
using Toxikon.ProtocolManager.Queries;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace Toxikon.ProtocolManager.Controllers.Protocols
{
    public class ProtocolRequestAddController
    {
        IProtocolRequestAddView view;
        IList sponsorContacts;
        ProtocolRequest request;

        RequestFormController requestFormController;
        
        public ProtocolRequestAddController(IProtocolRequestAddView view)
        {
            this.view = view;
            this.view.SetController(this);
            this.sponsorContacts = new ArrayList();
            this.request = new ProtocolRequest();
            this.requestFormController = new RequestFormController(this.view.GetRequestForm);
        }

        public void LoadView()
        {
            InitProtocolRequest();
        }

        private void InitProtocolRequest()
        {
            LoginInfo loginInfo = LoginInfo.GetInstance();
            this.request.RequestedBy = loginInfo.FullName;
            this.request.RequestedDate = DateTime.Now;
        }

        public void SearchButtonClicked()
        {
            if(this.view.SearchSponsorName.Trim() == String.Empty)
            {
                MessageBox.Show("Sponsor name is required.");
            }
            else
            {
                DoSearch();
            }
        }

        private void DoSearch()
        {
            this.sponsorContacts.Clear();
            sponsorContacts = QMatrix.GetSponsorContacts(this.view.SearchSponsorName);
            if (sponsorContacts.Count == 0)
            {
                MessageBox.Show("No record found.");
            }
            else
            {
                this.view.ClearView();
                AddSponsorContactsToView();
            }
        }

        private void AddSponsorContactsToView()
        {
            foreach(SponsorContact contact in sponsorContacts)
            {
                this.view.AddSponsorContactToList(contact);
            }
        }

        public void ContactListViewSelectedIndexChanged(int selectedIndex)
        {
            if(selectedIndex >= 0 && selectedIndex < this.sponsorContacts.Count)
            {
                this.request.SetContact((SponsorContact)this.sponsorContacts[selectedIndex]);
                this.requestFormController.LoadView(this.request);
            }
        }

        public void SubmitButtonClicked()
        {
            UpdateRequestWithViewValues();
            if (this.request.Contact.SponsorCode == String.Empty)
            {
                MessageBox.Show("No sponsor selected.");
            }
            else if (this.request.AssignedTo == String.Empty)
            {
                MessageBox.Show("Assigned To is required.");
            }
            else
            {
                SubmitFormWithConfirmation();
            }
        }

        private void UpdateRequestWithViewValues()
        {
            this.requestFormController.UpdateRequestWithViewValues();
            this.request.SetTitles(this.view.Titles);
        }

        private void SubmitFormWithConfirmation()
        {
            DialogResult dialogResult = ShowConfirmation();
            if (dialogResult == DialogResult.Yes)
            {
                this.requestFormController.SubmitRequest();
                this.requestFormController.ClearForm();
                this.Clear();
                MessageBox.Show("Submitted!");
            }
        }

        private DialogResult ShowConfirmation()
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to submit the form?",
                "Confirmation",
                MessageBoxButtons.YesNo);
            return dialogResult;
        }

        private void Clear()
        {
            InitProtocolRequest();
            this.sponsorContacts.Clear();
            this.view.ClearView();
        }
    }
}
