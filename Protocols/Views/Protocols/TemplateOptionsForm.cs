using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.ProtocolManager.Controllers;
using Toxikon.ProtocolManager.Controllers.Protocols;
using Toxikon.ProtocolManager.Interfaces.Protocols;
using Toxikon.ProtocolManager.Models;

namespace Toxikon.ProtocolManager.Views.Protocols
{
    public partial class TemplateOptionsForm : Form, ITemplateOptionsForm
    {
        Controller controller;

        public TemplateOptionsForm()
        {
            InitializeComponent();
        }

        public void SetController(Controller controller)
        {
            this.controller = controller;
        }

        public void AddItemToListBox1(Item item)
        {
            this.ListBox1.Items.Add(item.Value);
        }

        public void AddItemToListBox2(Item item)
        {
            this.ListBox2.Items.Add(item.Value);
        }

        public void ClearListBox2()
        {
            this.ListBox2.Items.Clear();
        }

        public void SetDialogResult(DialogResult dialogResult)
        {
            this.DialogResult = dialogResult;
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.controller is TemplateOptionsController)
            {
                ((TemplateOptionsController)this.controller).ListBox1_SelectedIndexChanged(this.ListBox1.SelectedIndex);
            }
        }

        private void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.controller is TemplateOptionsController)
            {
                ((TemplateOptionsController)this.controller).ListBox2_SelectedIndexChanged(this.ListBox2.SelectedIndex);
            }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (this.controller is TemplateOptionsController)
            {
                ((TemplateOptionsController)this.controller).SubmitButtonClicked();
            }
        }
    }
}
