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
        ICheckedListBoxForm view;
        IList items;
        public List<string> SelectedItems { get; private set; }
        public IList SelectedIndices { get; private set; }

        public CheckBoxOptionsController(ICheckedListBoxForm view, IList items)
        {
            this.view = view;
            this.view.SetController(this);
            this.items = new ArrayList(items);
            this.SelectedItems = new List<string> { };
            this.SelectedIndices = new ArrayList();
        }

        public void LoadView()
        {
            foreach(Item item in items)
            {
                this.view.AddItemToList(item.Text);
            }
        }

        public void SubmitButtonClicked()
        {
            if(view.SelectedItems.Count != 0)
            {
                this.SelectedIndices = view.SelectedIndices;
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
