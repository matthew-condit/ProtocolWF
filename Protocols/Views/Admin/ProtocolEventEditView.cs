using Toxikon.ProtocolManager.Controllers.Admin;
using Toxikon.ProtocolManager.Interfaces.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Toxikon.ProtocolManager.Views.Protocols
{
    public partial class ProtocolEventEditView : Form, IProtocolEventEditView
    {
        ProtocolEventEditController controller;

        public ProtocolEventEditView()
        {
            InitializeComponent();
        }

        public void SetController(ProtocolEventEditController controller)
        {
            this.controller = controller;
        }
        public void SetIsActiveRadioButtonGroup_Enable(bool value)
        {
            this.IsActiveRadioButtonGroup.Enabled = value;
        }
        public void SetDialogResult(DialogResult dialogResult)
        {
            this.DialogResult = dialogResult;
        }

        public string EventType
        {
            get { return this.EventTypeComboBox.SelectedItem.ToString(); }
            set { this.EventTypeComboBox.SelectedItem = value; }
        }
        public string EventDescription
        {
            get { return this.DescriptionTextBox.Text; }
            set { this.DescriptionTextBox.Text = value; }
        }
        public bool IsActive
        {
            get { return this.TrueRadioButton.Checked; }
            set
            {
                this.TrueRadioButton.Checked = value;
                this.FalseRadioButton.Checked = value == true ? false : true;
            }
        }

        private void ProtocolEventEditView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(this.DialogResult == System.Windows.Forms.DialogResult.Retry)
            {
                e.Cancel = true;
            }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            this.controller.SubmitButtonClicked();
        }
    }
}
