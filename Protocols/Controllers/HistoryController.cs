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
        IList userList;
        IList requestList;
        Item selectedItem;
        ProtocolRequest selectedRequest;
        LoginInfo loginInfo;
        ProtocolRequestReadOnlyController requestViewController;

        enum SearchTypes { RequestedBy, AssignedTo };

        public HistoryController(IHistoryView view)
        {
            this.view = view;
            this.view.SetController(this);
            this.requestViewController = new ProtocolRequestReadOnlyController(this.view.GetRequestView);
            this.userList = new ArrayList();
            this.requestList = new ArrayList();
            this.loginInfo = LoginInfo.GetInstance();
        }

        public void LoadView()
        {
            SetUserList();
            Item customItem = new Item();
            customItem.Name = "RequestedBy";
            customItem.Text = "Bichngoc McCulley";
            customItem.Value = "bmcculley";
            this.userList.Add(customItem);
            if(this.userList.Count != 0)
            {
                AddUserListToView();
                this.view.SetRequestedByComboBox_SelectedIndex(0);
            }
        }

        private void SetUserList()
        {
            switch(loginInfo.Role.RoleID)
            {
                case UserRoles.IT:
                    this.userList = QUsers.SelectUsersByRoleID(UserRoles.CSR);
                    this.view.SearchLabelText = SearchTypes.RequestedBy.ToString();
                    break;
                case UserRoles.CSR:
                    this.userList = QUsers.SelectUsersByRoleID(UserRoles.DocControl);
                    this.view.SearchLabelText = SearchTypes.AssignedTo.ToString();
                    break;
                case UserRoles.DocControl:
                    this.userList = QUsers.SelectUsersByRoleID(UserRoles.CSR);
                    this.view.SearchLabelText = SearchTypes.RequestedBy.ToString();
                    break;
                default:
                    break;
            }
        }

        private void AddUserListToView()
        {
            foreach(Item item in userList)
            {
                this.view.AddItemToRequestedByComboBox(item);
            }
        }

        public void RequestedByComboBox_SelectedIndexChanged(int selectedIndex)
        {
            if(selectedIndex > -1 && selectedIndex < this.userList.Count)
            {
                this.selectedItem = this.userList[selectedIndex] as Item;
            }
        }

        public void SearchButtonClicked()
        {
            this.requestList.Clear();
            this.view.ClearListView();
            this.requestViewController.ClearView();
            if(this.selectedItem != null)
            {
                SetRequestList();
                AddRequestListToView();
            }
        }

        private void SetRequestList()
        {
            switch(loginInfo.Role.RoleID)
            {
                case UserRoles.IT:
                    this.requestList = QProtocolRequests.AdminSelectClosedRequests(this.selectedItem.Value);
                    break;
                case UserRoles.CSR:
                    this.requestList = QProtocolRequests.SelectClosedRequests(loginInfo.UserName, 
                                       this.selectedItem.Value);
                    break;
                case UserRoles.DocControl:
                    this.requestList = QProtocolRequests.SelectClosedRequests(this.selectedItem.Value, 
                                       loginInfo.UserName);
                    break;
                default:
                    break;
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
