using Toxikon.ProtocolManager.Interfaces.Templates;
using Toxikon.ProtocolManager.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toxikon.ProtocolManager.Controllers.Templates
{
    public class ListViewPopupController
    {
        IListViewForm view;
        IList items;
        IList columns;

        public ListViewPopupController(IListViewForm view, IList columns, IList items)
        {
            this.view = view;
            this.view.SetController(this);
            this.columns = new ArrayList(columns);
            this.items = new ArrayList(items);
        }

        public void LoadView()
        {
            this.view.AddListViewColumns(columns);
            AddItemsToView();
            this.view.SetListViewAutoResizeColumns();
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
