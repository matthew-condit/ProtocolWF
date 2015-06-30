using Toxikon.ProtocolManager.Interfaces.Admin;
using Toxikon.ProtocolManager.Models;
using Toxikon.ProtocolManager.Queries;
using Toxikon.ProtocolManager.Views;
using Toxikon.ProtocolManager.Views.Admin;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.ProtocolManager.Views.Templates;
using Toxikon.ProtocolManager.Controllers.Templates;

namespace Toxikon.ProtocolManager.Controllers.Admin
{
    public class DepartmentListController
    {
        IDepartmentListView view;
        IList departments;
        Department selectedDepartment;
        LoginInfo loginInfo;

        public DepartmentListController(IDepartmentListView view)
        {
            this.view = view;
            this.view.SetController(this);
            this.departments = new ArrayList();
            loginInfo = LoginInfo.GetInstance();
        }

        public void LoadView()
        {
            LoadDepartmentList();
            AddDepartmentListToView();
        }

        public void LoadDepartmentList()
        {
            departments.Clear();
            departments = QDepartments.SelectItems();
        }

        private void AddDepartmentListToView()
        {
            view.ClearView();
            foreach (Department department in departments)
            {
                view.AddItemToListView(department);
            }
        }

        public void ListViewSelectedIndexChanged(int selectedIndex)
        {
            if(selectedIndex > -1 && selectedIndex < departments.Count)
            {
                selectedDepartment = (Department)departments[selectedIndex];
            }
            else
            {
                selectedDepartment = null;
            }
        }

        public void NewButtonClicked()
        {
            Department department = new Department();
            ListItem result = ShowPopup(department);
            if (result.Value != String.Empty)
            {
                InsertNewDepartment(department, result);
                LoadView();
            }
        }

        private void InsertNewDepartment(Department department, ListItem result)
        {
            department.DepartmentName = result.Value;
            department.IsActive = result.IsActive;
           
            int dbresult = QDepartments.InsertItem(department, loginInfo.UserName);
            MessageBox.Show("New department is added.");
        }

        public void UpdateButtonClicked()
        {
            if (this.selectedDepartment == null)
            {
                MessageBox.Show("Please select one department and try it again.");
            }
            else
            {
                ListItem result = ShowPopup(this.selectedDepartment);
                if (result.Value != String.Empty)
                {
                    UpdateDepartment(result);
                    LoadView();
                }
            }
        }

        private void UpdateDepartment(ListItem result)
        {
            this.selectedDepartment.DepartmentName = result.Value;
            this.selectedDepartment.IsActive = result.IsActive;
            QDepartments.UpdateItem(this.selectedDepartment, loginInfo.UserName);
        }

        private ListItem ShowPopup(Department department)
        {
            ListItem textBoxItem = new ListItem("Department: ", department.DepartmentName);
            ListItem trueFalseItem = new ListItem("Active: ", department.IsActive.ToString());
            ListItem result = TemplatesController.ShowOneTextBoxTrueFalseForm(textBoxItem, trueFalseItem,
                               this.view.ParentControl);
            return result;
        }
    }
}
