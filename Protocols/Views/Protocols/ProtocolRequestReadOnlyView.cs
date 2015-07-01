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

namespace Toxikon.ProtocolManager.Views.Protocols
{
    public partial class ProtocolRequestReadOnlyView : UserControl, IProtocolRequestReadOnlyView
    {
        ProtocolRequestReadOnlyController controller;

        public ProtocolRequestReadOnlyView()
        {
            InitializeComponent();
        }

        public RequestFormReadOnly GetRequestForm
        {
            get { return this.RequestForm; }
        }

        public void SetController(ProtocolRequestReadOnlyController controller)
        {
            this.controller = controller;
        }

        public Control ParentControl
        {
            get { return this.ParentForm; }
        }

        public void ClearView()
        {
            this.TitlesListView.Items.Clear();
        }

        public IList SelectedTitleIndexes
        {
            get
            {
                IList results = new ArrayList();
                if (this.TitlesListView.SelectedIndices.Count != 0)
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
            item.SubItems.Add(title.ProtocolNumber.FullCode);
            item.SubItems.Add(title.FileName);
            item.SubItems.Add(title.ProjectNumber);
        }

        public void SetListViewAutoResizeColumns()
        {
            this.TitlesListView.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.TitlesListView.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.TitlesListView.Columns[2].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            this.TitlesListView.Columns[3].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            this.TitlesListView.Columns[4].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            this.TitlesListView.Columns[5].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            this.TitlesListView.Columns[6].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            this.TitlesListView.Columns[7].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        public void ClearProtocolTitleListView()
        {
            this.TitlesListView.Items.Clear();
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
