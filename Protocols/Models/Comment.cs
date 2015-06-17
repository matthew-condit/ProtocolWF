using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocols.Models
{
    public class Comment
    {
        public DateTime AddedDate { get; set; }
        public string AddedBy { get; set; }
        public string Content { get; set; }

        public Comment()
        {
            this.AddedDate = DateTime.Now;
            this.AddedBy = "";
            this.Content = "";
        }
    }
}
