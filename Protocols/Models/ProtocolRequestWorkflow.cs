using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocols.Models
{
    public class ProtocolRequestWorkflow
    {
        public bool Submitted { get; set; }
        public DateTime SubmittedDate { get; set; }
        public bool Received { get; set; }
        public DateTime ReceivedDate { get; set; }
        public bool InProcess { get; set; }
        public DateTime InProcessDate { get; set; }
        public bool Completed { get; set; }
        public DateTime CompletedDate { get; set; }
        public bool Cancelled { get; set; }
        public DateTime CancelledDate { get; set; }

        public ProtocolRequestWorkflow()
        {
            this.Submitted = true;
            this.Received = false;
            this.InProcess = false;
            this.Completed = false;
            this.Cancelled = false;
        }
    }
}
