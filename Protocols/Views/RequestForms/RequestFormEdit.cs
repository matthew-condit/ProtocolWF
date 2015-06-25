using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.ProtocolManager.Interfaces;
using Toxikon.ProtocolManager.Controllers;
using System.Collections;
using Toxikon.ProtocolManager.Queries;
using Toxikon.ProtocolManager.Models;

namespace Toxikon.ProtocolManager.Views.RequestForms
{
    public partial class RequestFormEdit : UserControl, IRequestForm
    {
        RequestFormController controller;

        public RequestFormEdit()
        {
            InitializeComponent();
        }

        public void SetController(RequestFormController controller)
        {
            this.controller = controller;
        }

        public Control ParentControl
        {
            get { return this.ParentForm; }
        }

        public void ClearView()
        {
            this.ContactName = "";
            this.SponsorName = "";
            this.Email = "";
            this.Address = "";
            this.City = "";
            this.State = "";
            this.ZipCode = "";
            this.PhoneNumber = "";
            this.FaxNumber = "";
            this.PONumber = "";
            this.Guidelines = "";
            this.Compliance = "";
            this.ProtocolType = "";
            this.DueDate = DateTime.Now;
            this.SendVia = "";
            this.BillTo = "Toxikon";
            this.Comments = "";
            this.AssignedToTextBox.Text = "";
        }

        public string RequestedBy
        {
            get { return this.RequestedByLabel.Text; }
            set { this.RequestedByLabel.Text = value; }
        }
        public string RequestedDate
        {
            get { return this.RequestedDateLabel.Text; }
            set { this.RequestedDateLabel.Text = value; }
        }
        public string ContactName
        {
            get { return this.SponsorContactLabel.Text; }
            set { this.SponsorContactLabel.Text = value; }
        }
        public string SponsorName
        {
            get { return this.SponsorNameLabel.Text; }
            set { this.SponsorNameLabel.Text = value; }
        }
        public string Email
        {
            get { return this.EmailLabel.Text; }
            set { this.EmailLabel.Text = value; }
        }
        public string Address
        {
            get { return this.AddressLabel.Text; }
            set { this.AddressLabel.Text = value; }
        }
        public string City
        {
            get { return this.CityLabel.Text; }
            set { this.CityLabel.Text = value; }
        }
        public string State
        {
            get { return this.StateLabel.Text; }
            set { this.StateLabel.Text = value; }
        }
        public string ZipCode
        {
            get { return this.ZipCodeLabel.Text; }
            set { this.ZipCodeLabel.Text = value; }
        }
        public string PhoneNumber
        {
            get { return this.PhoneNumberLabel.Text; }
            set { this.PhoneNumberLabel.Text = value; }
        }
        public string FaxNumber
        {
            get { return this.FaxNumberLabel.Text; }
            set { this.FaxNumberLabel.Text = value; }
        }
        public string PONumber
        {
            get { return this.POLabel.Text; }
            set { this.POLabel.Text = value; }
        }
        public string Guidelines
        {
            get { return this.GuidelinesTextBox.Text; }
            set { this.GuidelinesTextBox.Text = value; }
        }
        public string Compliance
        {
            get { return this.ComplianceTextBox.Text; }
            set { this.ComplianceTextBox.Text = value; }
        }
        public string ProtocolType
        {
            get { return this.ProtocolTypeTextBox.Text; }
            set { this.ProtocolTypeTextBox.Text = value; }
        }
        public DateTime DueDate
        {
            get { return this.DueDateDateTimePicker.Value; }
            set { this.DueDateDateTimePicker.Value = value; }
        }
        public string SendVia
        {
            get { return this.SendViaTextBox.Text; }
            set { this.SendViaTextBox.Text = value; }
        }
        public string BillTo
        {
            get { return this.BillToTextBox.Text; }
            set { this.BillToTextBox.Text = value; }
        }

        public string Comments
        {
            get { return this.CommentsLabel.Text; }
            set { this.CommentsLabel.Text = value; }
        }

        public string AssignedTo
        {
            get { return this.AssignedToTextBox.Text; }
            set { this.AssignedToTextBox.Text = value; }
        }

        private void OpenGuidelinesOptions_Click(object sender, EventArgs e)
        {
            IList items = QListItems.GetListItems(ListNames.Guidelines);
            this.controller.OpenCheckBoxOptions(ListNames.Guidelines, items);
        }

        private void OpenComplianceOptions_Click(object sender, EventArgs e)
        {
            IList items = QListItems.GetListItems(ListNames.Compliance);
            this.controller.OpenListBoxOptions(ListNames.Compliance, items);
        }

        private void OpenProtocolTypeOptions_Click(object sender, EventArgs e)
        {
            IList items = QListItems.GetListItems(ListNames.ProtocolType);
            this.controller.OpenListBoxOptions(ListNames.ProtocolType, items);
        }

        private void OpenAssignedToOptions_Click(object sender, EventArgs e)
        {
            IList items = QUsers.GetUsersByRoleID(3, ListNames.AssignedTo);
            this.controller.OpenListBoxOptions(ListNames.AssignedTo, items);
        }

        private void ChangeContactButton_Click(object sender, EventArgs e)
        {
            this.controller.ChangeContactButtonClicked();
        }
    }
}
