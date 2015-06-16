using Protocols.Interfaces;
using Protocols.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Protocols.Controllers
{
    public class ListBoxOptionsController
    {
        IListBoxOptionsView view;
        IList items;
        public string SelectedItem { get; private set; }

        public ListBoxOptionsController(IListBoxOptionsView view, IList items)
        {
            this.view = view;
            this.view.SetController(this);
            this.items = new ArrayList(items);
            this.SelectedItem = "";
        }

        public void LoadView()
        {
            foreach(ListItem item in items)
            {
                this.view.AddItemToListBox(item.ItemName);
            }
        }

        public void MainListBoxSelectedIndexChanged(int selectedIndex)
        {
            if(selectedIndex > -1 && selectedIndex < this.items.Count)
            {
                ListItem selectedListItem = (ListItem)this.items[selectedIndex];
                this.SelectedItem = selectedListItem.ItemName;
            }
        }

        public void SubmitButtonClicked()
        {
            if(this.SelectedItem == "")
            {
                MessageBox.Show("Please select 1 item.");
                this.view.SetDialogResult(DialogResult.Retry);
            }
            else
            {
                this.view.SetDialogResult(DialogResult.OK);
            }
        }
    }
}
