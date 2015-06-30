using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.ProtocolManager.Interfaces.Templates;
using Toxikon.ProtocolManager.Models;

namespace Toxikon.ProtocolManager.Controllers.Templates
{
    public class OneTextBoxTrueFalseFormController
    {
        IOneTextBoxTrueFalseForm view;
        public string TextBoxValue { get; private set; }
        public bool TrueFalseValue { get; private set; }

        public OneTextBoxTrueFalseFormController(IOneTextBoxTrueFalseForm view)
        {
            this.view = view;
            this.view.SetController(this);
        }

        public void SetTextBoxItem(string label, string value)
        {
            this.view.TextBoxLabel = label;
            this.view.TextBoxValue = value;
        }

        public void SetTrueFalseItem(string label, bool value)
        {
            this.view.TrueFalseLabel = label;
            this.view.TrueFalseValue = value;
        }

        public void SubmitButtonClicked()
        {
            this.TextBoxValue = this.view.TextBoxValue;
            this.TrueFalseValue = this.view.TrueFalseValue;

            view.SetDialogResult(DialogResult.OK);
        }
    }
}
