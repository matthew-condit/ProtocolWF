using Protocols.Interfaces;
using Protocols.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocols.Controllers
{
    public class RequestDashboardController
    {
        IProtocolRequestDashboard view;
        IList requests;
        ProtocolRequest selectedRequest;

        public RequestDashboardController(IProtocolRequestDashboard view)
        {
            this.view = view;
            this.view.SetController(this);
            requests = new ArrayList();
            this.selectedRequest = null;
        }

        public void LoadView()
        {
            LoadRequests();
            AddRequestsToView();
        }

        private void LoadRequests()
        {

        }

        private void AddRequestsToView()
        {
            foreach (ProtocolRequest request in requests)
            {
                view.AddRequestToListView(request);
            }
        }

        public void RequestListSelectedIndexChanged(int selectedIndex)
        {
            if(selectedIndex > -1 && selectedIndex < this.requests.Count)
            {
                this.selectedRequest = (ProtocolRequest)this.requests[selectedIndex];
            }
            else
            {
                this.selectedRequest = null;
            }
        }
    }
}
