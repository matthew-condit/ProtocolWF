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

namespace Toxikon.ProtocolManager.Views.RequestForms
{
    public partial class RequestFormCSRView : UserControl, IRequestForm
    {
        RequestFormController controller;

        public RequestFormCSRView()
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
            this.RequestedBy = "";
            this.RequestedDateLabel.Text = "";
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
            this.DueDateLabel.Text = "";
            this.SendVia = "";
            this.BillTo = "";
            this.Cost = "";
            this.Comments = "";
            this.AssignedToLabel.Text = "";
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
            get { return this.GuidelinesLabel.Text; }
            set { this.GuidelinesLabel.Text = value; }
        }
        public string Compliance
        {
            get { return this.ComplianceLabel.Text; }
            set { this.ComplianceLabel.Text = value; }
        }
        public string ProtocolType
        {
            get { return this.ProtocolTypeLabel.Text; }
            set { this.ProtocolTypeLabel.Text = value; }
        }
        public DateTime DueDate
        {
            get 
            {
                DateTime result;
                if (!DateTime.TryParse(this.DueDateLabel.Text, out result))
                {
                    result = DateTime.Now;
                }
                return result;
            }
            set { this.DueDateLabel.Text = value.ToString("MM/dd/yyyy"); }
        }
        public string SendVia
        {
            get { return this.SendViaLabel.Text; }
            set { this.SendViaLabel.Text = value; }
        }
        public string BillTo
        {
            get { return this.BillToLabel.Text; }
            set { this.BillToLabel.Text = value; }
        }

        public string Cost
        {
            get { return this.CostLabel.Text; }
            set { this.CostLabel.Text = value; }
        }

        public string Comments
        {
            get { return this.CommentsLabel.Text; }
            set { this.CommentsLabel.Text = value; }
        }

        public string AssignedTo
        {
            get { return this.AssignedToLabel.Text; }
            set { this.AssignedToLabel.Text = value; }
        }

        private void UpdateCommentsButton_Click(object sender, EventArgs e)
        {
            this.controller.UpdateCommentsButtonClicked();
        }
    }
}
