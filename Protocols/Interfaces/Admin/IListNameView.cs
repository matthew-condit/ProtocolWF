using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.ProtocolManager.Controllers.Admin;
using Toxikon.ProtocolManager.Models;

namespace Toxikon.ProtocolManager.Interfaces.Admin
{
    public interface IListNameView
    {
        void SetController(ListNameController controller);
        void AddItemToListView(Item item);
        void ClearView();

        Control ParentControl { get; }
    }
}
