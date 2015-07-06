using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toxikon.ProtocolManager.Queries;

namespace Toxikon.ProtocolManager.Models
{
    public class Department
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public Department()
        {
            ID = 0;
            Name = "";
            IsActive = true;
        }

        public Department(string departmentName)
        {
            this.Name = departmentName;
            this.IsActive = true;
        }

        public void SetDepartment(string departmentID, string departmentName)
        {
            this.ID = departmentID == "" ? 0 : Convert.ToInt32(departmentID);
            this.Name = departmentName;
        }

        public void Insert(string departmentName, bool isActive)
        {
            LoginInfo loginInfo = LoginInfo.GetInstance();
            this.Name = departmentName;
            this.IsActive = isActive;
            int dbresult = QDepartments.InsertItem(this, loginInfo.UserName);
        }

        public void Update(string departmentName, bool isActive)
        {
            LoginInfo loginInfo = LoginInfo.GetInstance();
            this.Name = departmentName;
            this.IsActive = isActive;
            QDepartments.UpdateItem(this, loginInfo.UserName);
        }
    }
}
