using Protocols.Controllers;
using Protocols.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Protocols.Interfaces
{
    public interface IDashboardView
    {
        void SetController(DashboardController controller);
        //void AddProtocolRequestToView(ProtocolRequest request);
        void AddProtocolToView(Protocol protocol);
        Control ParentControl { get; }
    }
}
