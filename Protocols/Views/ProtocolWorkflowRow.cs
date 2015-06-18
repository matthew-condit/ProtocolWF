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
    public partial class ProtocolWorkflowRow : UserControl
    {
        public ProtocolWorkflowRow()
        {
            InitializeComponent();
        }

        public void SetProtocol(Protocol protocol)
        {
            this.SetProtocolWorkflow(protocol.ProtocolWorkflow);
        }

        private void SetProtocolWorkflow(ProtocolWorkflow item)
        {
            this.SubmittedLabel.BackColor = item.Submitted ? Color.DarkSeaGreen : Color.Gainsboro;
            this.ReceivedLabel.BackColor = item.Received ? Color.DarkSeaGreen : Color.Gainsboro;
            this.PuUpLabel.BackColor = item.PutUp ? Color.DarkSeaGreen : Color.Gainsboro;
            this.SentOutProtocolLabel.BackColor = item.SentOutProtocol ? Color.DarkSeaGreen : Color.Gainsboro;
            this.ReceivedSponsorSignatureLabel.BackColor = item.ReceviedSponsorSignature ? 
                                                           Color.DarkSeaGreen : Color.Gainsboro;
            this.QALabel.BackColor = item.SentToQA ? Color.DarkSeaGreen : Color.Gainsboro;
            this.ActivatedLabel.BackColor = item.Activated ? Color.DarkSeaGreen : Color.Gainsboro;
            this.LogInLabel.BackColor = item.SentToLogIn ? Color.DarkSeaGreen : Color.Gainsboro;
        }
    }
}
