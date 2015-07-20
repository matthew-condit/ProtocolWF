using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.ProtocolManager.Controllers.Templates;

namespace Toxikon.ProtocolManager.Interfaces.Templates
{
    public interface ITwoTextBoxTrueFalseForm
    {
        void SetController(TwoTextBoxTrueFalseFormController controller);
        void SetTrueFalseRadioButtonGroup_Enable(bool value);
        void SetDialogResult(DialogResult dialogResult);

        string Label1Text { get; set; }
        string Label2Text { get; set; }
        string Label3Text { get; set; }

        string TextBox1Text { get; set; }
        string TextBox2Text { get; set; }

        bool TrueFalseValue { get; set; }
    }
}
