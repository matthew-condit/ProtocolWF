using Toxikon.ProtocolManager.Controllers.Admin;
using Toxikon.ProtocolManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Toxikon.ProtocolManager.Interfaces.Admin
{
    public interface IUserEditView
    {
        void SetController(UserEditController controller);
        void SetUpdateMode();
        void SetNewMode();

        void SetDialogResult(DialogResult dialogResult);
        void AddDepartmentToComboBox(Department department);
        void AddRoleToComboBox(Role role);

        string UserName { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string FullName { get; set; }
        string EmailAddress { get; set; }
        Department Department { get; set; }
        Role Role { get; set; }
        bool IsActive { get; set; }
    }
}
