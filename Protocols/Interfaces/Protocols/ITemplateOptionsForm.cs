using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.ProtocolManager.Controllers;
using Toxikon.ProtocolManager.Models;

namespace Toxikon.ProtocolManager.Interfaces.Protocols
{
    public interface ITemplateOptionsForm
    {
        void SetController(Controller controller);
        void AddItemToListBox1(Item item);
        void AddItemToListBox2(Template item);
        void ClearListBox2();
        void SetDialogResult(DialogResult dialogResult);

        string CustomTemplate { get; set; }
    }
}
