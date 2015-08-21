using System;
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

namespace Toxikon.ProtocolManager.Views
{
    public partial class DashboardView : UserControl, IDashboardView
    {
        DashboardController controller;

        public DashboardView()
        {
            InitializeComponent();
            this.RequestDataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.RequestDataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.RequestDataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.RequestDataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.RequestDataGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
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
            int rowIndex = this.RequestDataGridView.Rows.Add(
                request.ID,
                 request.RequestedDate.ToString("MM/dd/yyyy"),
                 request.RequestedBy,
                 request.AssignedTo.FullName,
                 request.Contact.SponsorName,
                 request.AssignedPNCount.ToString() + "/" + request.TemplateCount.ToString());
        }

        private void RequestDataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1)
            {
                try
                {
                    var requestID = Convert.ToInt32(this.RequestDataGridView.Rows[e.RowIndex].Cells[0].Value);
                    this.controller.RequestDataGridViewCellDoubleClicked(requestID);
                }
                catch (FormatException fe)
                {
                    ErrorHandler.CreateLogFile("DashboardView", "RequestDataGridView_CellContentDoubleClick", fe);
                }
            }
        }
    }
}
