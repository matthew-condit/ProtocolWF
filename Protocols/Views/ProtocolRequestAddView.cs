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
using Protocols.Models;

namespace Protocols.Views
{
    public partial class ProtocolRequestAddView : UserControl, IProtocolRequestAddView
    {
        ProtocolRequestAddController controller;

        public ProtocolRequestAddView()
        {
            InitializeComponent();
        }

        public ProtocolRequestDetailView GetProtocolRequestDetailView
        {
            get { return this.ProtocolRequestDetailView; }
        }

        public void SetController(ProtocolRequestAddController controller)
        {
            this.controller = controller;
        }

        public void ClearView()
        {
            this.SearchSponsorName = "";
            this.SponsorListView.Items.Clear();
        }

        public void AddSponsorToSearchResultList(Sponsor sponsor)
        {
            ListViewItem item = this.SponsorListView.Items.Add(sponsor.SponsorName);
            item.SubItems.Add(sponsor.SponsorContact);
            item.SubItems.Add(sponsor.Email);
        }

        public string SearchSponsorName
        {
            get { return this.SearchTextBox.Text; }
            set { this.SearchTextBox.Text = value; }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            this.controller.SearchButtonClicked();
        }

        private void SponsorListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.SponsorListView.SelectedIndices.Count > 0)
            {
                this.controller.SponsorListViewSelectedIndexChanged(this.SponsorListView.SelectedIndices[0]);
            }
        }
    }
}
