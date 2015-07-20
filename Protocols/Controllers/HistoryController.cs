using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.ProtocolManager.Controllers.Protocols;
using Toxikon.ProtocolManager.Interfaces;
using Toxikon.ProtocolManager.Models;
using Toxikon.ProtocolManager.Queries;

namespace Toxikon.ProtocolManager.Controllers
{
    public class HistoryController
    {
        IHistoryView view;
        IList sponsors;
        IList requestList;
        Item selectedItem;
        ProtocolRequest selectedRequest;
        LoginInfo loginInfo;
        RequestDetailController requestViewController;

        public HistoryController(IHistoryView view)
        {
            this.view = view;
            this.view.SetController(this);
            this.requestViewController = new RequestDetailController(this.view.GetRequestView);
            this.requestList = new ArrayList();
            this.sponsors = new ArrayList();
            this.loginInfo = LoginInfo.GetInstance();
        }

        public void LoadView()
        {
            
        }

        public void SearchButtonClicked()
        {
            this.Clear();
            GetSponsors();
            GetSelectedSponsorRequests();
            AddRequestListToView();
        }

        private void Clear()
        {
            this.selectedItem = null;
            this.sponsors.Clear();
            this.requestList.Clear();
            this.view.ClearListView();
            this.requestViewController.ClearView();
        }

        private void GetSponsors()
        {
            sponsors = QProtocolRequests.GetSponsorCodes(RequestStatuses.Closed);
            QMatrix.GetSponsorNames(sponsors);
        }

        private void GetSelectedSponsorRequests()
        {
            if(this.sponsors.Count != 0)
            {
                this.selectedItem = TemplatesController.ShowListBoxOptionsForm(this.sponsors, 
                                    this.view.ParentControl);
                GetRequests();
            }
            else
            {
                MessageBox.Show("No records found.");
            }
        }

        private void GetRequests()
        {
            if(this.selectedItem != null)
            {
                this.requestList = QProtocolRequests.GetProtocolRequests_BySponsorCode(this.selectedItem.Name);
            }
        }

        private void AddRequestListToView()
        {
            foreach(ProtocolRequest request in this.requestList)
            {
                this.view.AddItemToListView(request);
            }
        }

        public void RequestListView_SelectedIndexChanged(int selectedIndex)
        {
            if(selectedIndex > -1 && selectedIndex < this.requestList.Count)
            {
                this.selectedRequest = (ProtocolRequest)this.requestList[selectedIndex];
                this.requestViewController.LoadView(this.selectedRequest);
            }
        }
    }
}
