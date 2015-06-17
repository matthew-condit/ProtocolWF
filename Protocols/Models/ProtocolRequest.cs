using Protocols.Queries;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
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
        public string SponsorCode { get; set; }
        public Sponsor Sponsor { get; private set; }
        public string Guidelines { get; set; }
        public string Compliance { get; set; }
        public string ProtocolType { get; set; }
        public List<string> Titles { get; set; }
        public DateTime DueDate { get; set; }
        public string SendMethod { get; set; }
        public string BillTo { get; set; }
        public List<Comment> Comments { get; set; }

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
            this.ID = 0;
            RequestedBy = "";
            RequestedDate = DateTime.Now;
            SponsorCode = "";
            this.Sponsor = new Models.Sponsor();
            Guidelines = "";
            Compliance = "";
            ProtocolType = "";
            Titles = new List<string>() { };
            DueDate = DateTime.Now;
            BillTo = "Toxikon";
            Comments = new List<Comment>() { };

            ReceivedBy = "";
            ReceivedDate = DateTime.Now;
            EffectiveDate = DateTime.Now;
            ProtocolNumber = "";
            RequestStatus = "";
        }

        public void SetSponsor()
        {
            this.Sponsor = QMatrix.GetSponsorBySponsorCode(this.SponsorCode);
        }

        public Image RequestStatusImage()
        {
            Image result = null;
            switch (this.RequestStatus)
            {
                case RequestStatuses.Submitted:
                    result = Properties.Resources.NGreen;
                    break;
                case RequestStatuses.Received:
                    result = Properties.Resources.RGreen;
                    break;
                case RequestStatuses.PutUp:
                    result = Properties.Resources.IGreen;
                    break;
                case RequestStatuses.AssignedWorkflow:
                    result = Properties.Resources.CGreen;
                    break;
                default:
                    break;
            }
            return result;
        }
    }
}
