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
        IList sponsors;
        ProtocolRequest request;

        RequestFormController requestFormController;
        
        public ProtocolRequestAddController(IProtocolRequestAddView view)
        {
            this.view = view;
            this.view.SetController(this);
            this.sponsors = new ArrayList();
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
                sponsors = QMatrix.GetSponsorInfo(this.view.SearchSponsorName);
                if(sponsors.Count == 0)
                {
                    MessageBox.Show("No record found.");
                }
                else
                {
                    AddSponsorsToView();
                }
            }
        }

        private void AddSponsorsToView()
        {
            foreach(Sponsor sponsor in sponsors)
            {
                this.view.AddSponsorToSearchResultList(sponsor);
            }
        }

        public void SponsorListViewSelectedIndexChanged(int selectedIndex)
        {
            if(selectedIndex >= 0 && selectedIndex < this.sponsors.Count)
            {
                this.request.SetSponsor((Sponsor)this.sponsors[selectedIndex]);
                this.requestFormController.LoadView(this.request);
            }
        }

        public void SubmitButtonClicked()
        {
            this.requestFormController.UpdateRequestWithViewValues();
            if (this.request.Sponsor.SponsorCode == String.Empty)
            {
                MessageBox.Show("No sponsor selected.");
            }
            else if (this.request.AssignedTo == String.Empty)
            {
                MessageBox.Show("Please fill in all required fields.");
            }
            else
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
            this.sponsors.Clear();
            this.view.ClearView();
        }
    }
}
