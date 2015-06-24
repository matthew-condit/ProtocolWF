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

namespace Toxikon.ProtocolManager.Controllers.Admin
{
    public class DepartmentListController
    {
        IDepartmentListView view;
        IList departments;
        Department selectedDepartment;

        public DepartmentListController(IDepartmentListView view)
        {
            this.view = view;
            this.view.SetController(this);
            this.departments = new ArrayList();
        }

        public void LoadView()
        {
            LoadDepartmentList();
            AddDepartmentListToView();
        }

        public void LoadDepartmentList()
        {
            departments.Clear();
            departments = QDepartments.GetDepartments();
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
            DepartmentEditView popup = new DepartmentEditView();
            DepartmentEditController popupController = new DepartmentEditController(popup);

            DialogResult dialogResult = popup.ShowDialog(view.ParentControl);
            if (dialogResult == DialogResult.OK)
            {
                Department department = popupController.Department;
                InsertNewDepartment(department);
                LoadView();
            }
            popup.Dispose();
        }

        private void InsertNewDepartment(Department department)
        {
            LoginInfo loginInfo = LoginInfo.GetInstance();
            Int32 result = QDepartments.InsertDepartment(department, loginInfo.UserName);
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
                DepartmentEditView popup = new DepartmentEditView();
                DepartmentEditController popupController = new DepartmentEditController(popup,
                                            this.selectedDepartment);

                DialogResult dialogResult = popup.ShowDialog(view.ParentControl);
                if (dialogResult == DialogResult.OK)
                {
                    UpdateDepartment();
                    LoadView();
                }
                popup.Dispose();
            }
        }

        private void UpdateDepartment()
        {
            LoginInfo loginInfo = LoginInfo.GetInstance();
            QDepartments.UpdateDepartment(this.selectedDepartment, loginInfo.UserName);
        }
    }
}
