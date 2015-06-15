using Protocols.Queries;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Protocols.Models
{
    public class LoginInfo
    {
        private static LoginInfo _instance;
        private User user;

        private LoginInfo()
        {
            user = new User();
            user = QUsers.GetUser(Environment.UserName);
            
            //user.UserName = Environment.UserName;
            //user.FullName = UserPrincipal.Current.DisplayName;
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
