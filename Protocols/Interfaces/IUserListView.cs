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
    public interface IUserListView
    {
        void SetController(UserListController controller);
        void ClearView();
        void AddItemToListView(User user);

        Control ParentControl { get; }
    }
}
