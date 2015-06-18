using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Protocols.Models;

namespace Protocols.Views
{
    public partial class ProtocolRequestWorkflowView : UserControl
    {
        ProtocolRequestWorkflow workflow;

        public ProtocolRequestWorkflowView()
        {
            InitializeComponent();
        }

        public void SetProtocolRequest(ProtocolRequest request)
        {
            this.RequestedDateLabel.Text = request.RequestedDate.ToString("MM/dd/yyyy");
            this.RequestedByLabel.Text = request.RequestedBy;
            this.SponsorLabel.Text = request.Sponsor.SponsorName;

            workflow = request.Workflow;
            this.SubmittedLabel.LinkVisited = workflow.Submitted;
            this.SubmittedLabel.BackColor = workflow.Submitted ? Color.DarkSeaGreen : Color.Gainsboro;
            this.ReceivedLabel.LinkVisited = workflow.Received;
            this.ReceivedLabel.BackColor = workflow.Received ? Color.DarkSeaGreen : Color.Gainsboro;
            this.InProcessLabel.LinkVisited = workflow.InProcess;
            this.InProcessLabel.BackColor = workflow.InProcess ? Color.DarkSeaGreen : Color.Gainsboro;
            this.CompletedLabel.LinkVisited = workflow.Completed;
            this.CompletedLabel.BackColor = workflow.Completed ? Color.DarkSeaGreen : Color.Gainsboro;
        }

        private void StatusLabel_MouseHover(object sender, EventArgs e)
        {
            if (sender is ToolStripLabel)
            {
                ToolStripLabel item = (ToolStripLabel)sender;
                if(item.BackColor == Color.Gainsboro)
                {
                    item.BackColor = Color.DarkSeaGreen;
                }
            }
        }

        private void StatusLabel_MouseLeave(object sender, EventArgs e)
        {
            if (sender is ToolStripLabel)
            {
                ToolStripLabel item = (ToolStripLabel)sender;
                if (item.BackColor == Color.DarkSeaGreen && !item.LinkVisited)
                {
                    item.BackColor = Color.Gainsboro;
                }
            }
        }
    }
}
