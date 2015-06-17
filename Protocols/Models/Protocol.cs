using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocols.Models
{
    public class Protocol
    {
        public int ProtocolRequestID { get; set; }
        public string Title { get; set; }
        public string ProtocolNumber { get; set; }
        public string RequestedBy { get; set; }
        public DateTime RequestedDate { get; set; }
        public string DepartmentNumber { get; set; }
        public string StudyType { get; set; } // GLP, N-GLP, GMP
        public string ProjectNumber { get; set; }
        public string WorkflowType { get; set; } // Protocol or Draft
        public ProtocolWorkflow ProtocolWorkflow { get; set; }

        public Protocol()
        {
            this.ProtocolWorkflow = new ProtocolWorkflow();
        }
    }
}
