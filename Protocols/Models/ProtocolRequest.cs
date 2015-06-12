using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocols.Models
{
    public class ProtocolRequest
    {
        public int ID { get; set; }
        public string RequestedBy { get; set; }
        public DateTime RequestedDate { get; set; }
        public string MatrixSponsorCode { get; set; }
        public string Guidelines { get; set; }
        public string Compliance { get; set; }
        public string ProtocolType { get; set; }
        public List<string> Titles { get; set; }
        public DateTime DueDate { get; set; }
        public string SendMethod { get; set; }
        public string BillTo { get; set; }
        public List<string> Comments { get; set; }

        public string ReceivedBy { get; set; }
        public DateTime ReceivedDate { get; set; }
        public DateTime EffectiveDate { get; set; }
        public string ProtocolNumber { get; set; }
        public string RequestStatus { get; set; }

        public ProtocolRequest()
        {
            Refresh();
        }

        public void Refresh()
        {
            RequestedBy = "";
            RequestedDate = DateTime.Now;
            MatrixSponsorCode = "";
            Guidelines = "";
            Compliance = "";
            ProtocolType = "";
            Titles = new List<string>() { };
            DueDate = DateTime.Now;
            BillTo = "Toxikon";
            Comments = new List<string>() { };

            ReceivedBy = "";
            ReceivedDate = DateTime.Now;
            EffectiveDate = DateTime.Now;
            ProtocolNumber = "";
            RequestStatus = "";
        }
    }
}
