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
        IList protocols;

        public DashboardController(IDashboardView view)
        {
            this.view = view;
            this.view.SetController(this);
            this.protocolRequests = new ArrayList();
            this.protocols = new ArrayList();
        }

        public void LoadView()
        {
            this.protocolRequests = QProtocolRequests.GetActiveProtocolRequests();
            //this.protocols = QProtocols.GetInProcessProtocols();
            LoadProtocolTitles();
            //LoadRequestComments();
            AddProtocolRequestsToView();
            //AddProtocolsToView();
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

        private void AddProtocolsToView()
        {
            foreach(Protocol protocol in protocols)
            {
                this.view.AddProtocolToView(protocol);
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
