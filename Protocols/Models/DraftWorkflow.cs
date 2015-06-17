using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocols.Models
{
    public class DraftWorkflow : ProtocolWorkflow
    {
        public bool SentOutDraft { get; set; }
        public DateTime SentOutDraftDate { get; set; }
        public bool ReceivedDraft { get; set; }
        public DateTime ReceivedDraftDate { get; set; }
        public bool InternalReviewed { get; set; }
        public DateTime InternalReviewedDate { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
