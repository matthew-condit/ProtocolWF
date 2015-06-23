using Protocols.Controllers;
using Protocols.Interfaces;
using Protocols.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Protocols.Views
{
    public partial class ListViewPopup : Form, IListViewPopup
    {
        ListViewPopupController controller;

        public ListViewPopup()
        {
            InitializeComponent();
        }

        public void SetController(ListViewPopupController controller)
        {
            this.controller = controller;
        }

        public void AddListViewColumns(IList columns)
        {
            foreach(string columnName in columns)
            {
                this.MainListView.Columns.Add(columnName);
            }
        }

        public void AddItemToListView(object item)
        {
            if(item is Comment)
            {
                AddCommentToListView((Comment)item);
            }
            else if(item is ProtocolActivity)
            {
                AddProtocolActivityToListView((ProtocolActivity)item);
            }
        }

        private void AddCommentToListView(Comment item)
        {
            ListViewItem listViewItem = this.MainListView.Items.Add(item.CreatedDate.ToString("MM/dd/yyyy"));
            listViewItem.SubItems.Add(item.CreatedBy);
            listViewItem.SubItems.Add(item.Content);
        }

        private void AddProtocolActivityToListView(ProtocolActivity item)
        {
            ListViewItem listViewItem = this.MainListView.Items.Add(item.CreatedDate.ToString("MM/dd/yyyy"));
            listViewItem.SubItems.Add(item.CreatedBy);
            listViewItem.SubItems.Add(item.ProtocolEvent.Description);
        }

        public void SetListViewAutoResizeColumns()
        {
            this.MainListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }
    }
}
