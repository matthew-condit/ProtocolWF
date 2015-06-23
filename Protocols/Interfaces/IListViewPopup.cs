using Protocols.Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocols.Interfaces
{
    public interface IListViewPopup
    {
        void SetController(ListViewPopupController controller);
        void AddListViewColumns(IList columns);
        void AddItemToListView(object item);
        void SetListViewAutoResizeColumns();
    }
}
