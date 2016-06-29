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
using Toxikon.ProtocolManager.Models.Admin;
using Toxikon.ProtocolManager.Queries;

namespace Toxikon.ProtocolManager.Controllers
{
    public class HistoryController
    {
        IHistoryView view;
        IList sponsors;
        IList sortedsponsors;
        IList requestList;
        Item selectedItem;
        ProtocolRequest selectedRequest;
        LoginInfo loginInfo;
        RequestDetailController requestViewController;


        public class mysortclass : IComparer
        {
            int IComparer.Compare(Object x, Object y)
            {
                Item sponsorA = (Item)x;
                Item sponsorB = (Item)y;
                return String.Compare(sponsorA.Text, sponsorB.Text);
            }
        }
        public static IComparer sortalpha() {
            return (IComparer) new mysortclass();
        }

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
            if(loginInfo.Role.RoleID == UserRoles.DocControl ||
               loginInfo.Role.RoleID == UserRoles.IT)
            {
                this.view.SetResetRequestVisible(true);
            }
            else
            {
                this.view.SetResetRequestVisible(false);
            }
        }

        public void SearchButtonClicked()
        {
            this.Clear();
            GetSponsors();
            GetSelectedSponsorRequests();
            AddRequestListToView();
        }

        public void ResetButtonClicked()
        {
            if(this.selectedRequest == null)
            {
                MessageBox.Show("Please select an item.");
            }
            else
            {
                ResetRequestWithConfirmation();
            }
        }

        private void ResetRequestWithConfirmation()
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to reset this request?",
                                        "Confirmation", MessageBoxButtons.YesNo);
            if(dialogResult == DialogResult.Yes)
            {
                this.selectedRequest.RequestStatus = "New";
                this.selectedRequest.IsActive = true;
                QProtocolRequests.UpdateRequestStatus(this.selectedRequest, loginInfo.UserName);

                AuditItem auditItem = CreateAuditItem("RequestStatus,IsActive", "Closed,0", "New,1");
                AuditHandler.InsertAuditItem(auditItem);
                this.requestList.Remove(this.selectedRequest);
                this.selectedRequest = null;
                ReloadRequestList();
            }
        }

        private void ReloadRequestList()
        {
            this.view.ClearListView();
            this.AddRequestListToView();
            this.requestViewController.ClearListView();
            this.requestViewController.ClearRequestForm();
        }

        private AuditItem CreateAuditItem(string fieldName, string oldValue, string newValue)
        {
            AuditItem item = new AuditItem();
            item.TableName = "ProtocolRequests";
            item.Type = "U";
            item.PK = "ID";
            item.PKValue = this.selectedRequest.ID.ToString();
            item.FieldName = fieldName;
            item.OldValue = oldValue.Trim() == String.Empty ? "N/A" : oldValue;
            item.NewValue = newValue;
            item.UpdatedBy = loginInfo.UserName;
            item.Reason = "Reset request in History page.";

            return item;
        }

        private void Clear()
        {
            this.selectedItem = null;
            this.sponsors.Clear();
            this.requestList.Clear();
            this.view.ClearListView();
            this.requestViewController.ClearListView();
            this.requestViewController.ClearRequestForm();
        }

        private void GetSponsors()
        {
            sponsors = QProtocolRequests.GetSponsorCodes(RequestStatuses.Closed);
            QMatrix.GetSponsorNames(sponsors);
            ArrayList sortedsponsors = new ArrayList(sponsors);
            sortedsponsors.Sort(HistoryController.sortalpha());
            this.sortedsponsors = sortedsponsors;
        }


        private void GetSelectedSponsorRequests()
        {
            if(this.sponsors.Count != 0)
            {
                this.selectedItem = TemplatesController.ShowListBoxOptionsForm(this.sortedsponsors, 
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
                this.requestViewController.LoadView(this.selectedRequest, RequestFormTypes.ReadOnly);
            }
        }
    }
}
