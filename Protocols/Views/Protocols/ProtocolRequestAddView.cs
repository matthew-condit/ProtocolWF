using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.ProtocolManager.Interfaces.Protocols;
using Toxikon.ProtocolManager.Controllers.Protocols;
using Toxikon.ProtocolManager.Models;
using Toxikon.ProtocolManager.Views.RequestForms;
using System.Diagnostics;

namespace Toxikon.ProtocolManager.Views.Protocols
{
    public partial class ProtocolRequestAddView : UserControl, IProtocolRequestAddView
    {
        ProtocolRequestAddController controller;

        public ProtocolRequestAddView()
        {
            InitializeComponent();
        }

        public RequestFormAdd GetRequestForm
        {
            get { return this.RequestForm; }
        }

        public void SetController(ProtocolRequestAddController controller)
        {
            this.controller = controller;
        }

        public Control ParentControl
        {
            get { return this; }
        }

        public void AddItemToDataGrid(Item item)
        {
            this.TitleDataGridView.Rows.Add(item.ID, item.Value);
        }

        public void ClearView()
        {
            this.SearchSponsorName = "";
            this.TitleDataGridView.Rows.Clear();
        }

        public string SearchSponsorName
        {
            get { return this.SearchTextBox.Text; }
            set { this.SearchTextBox.Text = value; }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            this.controller.SearchButtonClicked();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            this.controller.SubmitButtonClicked();
        }

        private void FindTemplateButton_Click(object sender, EventArgs e)
        {
            this.controller.FindTemplateButtonClicked();
        }

        private void TitleDataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            this.controller.RemoveItemFromTemplates(e.RowIndex);
        }
    }
}
