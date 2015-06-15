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
    public interface ICheckBoxOptionsView
    {
        void SetController(CheckBoxOptionsController controller);
        void AddItemToList(string item);
        void SetDialogResult(DialogResult dialogResult);

        IList SelectedItems { get; }
    }
}
