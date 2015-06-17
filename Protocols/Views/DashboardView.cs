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

        /*public void AddProtocolRequestToView(ProtocolRequest request)
        {
            this.RequestDataGridView.Rows.Add(request.RequestedDate.ToString("MM/dd/yyyy"),
                 request.RequestedBy, 
                 request.Sponsor.SponsorName, 
                 request.RequestStatusImage(),
                 request.Comments.Count.ToString());
        }*/

        public void AddProtocolToView(Protocol protocol)
        {
            if (protocol.WorkflowType == WorkflowTypes.Protocol)
            {
                ProtocolWorkflowRow prow = new ProtocolWorkflowRow();
                prow.SetProtocol(protocol);
                this.ProtocolFlowLayoutPanel.Controls.Add(prow);
                prow.Width = 795;
                prow.Height = 71;
            }
            else if(protocol.WorkflowType == WorkflowTypes.Draft)
            {
                DraftWorkflowRow drow = new DraftWorkflowRow();
            }
        }

        private void RequestDataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.controller.RequestDataGridViewCellDoubleClicked(e.RowIndex);
        }
    }
}
