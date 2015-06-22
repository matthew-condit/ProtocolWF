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

        public void SetDataGridViewCheckBoxCell_BackColor(ProtocolRequest request, int rowIndex)
        {
            DataGridViewRow row = this.RequestDataGridView.Rows[rowIndex];
            row.Cells[3].Style.BackColor = request.Workflow.Submitted ? Color.LightGoldenrodYellow : Color.White;
            row.Cells[3].Style.SelectionBackColor = row.Cells[3].Style.BackColor;

            row.Cells[4].Style.BackColor = request.Workflow.Received ? Color.LemonChiffon : Color.White;
            row.Cells[4].Style.SelectionBackColor = row.Cells[4].Style.BackColor;

            row.Cells[5].Style.BackColor = request.Workflow.InProcess ? Color.PaleGoldenrod : Color.White;
            row.Cells[5].Style.SelectionBackColor = row.Cells[5].Style.BackColor;

            row.Cells[6].Style.BackColor = request.Workflow.Completed ? Color.DarkKhaki : Color.White;
            row.Cells[6].Style.SelectionBackColor = row.Cells[6].Style.BackColor;

            row.Cells[7].Style.BackColor = request.Workflow.Cancelled ? Color.Tomato : Color.White;
            row.Cells[7].Style.SelectionBackColor = row.Cells[7].Style.BackColor;

            this.RequestDataGridView.Refresh();
        }

        /*public void AddProtocolRequestToView(ProtocolRequest request)
        {
            ProtocolRequestWorkflowView workflowControl = new ProtocolRequestWorkflowView();
            workflowControl.SetProtocolRequest(request);
            this.ProtocolRequestPanel.Controls.Add(workflowControl);
            workflowControl.Width = 800;
            workflowControl.Height = 25;
        }*/

        public void AddProtocolToView(Protocol protocol)
        {
            if (protocol.WorkflowType == ProtocolEventTypes.Protocol)
            {
                ProtocolWorkflowRow prow = new ProtocolWorkflowRow();
                prow.SetProtocol(protocol);
                //this.ProtocolFlowLayoutPanel.Controls.Add(prow);
                prow.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            }
            else if(protocol.WorkflowType == ProtocolEventTypes.Draft)
            {
                DraftWorkflowRow drow = new DraftWorkflowRow();
            }
        }

        private void RequestDataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.controller.RequestDataGridViewCellDoubleClicked(e.RowIndex);
        }

        private void RequestDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex >= 3 && e.ColumnIndex <= 7 && e.RowIndex != -1)
            {
                DataGridViewColumn col = this.RequestDataGridView.Columns[e.ColumnIndex];
                DataGridViewCheckBoxCell cell = this.RequestDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]
                    as DataGridViewCheckBoxCell;
                this.controller.CheckBoxCellClicked(col.Name, e.RowIndex, (bool)cell.Value);
            }
        }
    }
}
