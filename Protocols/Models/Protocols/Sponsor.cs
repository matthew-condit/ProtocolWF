using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toxikon.ProtocolManager.Models.Protocols
{
    public class Sponsor
    {
        public string SponsorCode { get; set; }
        public string SponsorName { get; set; }

        public Sponsor()
        {
            this.SponsorCode = "";
            this.SponsorName = "";
        }
    }
}
