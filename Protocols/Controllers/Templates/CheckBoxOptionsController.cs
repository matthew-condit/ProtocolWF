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
    public class CheckBoxOptionsController
    {
        ICheckBoxOptionsView view;
        IList items;
        public List<string> SelectedItems { get; private set; }

        public CheckBoxOptionsController(ICheckBoxOptionsView view, IList items)
        {
            this.view = view;
            this.view.SetController(this);
            this.items = new ArrayList(items);
            this.SelectedItems = new List<string> { };
        }

        public void LoadView()
        {
            foreach(ListItem item in items)
            {
                this.view.AddItemToList(item.ItemName);
            }
        }

        public void SubmitButtonClicked()
        {
            if(view.SelectedItems.Count != 0)
            {
                foreach (string item in view.SelectedItems)
                {
                    this.SelectedItems.Add(item);
                }
                this.view.SetDialogResult(DialogResult.OK);
            }
            else
            {
                this.view.SetDialogResult(DialogResult.Retry);
                MessageBox.Show("Please select at least 1 item.");
            }
        }
    }
}
