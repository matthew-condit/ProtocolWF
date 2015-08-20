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
using System.Diagnostics;
using Toxikon.ProtocolManager.Models;
using System.Collections;
using Toxikon.ProtocolManager.Queries;
using Toxikon.ProtocolManager.Views.RequestForms;

namespace Toxikon.ProtocolManager.Views.Protocols
{
    public partial class ProtocolRequestEditView : RequestDetailView
    {
        public ProtocolRequestEditView()
        {
            InitializeComponent();
            this.TemplateListView = this.TitlesListView;
            this.RequestForm = this.RequestFormEditView;
        }

        public override Control ParentControl
        {
            get { return this.ParentForm; }
        }

        private void AddTitleButton_Click(object sender, EventArgs e)
        {
            this.controller.AddTemplateButtonClicked();
        }

        private void RemoveTitleButton_Click(object sender, EventArgs e)
        {
            this.controller.RemoveTemplateButtonClicked();
        }

        private void AddEventButton_Click(object sender, EventArgs e)
        {
            this.controller.AddEventButtonClicked();
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

        private void SaveChangesButton_Click(object sender, EventArgs e)
        {
            this.controller.SaveChangedButtonClicked();
        }

        private void AddProtocolNumber_Click(object sender, EventArgs e)
        {
            this.controller.AddProtocolNumberButtonClicked();
        }

        private void RevisedProtocolButton_Click(object sender, EventArgs e)
        {
            this.controller.ReviseProtocolButtonClicked();
        }

        private void DownloadReportButton_Click(object sender, EventArgs e)
        {
            this.controller.DownloadRequestReportButtonClicked();
        }

        private void TitlesListView_Leave(object sender, EventArgs e)
        {
            this.TitlesListView.SelectedIndices.Clear();
        }

        private void CloseRequestButton_Click(object sender, EventArgs e)
        {
            this.controller.CloseRequestButtonClicked();
        }

        private void UpdateFilePathButton_Click(object sender, EventArgs e)
        {
            if (this.ListViewSelectedIndexes.Count == 1)
            {
                DialogResult dialogResult = openFileDialog.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    controller.UpdateFilePathButtonClicked(openFileDialog.FileName);
                }
            }
            else
            {
                MessageBox.Show("Please select one title and try it again.");
            }
        }

        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            this.controller.OpenFileButtonClicked();
        }

        private void UpdateProjectNumberButton_Click(object sender, EventArgs e)
        {
            this.controller.UpdateProjectNumberButtonClicked();
        }

        private void DepartmentButton_Click(object sender, EventArgs e)
        {
            this.controller.DepartmentButtonClicked();
        }

        private void CreateProtocolButton_Click(object sender, EventArgs e)
        {

        }
    }
}
