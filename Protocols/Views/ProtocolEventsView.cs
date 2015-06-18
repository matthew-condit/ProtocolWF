using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Protocols.Interfaces;
using Protocols.Controllers;
using Protocols.Models;

namespace Protocols.Views
{
    public partial class ProtocolEventsView : UserControl, IProtocolEventsView
    {
        ProtocolEventsController controller;

        public ProtocolEventsView()
        {
            InitializeComponent();
        }

        public void SetController(ProtocolEventsController controller)
        {
            this.controller = controller;
        }
        public void ClearView()
        {
            this.MainListView.Items.Clear();
        }
        public void AddItemToListView(ProtocolEvent protocolEvent)
        {
            ListViewItem item = this.MainListView.Items.Add(protocolEvent.ID.ToString());
            item.SubItems.Add(protocolEvent.Type);
            item.SubItems.Add(protocolEvent.Description);
            item.SubItems.Add(protocolEvent.IsActive.ToString());
        }

        public Control ParentControl
        {
            get { return this.ParentForm; }
        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            this.controller.NewButtonClicked();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            this.controller.UpdateButtonClicked();
        }

        private void MainListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.MainListView.SelectedIndices.Count > 0)
            {
                this.controller.ListViewSelectedIndexChanged(this.MainListView.SelectedIndices[0]);
            }
        }
    }
}
