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

namespace Protocols.Controllers
{
    public class DashboardController
    {
        IDashboardView view;
        IList protocolRequests;

        public DashboardController(IDashboardView view)
        {
            this.view = view;
            this.view.SetController(this);
            this.protocolRequests = new ArrayList();
        }

        public void LoadView()
        {
            LoadProtocolRequestsByUserRole();
            LoadProtocolTitles();
            AddProtocolRequestsToView();
        }

        private void LoadProtocolRequestsByUserRole()
        {
            LoginInfo loginInfo = LoginInfo.GetInstance();
            switch(loginInfo.Role.RoleID)
            {
                case 1:
                    this.protocolRequests = QProtocolRequests.GetActiveProtocolRequests();
                    break;
                case 2:
                    this.protocolRequests = QProtocolRequests.SelectProtocolRequestByRequestedBy(loginInfo.UserName);
                    break;
                case 3:
                    this.protocolRequests = QProtocolRequests.SelectProtocolRequestByAssignedTo(loginInfo.UserName);
                    break;
                default:
                    break;
            }
        }

        private void LoadProtocolTitles()
        {
            foreach (ProtocolRequest request in protocolRequests)
            {
                request.SetTitles((List<ProtocolTitle>)QProtocolTitles.SelectByRequestID(request.ID));
            }
        }

        private void AddProtocolRequestsToView()
        {
            foreach(ProtocolRequest request in protocolRequests)
            {
                this.view.AddProtocolRequestToView(request);
            }
        }

        public void RequestDataGridViewCellDoubleClicked(int selectedIndex)
        {
            ProtocolRequest request = (ProtocolRequest)this.protocolRequests[selectedIndex];

            MainView mainView = (MainView)this.view.ParentControl;
            mainView.Invoke(mainView.LoadProtocolRequestViewDelegate, new object[] { request });
        }

        public void CheckBoxCellClicked(string colName, int rowIndex, bool isChecked)
        {
            ProtocolRequest request = this.protocolRequests[rowIndex] as ProtocolRequest;
            switch(colName)
            {
                case "ReceivedCol":
                    request.Workflow.Received = isChecked;
                    break;
                case "InProcessCol":
                    request.Workflow.InProcess = isChecked;
                    break;
                case "CompletedCol":
                    request.Workflow.Completed = isChecked;
                    break;
                case "CancelledCol":
                    request.Workflow.Cancelled = isChecked;
                    break;
                default:
                    break;
            }
            this.view.SetDataGridViewCheckBoxCell_BackColor(request, rowIndex);
        }
    }
}
