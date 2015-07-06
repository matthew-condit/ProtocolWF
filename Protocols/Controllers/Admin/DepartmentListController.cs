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
using Toxikon.ProtocolManager.Interfaces.Templates;

namespace Toxikon.ProtocolManager.Controllers.Admin
{
    public class DepartmentListController : UCToolStripListView1Controller
    {
        IUCToolStripListView1 view;
        IList departments;
        Department selectedDepartment;
        LoginInfo loginInfo;

        public DepartmentListController(IUCToolStripListView1 view)
        {
            this.view = view;
            this.view.SetController(this);
            this.departments = new ArrayList();
            loginInfo = LoginInfo.GetInstance();
        }

        public override void LoadView()
        {
            departments.Clear();
            view.ClearView();

            IList columns = new ArrayList(){"ID", "Department", "Active"};
            this.view.AddListViewColumns(columns);
            this.view.ListTitle = "Departments";
            departments = QDepartments.SelectItems();
          
            AddDepartmentListToView();
            SetColumnsHeaderSize();
        }

        private void AddDepartmentListToView()
        {
            foreach (Department department in departments)
            {
                view.AddItemToListView(department);
            }
        }

        private void SetColumnsHeaderSize()
        {
            this.view.SetListViewAutoResizeColumns(0, ColumnHeaderAutoResizeStyle.ColumnContent);
            this.view.SetListViewAutoResizeColumns(1, ColumnHeaderAutoResizeStyle.ColumnContent);
            this.view.SetListViewAutoResizeColumns(2, ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        public override void ListViewSelectedIndexChanged(int selectedIndex)
        {
            if(selectedIndex > -1 && selectedIndex < departments.Count)
            {
                selectedDepartment = (Department)departments[selectedIndex];
            }
        }

        public override void NewButtonClicked()
        {
            Department department = new Department();
            Item result = ShowPopup(department);
            if (result.Value != String.Empty)
            {
                department.Insert(result.Value, result.IsActive);
                MessageBox.Show("New department is added.");
                LoadView();
            }
        }

        public override void UpdateButtonClicked()
        {
            if (this.selectedDepartment == null)
            {
                MessageBox.Show("Please select one department and try it again.");
            }
            else
            {
                Item result = ShowPopup(this.selectedDepartment);
                if (result.Value != String.Empty)
                {
                    this.selectedDepartment.Update(result.Value, result.IsActive);
                    LoadView();
                }
            }
        }

        private Item ShowPopup(Department department)
        {
            Item textBoxItem = new Item("Department: ", department.Name);
            Item trueFalseItem = new Item("Active: ", department.IsActive.ToString());
            Item result = TemplatesController.ShowOneTextBoxTrueFalseForm(textBoxItem, trueFalseItem,
                               this.view.ParentControl);
            return result;
        }
    }
}
