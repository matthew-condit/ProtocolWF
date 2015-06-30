using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toxikon.ProtocolManager.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public bool IsActive { get; set; }

        public Department()
        {
            DepartmentID = 0;
            DepartmentName = "";
            IsActive = true;
        }

        public Department(string departmentName)
        {
            this.DepartmentName = departmentName;
            this.IsActive = true;
        }

        public void SetDepartment(string departmentID, string departmentName)
        {
            this.DepartmentID = departmentID == "" ? 0 : Convert.ToInt32(departmentID);
            this.DepartmentName = departmentName;
        }
    }
}
