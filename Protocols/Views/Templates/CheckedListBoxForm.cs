using Toxikon.ProtocolManager.Controllers.Templates;
using Toxikon.ProtocolManager.Interfaces.Templates;
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

namespace Toxikon.ProtocolManager.Views.Templates
{
    public partial class CheckedListBoxForm : Form, ICheckedListBoxForm
    {
        CheckBoxOptionsController controller;

        public CheckedListBoxForm()
        {
            InitializeComponent();
        }

        public void SetController(CheckBoxOptionsController controller)
        {
            this.controller = controller;
        }

        public void SetDialogResult(DialogResult dialogResult)
        {
            this.DialogResult = dialogResult;
        }

        public void AddItemToList(string item)
        {
            this.OptionsCheckedListBox.Items.Add(item);
        }

        public IList SelectedItems
        {
            get
            {
                return this.OptionsCheckedListBox.CheckedItems;
            }
        }

        public IList SelectedIndices
        {
            get { return this.OptionsCheckedListBox.CheckedIndices; }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            this.controller.SubmitButtonClicked();
        }

        private void CheckBoxOptionsView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(this.DialogResult == System.Windows.Forms.DialogResult.Retry)
            {
                e.Cancel = true;
            }
        }
    }
}
