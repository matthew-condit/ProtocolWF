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
        ListItem selectedItem;
        ProtocolRequest selectedRequest;
        LoginInfo loginInfo;
        ProtocolRequestReadOnlyController requestViewController;

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
            ListItem customItem = new ListItem();
            customItem.ListName = ListNames.RequestedBy;
            customItem.ItemName = "Bichngoc McCulley-bmcculley";
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
                    this.userList = QUsers.GetUsersByRoleID(UserRoles.CSR, ListNames.RequestedBy);
                    this.view.SearchLableText = ListNames.RequestedBy;
                    break;
                case UserRoles.CSR:
                    this.userList = QUsers.GetUsersByRoleID(UserRoles.DocControl, ListNames.AssignedTo);
                    this.view.SearchLableText = ListNames.AssignedTo;
                    break;
                case UserRoles.DocControl:
                    this.userList = QUsers.GetUsersByRoleID(UserRoles.CSR, ListNames.RequestedBy);
                    this.view.SearchLableText = ListNames.RequestedBy;
                    break;
                default:
                    break;
            }
        }

        private void AddUserListToView()
        {
            foreach(ListItem item in userList)
            {
                this.view.AddItemToRequestedByComboBox(item);
            }
        }

        public void RequestedByComboBox_SelectedIndexChanged(int selectedIndex)
        {
            if(selectedIndex > -1 && selectedIndex < this.userList.Count)
            {
                this.selectedItem = this.userList[selectedIndex] as ListItem;
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
            string[] splits = this.selectedItem.ItemName.Split('-');
            string userName = splits[1];
            switch(loginInfo.Role.RoleID)
            {
                case UserRoles.IT:
                    this.requestList = QProtocolRequests.AdminSelectClosedRequests(userName);
                    break;
                case UserRoles.CSR:
                    this.requestList = QProtocolRequests.SelectClosedRequests(loginInfo.UserName, userName);
                    break;
                case UserRoles.DocControl:
                    this.requestList = QProtocolRequests.SelectClosedRequests(userName, loginInfo.UserName);
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
