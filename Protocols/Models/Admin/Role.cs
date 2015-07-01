using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toxikon.ProtocolManager.Queries;

namespace Toxikon.ProtocolManager.Models
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

        public void Submit(string roleName, bool isActive)
        {
            LoginInfo loginInfo = LoginInfo.GetInstance();
            this.RoleName = roleName;
            this.IsActive = isActive;
            QRoles.InsertItem(this.RoleName, loginInfo.UserName);
        }

        public void Update(string roleName, bool isActive)
        {
            LoginInfo loginInfo = LoginInfo.GetInstance();
            this.RoleName = roleName;
            this.IsActive = isActive;
            QRoles.UpdateItem(this, loginInfo.UserName);
        }
    }
}
