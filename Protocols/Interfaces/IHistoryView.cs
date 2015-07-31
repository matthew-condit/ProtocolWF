using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.ProtocolManager.Controllers;
using Toxikon.ProtocolManager.Models;
using Toxikon.ProtocolManager.Views.Protocols;

namespace Toxikon.ProtocolManager.Interfaces
{
    public interface IHistoryView
    {
        void SetController(HistoryController controller);
        void SetResetRequestVisible(bool value);
        void AddItemToListView(ProtocolRequest request);
        void ClearListView();

        ProtocolRequestReadOnlyView GetRequestView { get; }
        Control ParentControl { get; }
    }
}
