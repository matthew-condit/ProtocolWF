using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toxikon.ProtocolManager.Queries;

namespace Toxikon.ProtocolManager.Models
{
    public class ProtocolActivity
    {
        public int RequestID { get; set; }
        public int TemplateID { get; set; }
        public ProtocolEvent ProtocolEvent { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public ProtocolActivity()
        {
            this.RequestID = 0;
            this.TemplateID = 0;
            this.ProtocolEvent = new ProtocolEvent();
            this.CreatedBy = "";
            this.CreatedDate = DateTime.Now;
        }

        public ProtocolActivity(ProtocolTemplate title, int eventID, string createdBy)
        {
            this.RequestID = title.RequestID;
            this.TemplateID = title.TemplateID;
            this.ProtocolEvent = new ProtocolEvent(eventID);
            this.CreatedBy = createdBy;
        }

        public ProtocolActivity(int requestID, int templateID, int eventID, string createdBy)
        {
            this.RequestID = requestID;
            this.TemplateID = templateID;
            this.ProtocolEvent = new ProtocolEvent(eventID);
            this.CreatedBy = createdBy;
        }

        public void Submit()
        {
            QProtocolActivities.InsertItem(this);
        }
    }
}
