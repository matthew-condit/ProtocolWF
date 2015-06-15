using Protocols.Controllers;
using Protocols.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocols.Interfaces
{
    public interface IProtocolRequestDashboard
    {
        void SetController(RequestDashboardController controller);
        void AddRequestToListView(ProtocolRequest request);
    }
}
