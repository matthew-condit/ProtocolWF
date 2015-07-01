using Toxikon.ProtocolManager.Controllers.Templates;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Toxikon.ProtocolManager.Interfaces.Templates
{
    public interface IListBoxForm
    {
        void SetController(ListBoxOptionsController controller);
        void AddItemToListBox(string item);
        void SetDialogResult(DialogResult dialogResult);
    }
}
