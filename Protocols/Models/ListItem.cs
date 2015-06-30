using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toxikon.ProtocolManager.Models
{
    public class ListItem
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public string Value { get; set; }
        public bool IsActive { get; set; }

        public ListItem()
        {
            this.Name = "";
            this.Text = "";
            this.Value = "";
            this.IsActive = true;
        }
    }
}
