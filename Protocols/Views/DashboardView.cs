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
    public partial class DashboardView : UserControl, IDashboardView
    {
        DashboardController controller;

        public DashboardView()
        {
            InitializeComponent();
        }

        public void SetController(DashboardController controller)
        {
            this.controller = controller;
        }

        public Control ParentControl
        {
            get { return this.ParentForm; }
        }

        public void AddProtocolRequestToView(ProtocolRequest request)
        {
            int rowIndex = this.RequestDataGridView.Rows.Add(request.RequestedDate.ToString("MM/dd/yyyy"),
                 request.RequestedBy,
                 request.Sponsor.SponsorName);
            /*DataGridViewRow row = this.RequestDataGridView.Rows[rowIndex];
            row.Height = 40;
            SetDataGridViewCheckBoxCell_BackColor(request, rowIndex);*/
        }

        private void RequestDataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.controller.RequestDataGridViewCellDoubleClicked(e.RowIndex);
        }
    }
}
