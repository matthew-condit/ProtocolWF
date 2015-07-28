using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.ProtocolManager.Controllers.Admin;
using Toxikon.ProtocolManager.Models;
using Toxikon.ProtocolManager.Models.Admin;

namespace Toxikon.ProtocolManager.Interfaces.Admin
{
    public interface IDepartmentDirectorsView
    {
        void SetController(DepartmentDirectorsController controller);
        void AddDepartmentToView(Department department);
        void AddDirectorsToView(Item director);
        void AddItemToListView(DepartmentDirector item);
        void ClearView();

        Control UCParentForm { get; }
    }
}
