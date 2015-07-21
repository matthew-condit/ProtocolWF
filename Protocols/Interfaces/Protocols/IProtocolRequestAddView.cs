using Toxikon.ProtocolManager.Controllers.Protocols;
using Toxikon.ProtocolManager.Models;
using Toxikon.ProtocolManager.Views.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toxikon.ProtocolManager.Views.RequestForms;
using System.Windows.Forms;

namespace Toxikon.ProtocolManager.Interfaces.Protocols
{
    public interface IProtocolRequestAddView
    {
        void SetController(ProtocolRequestAddController controller);
        void AddItemToDataGrid(Template item);
        void ClearView();

        string SearchSponsorName { get; set; }
        RequestFormAdd GetRequestForm { get; }
        Control ParentControl { get; }
    }
}
