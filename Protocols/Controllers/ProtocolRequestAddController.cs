using Protocols.Interfaces;
using Protocols.Models;
using Protocols.Queries;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace Protocols.Controllers
{
    public class ProtocolRequestAddController
    {
        IProtocolRequestAddView view;
        IList sponsors;
        Sponsor selectedSponsor;

        ProtocolRequestDetailController protocolRequestDetailController;
        
        public ProtocolRequestAddController(IProtocolRequestAddView view)
        {
            this.view = view;
            this.view.SetController(this);
            this.sponsors = new ArrayList();
            selectedSponsor = null;
            this.protocolRequestDetailController = new ProtocolRequestDetailController(
                    this.view.GetProtocolRequestDetailView);
            this.protocolRequestDetailController.SubmitButtonClickDelegate = new
                ProtocolRequestDetailController.SubmitButtonClick(this.ProtocolRequestDetail_SubmitButtonClicked);
        }

        public void LoadView()
        {

        }

        public void SearchButtonClicked()
        {
            if(this.view.SearchSponsorName.Trim() == String.Empty)
            {
                MessageBox.Show("Sponsor name is required.");
            }
            else
            {
                sponsors = MatrixQueries.GetSponsorInfo(this.view.SearchSponsorName);
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
                selectedSponsor = (Sponsor)this.sponsors[selectedIndex];
                UpdateViewWithSelectedSponsor();
            }
        }

        private void UpdateViewWithSelectedSponsor()
        {
            this.protocolRequestDetailController.LoadView(this.selectedSponsor);
        }

        private void ProtocolRequestDetail_SubmitButtonClicked()
        {
            this.selectedSponsor = null;
            this.sponsors.Clear();
            this.view.ClearView();
        }
    }
}
