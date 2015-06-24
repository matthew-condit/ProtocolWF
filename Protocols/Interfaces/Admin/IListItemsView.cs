using Toxikon.ProtocolManager.Controllers.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toxikon.ProtocolManager.Interfaces.Admin
{
    public interface IListItemsView
    {
        void SetController(ListItemsController controller);
        void AddListNameToView(string listName);
        void AddListItemToView(string listItem);
        void ClearListItems();
        void ClearNewItemTextBox();

        string ItemName { get; set; }
    }
}
