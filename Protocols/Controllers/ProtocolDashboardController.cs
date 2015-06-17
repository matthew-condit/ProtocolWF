using Protocols.Interfaces;
using Protocols.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocols.Controllers
{
    public class ProtocolDashboardController
    {
        IProtocolDashboardView view;
        List<Protocol> protocols;

        public ProtocolDashboardController(IProtocolDashboardView view)
        {
            this.view = view;
            this.view.SetController(this);
            this.protocols = new List<Protocol>() { };
        }

        public void LoadView()
        {
            AddProtocolsToView();
        }
        private void AddProtocolsToView()
        {
            foreach(Protocol protocol in protocols)
            {
                this.view.AddProtocolToDataGridView(protocol);
            }
        }
    }
}
