using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toxikon.ProtocolManager.Interfaces.Admin;
using Toxikon.ProtocolManager.Models;
using Toxikon.ProtocolManager.Models.Admin;
using Toxikon.ProtocolManager.Queries;

namespace Toxikon.ProtocolManager.Controllers.Admin
{
    public class DepartmentDirectorsController
    {
        private IDepartmentDirectorsView view;
        private IList departments;
        private IList directors;
        private IList departmentDirectors;

        private Department selectedDepartment;
        private User selectedDirector;
        private DepartmentDirector selectedDepartmentDirector;

        public DepartmentDirectorsController(IDepartmentDirectorsView view)
        {
            this.view = view;
            this.view.SetController(this);
            this.departments = new ArrayList();
            this.directors = new ArrayList();
            this.departmentDirectors = new ArrayList();
        }

        public void LoadView()
        {
            this.departments = QDepartments.SelectItems();
            this.directors = QUsers.SelectUsersByRoleID(UserRoles.DepartmentDirector);

            AddDepartmentsToView();
            AddDirectorsToView();
            AddDepartmentDirectorsToView();
        }

        private void ClearView()
        {
            this.departmentDirectors.Clear();
            this.selectedDepartment = null;
            this.selectedDirector = null;
            this.selectedDepartmentDirector = null;
            this.view.ClearView();
        }

        private void AddDepartmentsToView()
        {
            foreach(Department department in this.departments)
            {
                this.view.AddDepartmentToView(department);
            }
        }

        private void AddDirectorsToView()
        {
            foreach(User user in this.directors)
            {
                this.view.AddDirectorsToView(user);
            }
        }

        private void AddDepartmentDirectorsToView()
        {
            foreach(DepartmentDirector item in departmentDirectors)
            {
                this.view.AddItemToListView(item);
            }
        }

        public void AddButtonClicked()
        {
            if(this.selectedDepartment != null && this.selectedDirector != null)
            {
                CreateAndSubmitDepartmentDirector();
            }
        }

        private void CreateAndSubmitDepartmentDirector()
        {
            DepartmentDirector item = new DepartmentDirector();
            item.DepartmentID = this.selectedDepartment.ID;
            item.UserName = this.selectedDirector.UserName;

            QDepartmentDirectors.InsertItem(item);
        }
    }
}
