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
using Toxikon.ProtocolManager.Models;
using System.Collections;

namespace Toxikon.ProtocolManager.Views.Protocols
{
    public partial class ProtocolRequestManagerView : RequestDetailView
    {
        public ProtocolRequestManagerView()
        {
            InitializeComponent();
            this.TemplateListView = this.TitlesListView;
            this.RequestForm = this.RequestFormManagerView;
        }

        public override Control ParentControl
        {
            get { return this.ParentForm; }
        }

        private void ViewEventsButton_Click(object sender, EventArgs e)
        {
            this.controller.ViewEventsButtonClicked();
        }

        private void ViewCommentsButton_Click(object sender, EventArgs e)
        {
            this.controller.ViewCommentsButtonClicked();
        }

        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            this.controller.OpenFileButtonClicked();
        }

        private void SaveChangesButton_Click(object sender, EventArgs e)
        {
            this.controller.SaveChangedButtonClicked();
        }

        private void DownloadReportButton_Click(object sender, EventArgs e)
        {
            this.controller.DownloadRequestReportButtonClicked();
        }
    }
}
