using Toxikon.ProtocolManager.Controllers.Templates;
using Toxikon.ProtocolManager.Interfaces.Templates;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Toxikon.ProtocolManager.Views.Templates
{
    public partial class ListBoxForm : Form, IListBoxForm
    {
        ListBoxOptionsController controller;

        public ListBoxForm()
        {
            InitializeComponent();
        }

        public void SetController(ListBoxOptionsController controller)
        {
            this.controller = controller;
        }
        public void AddItemToListBox(string item)
        {
            this.MainListBox.Items.Add(item);
        }
        public void SetDialogResult(DialogResult dialogResult)
        {
            this.DialogResult = dialogResult;
        }

        private void MainListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.controller.MainListBoxSelectedIndexChanged(this.MainListBox.SelectedIndex);
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            this.controller.SubmitButtonClicked();
        }

        private void ListBoxOptionsView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(this.DialogResult == System.Windows.Forms.DialogResult.Retry)
            {
                e.Cancel = true;
            }
        }
    }
}
