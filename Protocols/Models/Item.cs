using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toxikon.ProtocolManager.Models
{
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string Value { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        public Item()
        {
            this.ID = 0;
            this.Name = "";
            this.Text = "";
            this.Value = "";
            this.IsActive = true;
            this.CreatedBy = "";
            this.CreatedDate = DateTime.Now;
            this.UpdatedBy = "";
            this.UpdatedDate = DateTime.Now;
        }

        public Item(string name, string value)
        {
            this.ID = 0;
            this.Name = name;
            this.Value = value;
            this.Text = value;
            this.IsActive = true;
            this.CreatedBy = "";
            this.CreatedDate = DateTime.Now;
            this.UpdatedBy = "";
            this.UpdatedDate = DateTime.Now;
        }

        public Item(string name, string text, string value, bool isActive)
        {
            this.ID = 0;
            this.Name = name;
            this.Text = text;
            this.Value = value;
            this.IsActive = isActive;
            this.CreatedBy = "";
            this.CreatedDate = DateTime.Now;
            this.UpdatedBy = "";
            this.UpdatedDate = DateTime.Now;
        }
    }
}
