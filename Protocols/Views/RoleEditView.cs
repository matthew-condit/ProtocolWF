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
    public partial class RoleEditView : Form, IRoleEditView
    {
        RoleEditController controller;

        public RoleEditView()
        {
            InitializeComponent();
        }

        public void SetController(RoleEditController controller)
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

        public string RoleName
        {
            get { return this.RoleTextBox.Text; }
            set { this.RoleTextBox.Text = value; }
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

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            this.controller.SubmitButtonClicked();
        }

        private void RolePopup_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.Retry)
            {
                e.Cancel = true;
            }
        }
    }
}
