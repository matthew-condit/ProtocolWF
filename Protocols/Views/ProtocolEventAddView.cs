using Protocols.Controllers;
using Protocols.Interfaces;
using Protocols.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Protocols.Views
{
    public partial class ProtocolEventAddView : Form, IProtocolEventAddView
    {
        ProtocolEventAddController controller;

        public ProtocolEventAddView()
        {
            InitializeComponent();
        }

        public void SetController(ProtocolEventAddController controller)
        {
            this.controller = controller;
        }
        public void AddProtocolEventTypeToView(string eventType)
        {
            this.EventTypeComboBox.Items.Add(eventType);
        }
        public void SetSelectedProtocolEventType(int selectedIndex)
        {
            if(this.EventTypeComboBox.Items.Count != 0 && selectedIndex > -1)
            {
                this.EventTypeComboBox.SelectedIndex = selectedIndex;
            }
        }
        public void AddProtocolEventToView(ProtocolEvent protocolEvent)
        {
            this.ProtocolEventsListBox.Items.Add(protocolEvent.Description);
        }
        public void ClearListBox()
        {
            this.ProtocolEventsListBox.Items.Clear();
        }
        public void SetDialogResult(DialogResult dialogResult)
        {
            this.DialogResult = dialogResult;
        }

        private void EventTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.controller.EventTypeComboBox_SelectedIndexChanged(this.EventTypeComboBox.SelectedIndex);
        }

        private void ProtocolEventsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.controller.ProtocolEventListBox_SelectedIndexChanged(this.ProtocolEventsListBox.SelectedIndex);
        }

        private void ProtocolEventAddView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(this.DialogResult == System.Windows.Forms.DialogResult.Retry)
            {
                e.Cancel = true;
            }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            this.controller.SubmitButtonClicked();
        }
    }
}
