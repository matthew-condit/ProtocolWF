using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.ProtocolManager.Interfaces.Admin;
using Toxikon.ProtocolManager.Controllers.Admin;

namespace Toxikon.ProtocolManager.Views.Admin
{
    public partial class ProtocolNumberUpdateView : UserControl, IProtocolNumberUpdateView
    {
        public ProtocolNumberUpdateView()
        {
            InitializeComponent();
        }

        private ProtocolNumberUpdateController controller;

        public void SetController(ProtocolNumberUpdateController controller)
        {
            this.controller = controller;
        }

        public void SetAdminView(bool value)
        {
            this.ProtocolNumberTextBox.Enabled = value;
            this.YearNumberTextBox.Enabled = value;
            this.TrueFalseRadioButtonGroup.Enabled = value;
        }

        public void ClearView()
        {
            this.RequestID = "";
            this.TemmplateID = "";
            this.ProtocolNumber = "";
            this.YearNumber = "";
            this.SequenceNumber = "";
            this.RevisedNumber = "";
            this.ProtocolType = "";
            this.IsActive = true;
        }

        public string RequestID
        {
            get { return this.RequestIDTextBox.Text; }
            set { this.RequestIDTextBox.Text = value; }
        }

        public string TemmplateID
        {
            get { return this.TemplateIDTextBox.Text; }
            set { this.TemplateIDTextBox.Text = value; }
        }

        public string ProtocolNumber
        {
            get { return this.ProtocolNumberTextBox.Text; }
            set { this.ProtocolNumberTextBox.Text = value; }
        }

        public string YearNumber
        {
            get { return this.YearNumberTextBox.Text; }
            set { this.YearNumberTextBox.Text = value; }
        }

        public string SequenceNumber
        {
            get { return this.SequenceNumberTextBox.Text; }
            set { this.SequenceNumberTextBox.Text = value; }
        }

        public string RevisedNumber
        {
            get { return this.RevisedNumberTextBox.Text; }
            set { this.RevisedNumberTextBox.Text = value; }
        }

        public string ProtocolType
        {
            get { return this.ProtocolTypeTextBox.Text; }
            set { this.ProtocolTypeTextBox.Text = value; }
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

        private void SearchButton_Click(object sender, EventArgs e)
        {
            this.controller.SearchButtonClicked();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            this.controller.UpdateButtonClicked();
        }

    }
}
