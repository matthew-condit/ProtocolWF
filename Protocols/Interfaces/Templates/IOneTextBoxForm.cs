using Toxikon.ProtocolManager.Controllers.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Toxikon.ProtocolManager.Interfaces.Templates
{
    public interface IOneTextBoxForm
    {
        void SetController(OneTextBoxFormController controller);
        void SetDialogResult(DialogResult dialogResult);

        string TextBoxLabel { get; set; }
        string TextBoxValue { get; set; }
    }
}
