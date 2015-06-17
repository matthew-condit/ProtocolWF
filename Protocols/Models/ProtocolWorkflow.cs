using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocols.Models
{
    public class ProtocolWorkflow
    {
        public bool Submitted { get; set; }
        public DateTime SubmittedDate { get; set; }
        public bool Received { get; set; }
        public DateTime ReceivedDate { get; set; }
        public bool PutUp { get; set; }
        public DateTime PutUpDate { get; set; }
        public bool SentOutProtocol { get; set; }
        public DateTime SentOutProtocolDate { get; set; }
        public bool ReceviedSponsorSignature { get; set; }
        public DateTime ReceivedSponsorSignatureDate { get; set; }
        public bool SentToQA { get; set; }
        public DateTime SentToQADate { get; set; }
        public bool Activated { get; set; }
        public DateTime SetWorkflowActiveStatusDate { get; set; }
        public bool SentToLogIn { get; set; }
        public DateTime SentToLogInDate { get; set; }

        public ProtocolWorkflow()
        {
            this.Submitted = true;
            this.Received = false;
            this.PutUp = false;
            this.SentOutProtocol = false;
            this.ReceviedSponsorSignature = false;
            this.SentToQA = false;
            this.Activated = false;
            this.SentToLogIn = false;
        }
    }
}
