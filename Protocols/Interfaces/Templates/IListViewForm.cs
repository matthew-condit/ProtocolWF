using Toxikon.ProtocolManager.Controllers.Templates;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toxikon.ProtocolManager.Interfaces.Templates
{
    public interface IListViewForm
    {
        void SetController(ListViewPopupController controller);
        void AddListViewColumns(IList columns);
        void AddItemToListView(object item);
        void SetListViewAutoResizeColumns();
    }
}
