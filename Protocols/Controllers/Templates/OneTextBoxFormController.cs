using Toxikon.ProtocolManager.Interfaces.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Toxikon.ProtocolManager.Controllers.Templates
{
    public class OneTextBoxFormController
    {
        IOneTextBoxForm view;
        public string TextBoxLabel { get; set; }
        public string TextBoxValue { get; set; }

        public OneTextBoxFormController(IOneTextBoxForm view)
        {
            this.view = view;
            this.view.SetController(this);
            this.TextBoxLabel = "";
            this.TextBoxValue = "";
        }

        public void LoadView()
        {
            this.view.TextBoxLabel = this.TextBoxLabel;
            this.view.TextBoxValue = this.TextBoxValue;
        }

        public void SubmitButtonClicked()
        {
            this.TextBoxValue = this.view.TextBoxValue;
            view.SetDialogResult(DialogResult.OK);
        }
    }
}
