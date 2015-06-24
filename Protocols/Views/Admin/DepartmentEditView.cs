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

namespace Toxikon.ProtocolManager.Views.Admin
{
    public partial class DepartmentEditView : Form, IDepartmentEditView
    {
        DepartmentEditController controller;

        public DepartmentEditView()
        {
            InitializeComponent();
        }

        public void SetController(DepartmentEditController controller)
        {
            this.controller = controller;
        }

        public void SetDialogResult(DialogResult dialogResult)
        {
            this.DialogResult = dialogResult;
        }

        public void SetIsActiveRadioButtonGroup_Enable(bool value)
        {
            this.IsActiveRadioButtonGroup.Enabled = value;
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

        public string DepartmentName
        {
            get { return this.DepartmentTextBox.Text; }
            set { this.DepartmentTextBox.Text = value; }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            this.controller.SubmitButtonClicked();
        }

        private void DepartmentEditView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.Retry)
            {
                e.Cancel = true;
            }
        }
    }
}
