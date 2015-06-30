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
    public class RoleListController
    {
        IRoleListView view;
        IList roles;
        Role selectedRole;

        public RoleListController(IRoleListView view)
        {
            this.view = view;
            this.view.SetController(this);
            roles = new ArrayList();
        }

        public void LoadView()
        {
            this.roles.Clear();
            this.view.ClearView();
            this.roles = QRoles.SelectItems();
            AddRolesToView();
        }

        private void AddRolesToView()
        {
            foreach (Role role in roles)
            {
                this.view.AddItemToListView(role);
            }
        }

        public void ListViewSelectedIndexChanged(int selectedIndex)
        {
            this.selectedRole = (Role)this.roles[selectedIndex];
        }

        public void NewButtonClicked()
        {
            OneTextBoxTrueFalseForm popup = new OneTextBoxTrueFalseForm();
            OneTextBoxTrueFalseFormController popupController = new OneTextBoxTrueFalseFormController(popup);
            popupController.SetTextBoxItem("Role: ", "");
            popupController.SetTrueFalseItem("Active: ", true);

            DialogResult dialogResult = popup.ShowDialog(view.ParentControl);
            if (dialogResult == DialogResult.OK)
            {
                Role role = new Role();
                role.RoleName = popupController.TextBoxValue;
                role.IsActive = popupController.TrueFalseValue;
                InsertNewRole(role);
                LoadView();
            }
            popup.Dispose();
        }

        private void InsertNewRole(Role role)
        {
            LoginInfo loginInfo = LoginInfo.GetInstance();
            QRoles.InsertItem(role.RoleName, loginInfo.UserName);
            MessageBox.Show("New role is added.");
        }

        public void UpdateButtonClicked()
        {
            if (this.selectedRole == null)
            {
                MessageBox.Show("Please select one role and try it again.");
            }
            else
            {
                OneTextBoxTrueFalseForm popup = new OneTextBoxTrueFalseForm();
                OneTextBoxTrueFalseFormController popupController = new OneTextBoxTrueFalseFormController(popup);
                popupController.SetTextBoxItem("Role: ", this.selectedRole.RoleName);
                popupController.SetTrueFalseItem("Active: ", this.selectedRole.IsActive);

                DialogResult dialogResult = popup.ShowDialog(view.ParentControl);
                if (dialogResult == DialogResult.OK)
                {
                    UpdateSelectedRole();
                    LoadView();
                }
                popup.Dispose();
            }
        }

        private void UpdateSelectedRole()
        {
            LoginInfo loginInfo = LoginInfo.GetInstance();
            QRoles.UpdateItem(selectedRole, loginInfo.UserName);
        }
    }
}
