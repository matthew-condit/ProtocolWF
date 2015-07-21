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
    public partial class TwoTextBoxTrueFalseForm : Form, ITwoTextBoxTrueFalseForm
    {
        public TwoTextBoxTrueFalseForm()
        {
            InitializeComponent();
        }

        private TwoTextBoxTrueFalseFormController controller;
        
        public void SetController(TwoTextBoxTrueFalseFormController controller)
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

        public string Label1Text
        {
            get { return this.Label1.Text; }
            set { this.Label1.Text = value; }
        }

        public string Label2Text
        {
            get { return this.Label2.Text; }
            set { this.Label2.Text = value; }
        }

        public string Label3Text
        {
            get { return this.Label3.Text; }
            set { this.Label3.Text = value; }
        }

        public string TextBox1Text
        {
            get { return this.TextBox1.Text; }
            set { this.TextBox1.Text = value; }
        }

        public string TextBox2Text
        {
            get { return this.TextBox2.Text; }
            set { this.TextBox2.Text = value; }
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
