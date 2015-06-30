using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.ProtocolManager.Controllers.Templates;

namespace Toxikon.ProtocolManager.Interfaces.Templates
{
    public interface IOneTextBoxTrueFalseForm
    {
        void SetController(OneTextBoxTrueFalseFormController controller);
        void SetTrueFalseRadioButtonGroup_Enable(bool value);
        void SetDialogResult(DialogResult dialogResult);

        string TextBoxLabel { get; set; }
        string TextBoxValue { get; set; }
        string TrueFalseLabel { get; set; }
        bool TrueFalseValue { get; set; }
    }
}
