using Protocols.Controllers;
using Protocols.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Protocols.Views
{
    public partial class OneTextBoxFormView : Form, IOneTextBoxFormView
    {
        OneTextBoxFormController controller;

        public OneTextBoxFormView()
        {
            InitializeComponent();
        }

        public void SetController(OneTextBoxFormController controller)
        {
            this.controller = controller;
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

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            this.controller.SubmitButtonClicked();
        }
    }
}
