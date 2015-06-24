using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toxikon.ProtocolManager.Models
{
    public class Comment
    {
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string Content { get; set; }

        public Comment()
        {
            this.CreatedDate = DateTime.Now;
            this.CreatedBy = "";
            this.Content = "";
        }
    }
}
