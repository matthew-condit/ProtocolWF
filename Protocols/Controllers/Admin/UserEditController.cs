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
using Toxikon.ProtocolManager.Models.Admin;

namespace Toxikon.ProtocolManager.Controllers.Admin
{
    public class UserEditController
    {
        IUserEditView view;
        IList departments;
        IList roles;
        List<AuditItem> auditItems;
        private LoginInfo loginInfo;
        public User User { get; private set; }

        public UserEditController(IUserEditView view, User user)
        {
            this.User = user;
            departments = new ArrayList();
            roles = new ArrayList();
            this.view = view;
            this.view.SetController(this);
            auditItems = new List<AuditItem>();
            loginInfo = LoginInfo.GetInstance();
        }

        public void LoadView()
        {
            this.LoadDepartments();
            this.LoadRoles();
            if(User.UserName == String.Empty)
            {
                this.view.SetNewMode();
            }
            else
            {
                LoadUpdateMode();
            }
        }

        private void LoadUpdateMode()
        {
            this.view.SetUpdateMode();
            this.User.Department = GetDepartmentByID(this.User.Department.ID);
            this.User.Role = GetRoleByID(this.User.Role.RoleID);
            UpdateViewWithUser();
        }

        private void LoadDepartments()
        {
            departments = QDepartments.SelectItems();
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
                if(department.ID == id)
                {
                    result = department;
                    break;
                }
            }
            return result;
        }

        private void LoadRoles()
        {
            roles = QRoles.SelectItems();
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
                SubmitAuditItems();
                UpdateUserWithViewValues();
                view.SetDialogResult(DialogResult.OK);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void SubmitAuditItems()
        {
            CreateAuditItems();
            if(this.auditItems.Count != 0)
            {
                AuditHandler.InsertAuditItems(this.auditItems);
                this.auditItems.Clear();
            }
        }

        private void CreateAuditItems()
        {
            CheckAndAddToAuditItems("FirstName", this.User.FirstName, this.view.FirstName);
            CheckAndAddToAuditItems("LastName", this.User.LastName, this.view.LastName);
            CheckAndAddToAuditItems("FullName", this.User.FullName, this.view.FullName);
            CheckAndAddToAuditItems("EmailAddress", this.User.EmailAddress, this.view.EmailAddress);
            CheckAndAddToAuditItems("DepartmentID", this.User.Department.ID.ToString(),
                                    this.view.Department.ID.ToString());
            CheckAndAddToAuditItems("RoleID", this.User.Role.RoleID.ToString(), this.view.Role.RoleID.ToString());
            CheckAndAddToAuditItems("IsActive", this.User.IsActive.ToString(), this.view.IsActive.ToString());
        }

        private void CheckAndAddToAuditItems(string fieldName, string oldValue, string newValue)
        {
            if (oldValue.Trim() != newValue.Trim())
            {
                AuditItem item = CreateAuditItem(fieldName, oldValue, newValue);
                this.auditItems.Add(item);
            }
        }

        private AuditItem CreateAuditItem(string fieldName, string oldValue, string newValue)
        {
            AuditItem item = new AuditItem();
            item.TableName = "Users";
            item.Type = "U";
            item.PK = "UserName";
            item.PKValue = this.User.UserName;
            item.FieldName = fieldName;
            item.OldValue = oldValue.Trim() == String.Empty ? "N/A" : oldValue;
            item.NewValue = newValue;
            item.UpdatedBy = loginInfo.UserName;
            item.Reason = "Update using Save Changes button.";

            return item;
        }
    }
}
