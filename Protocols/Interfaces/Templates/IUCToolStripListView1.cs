using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.ProtocolManager.Controllers.Templates;

namespace Toxikon.ProtocolManager.Interfaces.Templates
{
    public interface IUCToolStripListView1
    {
        void SetController(UCToolStripListView1Controller controller);
        void AddListViewColumns(IList columns);
        void AddItemToListView(object item);
        void SetListViewAutoResizeColumns(int columnIndex, ColumnHeaderAutoResizeStyle style);
        void ClearView();

        string ListTitle { get; set; }
        Control ParentControl { get; }
    }
}
