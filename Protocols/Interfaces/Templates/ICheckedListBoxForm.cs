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
    public interface ICheckedListBoxForm
    {
        void SetController(CheckBoxOptionsController controller);
        void AddItemToList(string item);
        void SetDialogResult(DialogResult dialogResult);

        IList SelectedItems { get; }
        IList SelectedIndices { get; }
    }
}
