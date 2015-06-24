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
    public interface IUserListView
    {
        void SetController(UserListController controller);
        void ClearView();
        void AddItemToListView(User user);

        Control ParentControl { get; }
    }
}
