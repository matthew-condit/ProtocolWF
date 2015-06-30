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

        public ListItem(string name, string value)
        {
            this.Name = name;
            this.Value = value;
            this.Text = value;
            this.IsActive = true;
        }

        public ListItem(string name, string text, string value, bool isActive)
        {
            this.Name = name;
            this.Text = text;
            this.Value = value;
            this.IsActive = isActive;
        }
    }
}
