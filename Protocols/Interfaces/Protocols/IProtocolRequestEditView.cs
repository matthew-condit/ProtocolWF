using Toxikon.ProtocolManager.Controllers.Protocols;
using Toxikon.ProtocolManager.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.ProtocolManager.Views.RequestForms;

namespace Toxikon.ProtocolManager.Interfaces.Protocols
{
    public interface IProtocolRequestEditView
    {
        void SetController(ProtocolRequestEditController controller);
        void AddTitleToView(ProtocolTemplate title);
        void SetListViewAutoResizeColumns();
        void ClearProtocolTitleListView();
        void ClearView();

        RequestFormEdit GetRequestForm { get; }
        IList SelectedTitleIndexes { get; }

        Control ParentControl { get; }
    }
}
