using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.ProtocolManager.Controllers.Templates;
using Toxikon.ProtocolManager.Interfaces.Templates;

namespace Toxikon.ProtocolManager.Views.Templates
{
    public partial class OneTextBoxTrueFalseForm : Form, IOneTextBoxTrueFalseForm
    {
        OneTextBoxTrueFalseFormController controller;

        public OneTextBoxTrueFalseForm()
        {
            InitializeComponent();
        }

        public void SetController(OneTextBoxTrueFalseFormController controller)
        {
            this.controller = controller;
        }
        public void SetTrueFalseRadioButtonGroup_Enable(bool value)
        {
            this.TrueFalseRadioButtonGroup.Enabled = value;
        }
        public void SetDialogResult(DialogResult dialogResult)
        {
            this.DialogResult = dialogResult;
        }

        public string TextBoxLabel
        {
            get { return this.Label1.Text; }
            set { this.Label1.Text = value; }
        }
        public string TextBoxValue
        {
            get { return this.TextBox1.Text; }
            set { this.TextBox1.Text = value; }
        }
        public string TrueFalseLabel
        {
            get { return this.Label2.Text; }
            set { this.Label2.Text = value; }
        }
        public bool TrueFalseValue
        {
            get { return this.TrueRadioButton.Checked; }
            set
            {
                this.TrueRadioButton.Checked = value;
                this.FalseRadioButton.Checked = value == true ? false : true;
            }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            this.controller.SubmitButtonClicked();
        }
    }
}
