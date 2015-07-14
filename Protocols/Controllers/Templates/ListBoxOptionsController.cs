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
        IListBoxForm view;
        IList items;
        public Item SelectedItem { get; private set; }
        public int SelectedIndex { get; private set; }

        public ListBoxOptionsController(IListBoxForm view, IList items)
        {
            this.view = view;
            this.view.SetController(this);
            this.items = new ArrayList(items);
            this.SelectedItem = new Item();
            this.SelectedIndex = -1;
        }

        public void LoadView()
        {
            foreach(Item item in items)
            {
                this.view.AddItemToListBox(item.Text);
            }
        }

        public void MainListBoxSelectedIndexChanged(int selectedIndex)
        {
            if(selectedIndex > -1 && selectedIndex < this.items.Count)
            {
                this.SelectedItem = (Item)this.items[selectedIndex];
                this.SelectedIndex = selectedIndex;
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
