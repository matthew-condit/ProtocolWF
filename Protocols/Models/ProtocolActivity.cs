using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocols.Models
{
    public class ProtocolActivity
    {
        public int ProtocolRequestID { get; set; }
        public int ProtocolTitleID { get; set; }
        public ProtocolEvent ProtocolEvent { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public ProtocolActivity()
        {
            this.ProtocolRequestID = 0;
            this.ProtocolTitleID = 0;
            this.ProtocolEvent = new ProtocolEvent();
            this.CreatedBy = "";
            this.CreatedDate = DateTime.Now;
        }
    }
}
