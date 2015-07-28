using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toxikon.ProtocolManager.Models.Admin
{
    public class DepartmentDirector
    {
        public int ID { get; set; }
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public bool IsActive { get; set; }

        public DepartmentDirector()
        {
            this.ID = 0;
            this.DepartmentID = 0;
            this.DepartmentName = "";
            this.UserName = "";
            this.FullName = "";
            this.IsActive = false;
        }
    }
}
