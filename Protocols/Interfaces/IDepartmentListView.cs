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
    public interface IDepartmentListView
    {
        void SetController(DepartmentListController controller);
        void AddItemToListView(Department department);
        void ClearView();

        Control ParentControl { get; }
    }
}
