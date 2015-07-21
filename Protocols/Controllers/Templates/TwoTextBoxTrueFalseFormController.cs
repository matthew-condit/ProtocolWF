using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.ProtocolManager.Interfaces.Templates;

namespace Toxikon.ProtocolManager.Controllers.Templates
{
    public class TwoTextBoxTrueFalseFormController : Controller
    {
        ITwoTextBoxTrueFalseForm view;
        public string TextBox1Value { get; private set; }
        public string TextBox2Value { get; private set; }
        public bool TrueFalseValue { get; private set; }

        public TwoTextBoxTrueFalseFormController(ITwoTextBoxTrueFalseForm view)
        {
            this.view = view;
            this.view.SetController(this);
            this.TextBox1Value = "";
            this.TextBox2Value = "";
            this.TrueFalseValue = true;
        }

        public void SetLabelTexts(string label1, string label2, string label3)
        {
            this.view.Label1Text = label1;
            this.view.Label2Text = label2;
            this.view.Label3Text = label3;
        }

        public void SetTextBoxTexts(string textBox1, string textBox2)
        {
            this.view.TextBox1Text = textBox1;
            this.view.TextBox2Text = textBox2;
        }

        public void SetTrueFalseValue(bool value)
        {
            this.view.TrueFalseValue = value;
        }

        public void SubmitButtonClicked()
        {
            this.TextBox1Value = this.view.TextBox1Text;
            this.TextBox2Value = this.view.TextBox2Text;
            this.TrueFalseValue = this.view.TrueFalseValue;

            view.SetDialogResult(DialogResult.OK);
        }
    }
}
