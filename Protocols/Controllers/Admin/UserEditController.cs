using Toxikon.ProtocolManager.Interfaces.Admin;
using Toxikon.ProtocolManager.Models;
using Toxikon.ProtocolManager.Queries;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Toxikon.ProtocolManager.Controllers.Admin
{
    public class UserEditController
    {
        IUserEditView view;
        IList departments;
        IList roles;
        public User User { get; private set; }

        public UserEditController(IUserEditView view)
        {
            User = new User();
            departments = new ArrayList();
            roles = new ArrayList();

            this.view = view;
            this.view.SetController(this);
            this.LoadDepartments();
            this.LoadRoles();
            this.view.SetNewMode();
            UpdateViewWithUser();
        }

        public UserEditController(IUserEditView view, User user)
        {
            this.User = user;
            departments = new ArrayList();
            roles = new ArrayList();

            this.view = view;
            this.view.SetController(this);
            this.LoadDepartments();
            this.LoadRoles();
            this.view.SetUpdateMode();

            this.User.Department = GetDepartmentByID(user.Department.DepartmentID);
            this.User.Role = GetRoleByID(user.Role.RoleID);

            UpdateViewWithUser();
        }

        private void LoadDepartments()
        {
            departments = QDepartments.GetDepartments();
            foreach(Department department in departments)
            {
                view.AddDepartmentToComboBox(department);
            }
        }

        private Department GetDepartmentByID(int id)
        {
            Department result = new Department();
            foreach(Department department in departments)
            {
                if(department.DepartmentID == id)
                {
                    result = department;
                    break;
                }
            }
            return result;
        }

        private void LoadRoles()
        {
            roles = QRoles.GetRoles();
            foreach(Role role in roles)
            {
                view.AddRoleToComboBox(role);
            }
        }

        private Role GetRoleByID(int id)
        {
            Role result = new Role();
            foreach(Role role in roles)
            {
                if(role.RoleID == id)
                {
                    result = role;
                    break;
                }
            }
            return result;
        }

        private void UpdateViewWithUser()
        {
            this.view.UserName = User.UserName;
            this.view.FirstName = User.FirstName;
            this.view.LastName = User.LastName;
            this.view.FullName = User.FullName;
            this.view.EmailAddress = User.EmailAddress;
            this.view.Department = User.Department;
            this.view.Role = User.Role;
            this.view.IsActive = User.IsActive;
        }

        private void UpdateUserWithViewValues()
        {
            this.User.UserName = view.UserName;
            this.User.FirstName = view.FirstName;
            this.User.LastName = view.LastName;
            this.User.FullName = view.FullName;
            this.User.EmailAddress = view.EmailAddress;
            this.User.Department = view.Department;
            this.User.Role = view.Role;
            this.User.IsActive = Convert.ToBoolean(view.IsActive);
        }

        public void SearchButtonClicked(string searchString)
        {
            try
            {
                if(searchString.Trim() != "")
                {
                    IList searchResults = QTMS.GetResultsFromSearchEmployee(searchString);
                    if(searchResults.Count == 0)
                    {
                        MessageBox.Show("No record found.");
                    }
                    else
                    {
                        this.User = (User)searchResults[0];
                        UpdateViewWithUser();
                    }
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void SubmitButtonClicked()
        {
            try
            {
                UpdateUserWithViewValues();
                view.SetDialogResult(DialogResult.OK);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
