using Toxikon.ProtocolManager.Controllers.Protocols;
using Toxikon.ProtocolManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Toxikon.ProtocolManager.Interfaces.Protocols
{
    public interface IProtocolEventsView
    {
        void SetController(ProtocolEventsController controller);
        void ClearView();
        void AddItemToListView(ProtocolEvent protocolEvent);

        Control ParentControl { get; }
    }
}
