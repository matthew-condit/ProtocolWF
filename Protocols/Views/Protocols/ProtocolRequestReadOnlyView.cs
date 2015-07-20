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
using Toxikon.ProtocolManager.Views.RequestForms;
using System.Collections;
using Toxikon.ProtocolManager.Models;
using Toxikon.ProtocolManager.Interfaces;

namespace Toxikon.ProtocolManager.Views.Protocols
{
    public partial class ProtocolRequestReadOnlyView : RequestDetailView
    {
        public ProtocolRequestReadOnlyView()
        {
            InitializeComponent();
            this.TemplateListView = this.TitlesListView;
            this.RequestForm = this.RequestFormReadOnly;
        }

        public override Control ParentControl
        {
            get { return this.ParentForm; }
        }

        private void ViewCommentsButton_Click(object sender, EventArgs e)
        {
            this.controller.ViewCommentsButtonClicked();
        }

        private void ViewEventsButton_Click(object sender, EventArgs e)
        {
            this.controller.ViewEventsButtonClicked();
        }

        private void DownloadReportButton_Click(object sender, EventArgs e)
        {
            this.controller.DownloadRequestReportButtonClicked();
        }

        private void TitlesListView_Leave(object sender, EventArgs e)
        {
            this.TitlesListView.SelectedIndices.Clear();
        }

        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            this.controller.OpenFileButtonClicked();
        }
    }
}
