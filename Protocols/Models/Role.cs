using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocols.Models
{
    public class Role
    {
        public Int32 RoleID { get; set; }
        public string RoleName { get; set; }
        public bool IsActive { get; set; }

        public Role()
        {
            this.RoleID = 0;
            this.RoleName = "";
            this.IsActive = true;
        }

        public void SetRole(string roleID, string roleName)
        {
            this.RoleID = Convert.ToInt32(roleID);
            this.RoleName = roleName;
        }
    }
}
