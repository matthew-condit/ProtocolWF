using Toxikon.ProtocolManager.Interfaces.Admin;
using Toxikon.ProtocolManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Toxikon.ProtocolManager.Controllers.Admin
{
    public class DepartmentEditController
    {
        IDepartmentEditView view;
        public Department Department { get; private set; }

        public DepartmentEditController(IDepartmentEditView view)
        {
            this.view = view;
            this.view.SetController(this);
            this.view.IsActive = true;
            this.view.SetIsActiveRadioButtonGroup_Enable(false);
            this.Department = new Department();
        }

        public DepartmentEditController(IDepartmentEditView view, Department department)
        {
            this.view = view;
            this.view.SetController(this);
            this.Department = department;
            this.view.DepartmentName = department.DepartmentName;
            this.view.IsActive = department.IsActive;
            this.view.SetIsActiveRadioButtonGroup_Enable(true);
        }

        public void SubmitButtonClicked()
        {
            try
            {
                if(view.DepartmentName.Trim() == "")
                {
                    SubmitInvalidDepartmentNameHandler();
                }
                else
                {
                    SubmitValidDepartmentNameHandler();
                }
            }
            catch(Exception e)
            {
                ShowMessage(e.Message);
            }
        }

        private void SubmitInvalidDepartmentNameHandler()
        {
            view.SetDialogResult(DialogResult.Retry);
            ShowMessage("Department name is required.");
        }

        private void SubmitValidDepartmentNameHandler()
        {
            this.Department.SetDepartmentName(view.DepartmentName);
            this.Department.IsActive = view.IsActive;
            view.SetDialogResult(DialogResult.OK);
        }

        private void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

    }
}
