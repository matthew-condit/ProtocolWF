using Protocols.Interfaces;
using Protocols.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocols.Controllers
{
    public class ListViewPopupController
    {
        IListViewPopup view;
        string itemType;
        IList items;

        public ListViewPopupController(IListViewPopup view, string itemType, IList items)
        {
            this.view = view;
            this.view.SetController(this);
            this.itemType = itemType;
            this.items = new ArrayList(items);
        }

        public void LoadView()
        {
            if(itemType == ListViewPopupItemTypes.ProtocolComment)
            {
                AddCommentColumns();
            }
            else if(itemType == ListViewPopupItemTypes.ProtocolEvent)
            {
                AddEventColumns();
            }
            AddItemsToView();
            this.view.SetListViewAutoResizeColumns();
        }

        private void AddCommentColumns()
        {
            IList columns = new ArrayList();
            columns.Add("Date");
            columns.Add("User");
            columns.Add("Comments");
            this.view.AddListViewColumns(columns);
        }

        private void AddEventColumns()
        {
            IList columns = new ArrayList();
            columns.Add("Date");
            columns.Add("User");
            columns.Add("Event");
            this.view.AddListViewColumns(columns);
        }

        private void AddItemsToView()
        {
            foreach (object item in items)
            {
                this.view.AddItemToListView(item);
            }
        }
    }
}
