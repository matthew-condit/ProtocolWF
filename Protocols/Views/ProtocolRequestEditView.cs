using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Protocols.Interfaces;
using Protocols.Controllers;
using System.Diagnostics;
using Protocols.Models;
using System.Collections;

namespace Protocols.Views
{
    public partial class ProtocolRequestEditView : UserControl, IProtocolRequestEditView
    {
        ProtocolRequestEditController controller;

        public ProtocolRequestEditView()
        {
            InitializeComponent();
        }

        public void SetController(ProtocolRequestEditController controller)
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
            this.TitlesListView.Items.Clear();
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

        public IList SelectedTitleIndexes
        {
            get
            {
                IList results = new ArrayList();
                if(this.TitlesListView.SelectedIndices.Count != 0)
                {
                    results = this.TitlesListView.SelectedIndices;
                }
                return results;
            }
        }

        public void AddTitleToView(ProtocolTitle title)
        {
            ListViewItem item = this.TitlesListView.Items.Add(title.Description);
            item.SubItems.Add(title.LatestActivity.ProtocolEvent.Description);
            item.SubItems.Add(title.LatestActivity.CreatedDate.ToString("MM/dd/yyyy"));
            item.SubItems.Add(title.LatestActivity.CreatedBy);
            item.SubItems.Add(title.CommentsCount.ToString());
        }

        public void SetListViewAutoResizeColumns()
        {
            this.TitlesListView.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.TitlesListView.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.TitlesListView.Columns[2].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            this.TitlesListView.Columns[3].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            this.TitlesListView.Columns[4].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        public void ClearProtocolTitleListView()
        {
            this.TitlesListView.Items.Clear();
        }

        private void OpenGuidelinesOptions_Click(object sender, EventArgs e)
        {
            this.controller.OpenCheckBoxOptions(ListNames.Guidelines);
        }

        private void OpenComplianceOptions_Click(object sender, EventArgs e)
        {
            this.controller.OpenListBoxOptions(ListNames.Compliance);
        }

        private void OpenProtocolTypeOptions_Click(object sender, EventArgs e)
        {
            this.controller.OpenListBoxOptions(ListNames.ProtocolType);
        }

        private void AddEventButton_Click(object sender, EventArgs e)
        {
            this.controller.AddEventButtonClicked();
        }

        private void AddTitleButton_Click(object sender, EventArgs e)
        {
            this.controller.AddTitleButtonClicked();
        }

        private void EditTitleButton_Click(object sender, EventArgs e)
        {
            this.controller.EditTitleButtonClicked();
        }

        private void AddCommentButton_Click(object sender, EventArgs e)
        {
            this.controller.AddCommentsButtonClicked();
        }

        private void ViewCommentsButton_Click(object sender, EventArgs e)
        {
            this.controller.ViewCommentsButtonClicked();
        }

        private void ViewEventsButton_Click(object sender, EventArgs e)
        {
            this.controller.ViewEventsButtonClicked();
        }
    }
}
