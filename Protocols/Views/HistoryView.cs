﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.ProtocolManager.Interfaces;
using Toxikon.ProtocolManager.Controllers;
using Toxikon.ProtocolManager.Models;
using Toxikon.ProtocolManager.Views.Protocols;

namespace Toxikon.ProtocolManager.Views
{
    public partial class HistoryView : UserControl, IHistoryView
    {
        HistoryController controller;

        public HistoryView()
        {
            InitializeComponent();
        }

        public void SetController(HistoryController controller)
        {
            this.controller = controller;
        }

        public string SearchLabelText
        {
            get { return this.SearchLabel.Text; }
            set { this.SearchLabel.Text = value; }
        }

        public void AddItemToRequestedByComboBox(Item item)
        {
            this.RequestedByComboBox.Items.Add(item.Text);
        }
        
        public void SetRequestedByComboBox_SelectedIndex(int index)
        {
            this.RequestedByComboBox.SelectedIndex = index;
        }
        
        public void AddItemToListView(ProtocolRequest request)
        {
            ListViewItem item = this.RequestListView.Items.Add(request.RequestedDate.ToString("MM/dd/yyyy"));
            item.SubItems.Add(request.Contact.SponsorName);
        }

        public void ClearListView()
        {
            this.RequestListView.Items.Clear();
        }

        public ProtocolRequestReadOnlyView GetRequestView
        {
            get { return this.ProtocolRequestDetail; }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            this.controller.SearchButtonClicked();
        }

        private void RequestedByComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.controller.RequestedByComboBox_SelectedIndexChanged(this.RequestedByComboBox.SelectedIndex);
        }

        private void RequestListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.RequestListView.SelectedIndices.Count > 0)
            {
                this.controller.RequestListView_SelectedIndexChanged(this.RequestListView.SelectedIndices[0]);
            }
        }
    }
}
