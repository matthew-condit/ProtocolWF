using Toxikon.ProtocolManager.Controllers;
using Toxikon.ProtocolManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Toxikon.ProtocolManager.Interfaces
{
    public interface IDashboardView
    {
        void SetController(DashboardController controller);
        void AddProtocolRequestToView(ProtocolRequest request);
        Control ParentControl { get; }
    }
}
