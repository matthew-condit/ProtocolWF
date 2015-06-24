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
        public List<ProtocolTitle> Titles { get; private set; }
        public DateTime DueDate { get; set; }
        public string SendVia { get; set; }
        public string BillTo { get; set; }
        public string Comments { get; set; }
        public string AssignedTo { get; set; }
        public string Priority { get; set; }

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
            Titles = new List<ProtocolTitle>() { };
            DueDate = DateTime.Now;
            BillTo = "Toxikon";
            Comments = "";
            this.AssignedTo = "";
        }

        public void SetSponsor()
        {
            this.Sponsor = QMatrix.GetSponsorBySponsorCode(this.SponsorCode);
        }

        public void SetTitles(List<string> titleDescriptions)
        {
            foreach(string item in titleDescriptions)
            {
                ProtocolTitle protocolTitle = new ProtocolTitle();
                protocolTitle.Description = item;
                this.Titles.Add(protocolTitle);
            }
        }

        public void SetTitles(List<ProtocolTitle> items)
        {
            this.Titles = new List<ProtocolTitle>(items);
        }

        public void RefreshProtocolTitles()
        {
            this.Titles.Clear();
            this.Titles = (List<ProtocolTitle>)QProtocolTitles.SelectByRequestID(this.ID);
        }       
    }
}
