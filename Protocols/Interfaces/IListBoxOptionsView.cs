using Protocols.Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Protocols.Interfaces
{
    public interface IListBoxOptionsView
    {
        void SetController(ListBoxOptionsController controller);
        void AddItemToListBox(string item);
        void SetDialogResult(DialogResult dialogResult);
    }
}
