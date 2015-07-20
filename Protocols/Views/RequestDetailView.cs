using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.ProtocolManager.Controllers;
using Toxikon.ProtocolManager.Interfaces;
using Toxikon.ProtocolManager.Models;

namespace Toxikon.ProtocolManager.Views
{
    public class RequestDetailView : UserControl
    {
        protected RequestDetailController controller;
        protected ListView TemplateListView;
        public IRequestForm RequestForm { get; set; }
        public virtual Control ParentControl { get; protected set; }

        public RequestDetailView()
        {

        }

        public void SetController(RequestDetailController controller)
        {
            this.controller = controller;
        }

        public IList ListViewSelectedIndexes
        {
            get
            {
                IList results = new ArrayList();
                if (this.TemplateListView.SelectedIndices.Count != 0)
                {
                    results = this.TemplateListView.SelectedIndices;
                }
                return results;
            }
        }

        public void AddTemplateToListView(ProtocolTemplate title)
        {
            ListViewItem item = this.TemplateListView.Items.Add(title.TemplateID.ToString());
            item.SubItems.Add(title.Description);
            item.SubItems.Add(title.LatestActivity.ProtocolEvent.Description);
            item.SubItems.Add(title.LatestActivity.CreatedDate.ToString("MM/dd/yyyy"));
            item.SubItems.Add(title.LatestActivity.CreatedBy);
            item.SubItems.Add(title.CommentsCount.ToString());
            item.SubItems.Add(title.ProtocolNumber.FullCode);
            item.SubItems.Add(title.FileName);
            item.SubItems.Add(title.ProjectNumber);
            item.SubItems.Add(title.Department.Name);
        }

        public void ClearListView()
        {
            this.TemplateListView.Items.Clear();
        }

        public void SetListViewAutoResizeColumns()
        {
            this.TemplateListView.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.TemplateListView.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.TemplateListView.Columns[2].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.TemplateListView.Columns[3].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            this.TemplateListView.Columns[4].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            this.TemplateListView.Columns[5].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            this.TemplateListView.Columns[6].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            this.TemplateListView.Columns[7].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            this.TemplateListView.Columns[8].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            this.TemplateListView.Columns[9].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
    }
}
