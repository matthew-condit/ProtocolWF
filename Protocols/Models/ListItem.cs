using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocols.Models
{
    public class ListItem
    {
        public string ListName { get; set; }
        public string ItemName { get; set; }
        public bool IsActive { get; set; }

        public ListItem()
        {
            this.ListName = "";
            this.ItemName = "";
            this.IsActive = true;
        }
    }
}
