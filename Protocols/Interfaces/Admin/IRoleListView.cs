using Toxikon.ProtocolManager.Controllers.Admin;
using Toxikon.ProtocolManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Toxikon.ProtocolManager.Interfaces.Admin
{
    public interface IRoleListView
    {
        void SetController(RoleListController controller);
        void ClearView();
        void AddItemToListView(Role role);

        Control ParentControl { get; }
    }
}
