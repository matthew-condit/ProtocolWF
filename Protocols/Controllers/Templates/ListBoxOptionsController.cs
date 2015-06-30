using Toxikon.ProtocolManager.Interfaces.Templates;
using Toxikon.ProtocolManager.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Toxikon.ProtocolManager.Controllers.Templates
{
    public class ListBoxOptionsController
    {
        IListBoxOptionsView view;
        IList items;
        public ListItem SelectedItem { get; private set; }

        public ListBoxOptionsController(IListBoxOptionsView view, IList items)
        {
            this.view = view;
            this.view.SetController(this);
            this.items = new ArrayList(items);
            this.SelectedItem = null;
        }

        public void LoadView()
        {
            foreach(ListItem item in items)
            {
                this.view.AddItemToListBox(item.Text);
            }
        }

        public void MainListBoxSelectedIndexChanged(int selectedIndex)
        {
            if(selectedIndex > -1 && selectedIndex < this.items.Count)
            {
                this.SelectedItem = (ListItem)this.items[selectedIndex];
            }
        }

        public void SubmitButtonClicked()
        {
            if(this.SelectedItem == null)
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
