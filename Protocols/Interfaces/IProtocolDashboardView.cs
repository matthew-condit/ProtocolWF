using Protocols.Controllers;
using Protocols.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocols.Interfaces
{
    public interface IProtocolDashboardView
    {
        void SetController(ProtocolDashboardController controller);
        void AddProtocolToDataGridView(Protocol protocol);
    }
}
