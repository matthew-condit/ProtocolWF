using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toxikon.ProtocolManager.Controllers.Protocols;
using Toxikon.ProtocolManager.Interfaces;
using Toxikon.ProtocolManager.Models;
using Toxikon.ProtocolManager.Queries;

namespace Toxikon.ProtocolManager.Controllers
{
    public class HistoryController
    {
        IHistoryView view;
        IList requestedByList;
        IList requestList;
        ListItem selectedItem;
        ProtocolRequest selectedRequest;
        LoginInfo loginInfo;
        ProtocolRequestReadOnlyController requestViewController;

        public HistoryController(IHistoryView view)
        {
            this.view = view;
            this.view.SetController(this);
            this.requestViewController = new ProtocolRequestReadOnlyController(this.view.GetRequestView);
            this.requestedByList = new ArrayList();
            this.requestList = new ArrayList();
            this.loginInfo = LoginInfo.GetInstance();
        }

        public void LoadView()
        {
            this.requestedByList = QUsers.GetUsersByRoleID(2, ListNames.RequestedBy);
            if(this.requestedByList.Count != 0)
            {
                AddRequestedByListToView();
                this.view.SetRequestedByComboBox_SelectedIndex(0);
            }
        }

        private void AddRequestedByListToView()
        {
            foreach(ListItem item in requestedByList)
            {
                this.view.AddItemToRequestedByComboBox(item);
            }
        }

        public void RequestedByComboBox_SelectedIndexChanged(int selectedIndex)
        {
            if(selectedIndex > -1 && selectedIndex < this.requestedByList.Count)
            {
                this.selectedItem = this.requestedByList[selectedIndex] as ListItem;
            }
        }

        public void SearchButtonClicked()
        {
            if(this.selectedItem != null)
            {
                string[] splits = this.selectedItem.ItemName.Split('-');
                string userName = splits[1];
                this.requestList = QProtocolRequests.SelectProtocolRequestByRequestedBy(userName);
                AddRequestListToView();
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
