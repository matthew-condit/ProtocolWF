using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.ProtocolManager.Interfaces.Protocols;
using Toxikon.ProtocolManager.Controllers.Protocols;
using Toxikon.ProtocolManager.Models;
using Toxikon.ProtocolManager.Views.RequestForms;
using System.Diagnostics;

namespace Toxikon.ProtocolManager.Views.Protocols
{
    public partial class ProtocolRequestAddView : UserControl, IProtocolRequestAddView
    {
        ProtocolRequestAddController controller;

        public ProtocolRequestAddView()
        {
            InitializeComponent();
        }

        public RequestFormAdd GetRequestForm
        {
            get { return this.RequestForm; }
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

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            this.controller.SubmitButtonClicked();
        }

        public List<string> Titles
        {
            get
            {
                List<string> results = new List<string>();
                try
                {
                    foreach (DataGridViewRow row in this.TitleDataGridView.Rows)
                    {
                        DataGridViewCell cell = row.Cells[0];
                        string cellValue = cell.EditedFormattedValue.ToString().Trim();
                        if (cellValue != String.Empty)
                        {
                            results.Add(cellValue);
                        }
                    }
                }
                catch (NullReferenceException e)
                {
                    Debug.WriteLine(e.ToString());
                }

                return results;
            }
        }
    }
}
