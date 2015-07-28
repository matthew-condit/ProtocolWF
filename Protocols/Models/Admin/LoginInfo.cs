using Toxikon.ProtocolManager.Queries;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Toxikon.ProtocolManager.Models
{
    public class LoginInfo
    {
        private static LoginInfo _instance;
        private User user;

        private LoginInfo()
        {
            user = new User();
            user = QUsers.SelectUser(Environment.UserName);
            //user.Role.RoleID = 5;
            //user.UserName = "cschondelmeyer";//Environment.UserName;
            //user.FullName = "Bichngoc McCulley";// UserPrincipal.Current.DisplayName;*/
        }

        public static LoginInfo GetInstance()
        {
            if (_instance == null)
            {
                _instance = new LoginInfo();
            }
            return _instance;
        }

        public string UserName
        {
            get { return this.user.UserName; }
        }

        public string FullName
        {
            get { return this.user.FullName; }
        }

        public Role Role
        {
            get { return this.user.Role; }
        }
    }
}
