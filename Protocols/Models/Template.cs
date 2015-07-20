using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toxikon.ProtocolManager.Models
{
    public class Template
    {
        public int ID { get; set; }
        public int GroupID { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }

        public Template()
        {
            this.ID = 0;
            this.GroupID = 0;
            this.Title = "";
            this.IsActive = false;
        }
    }
}
