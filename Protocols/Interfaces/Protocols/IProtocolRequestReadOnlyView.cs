using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.ProtocolManager.Controllers.Protocols;
using Toxikon.ProtocolManager.Models;
using Toxikon.ProtocolManager.Views.RequestForms;

namespace Toxikon.ProtocolManager.Interfaces.Protocols
{
    public interface IProtocolRequestReadOnlyView
    {
        void SetController(ProtocolRequestReadOnlyController controller);
        void AddTitleToView(ProtocolTemplate title);
        void SetListViewAutoResizeColumns();
        void ClearProtocolTitleListView();
        void ClearView();

        RequestFormReadOnly GetRequestForm { get; }
        IList SelectedTitleIndexes { get; }

        Control ParentControl { get; }
    }
}
