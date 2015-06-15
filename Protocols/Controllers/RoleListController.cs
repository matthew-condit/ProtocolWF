using Protocols.Interfaces;
using Protocols.Models;
using Protocols.Queries;
using Protocols.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Protocols.Controllers
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
            this.roles = QRoles.GetRoles();
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
            RoleEditView popup = new RoleEditView();
            RoleEditController popupController = new RoleEditController(popup);

            DialogResult dialogResult = popup.ShowDialog(view.ParentControl);
            if (dialogResult == DialogResult.OK)
            {
                Role role = popupController.Role;
                InsertNewRole(role);
                LoadView();
            }
            popup.Dispose();
        }

        private void InsertNewRole(Role role)
        {
            LoginInfo loginInfo = LoginInfo.GetInstance();
            QRoles.InsertRole(role.RoleName, loginInfo.UserName);
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
                RoleEditView popup = new RoleEditView();
                RoleEditController popupController = new RoleEditController(popup, this.selectedRole);

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
            QRoles.UpdateRole(selectedRole, loginInfo.UserName);
        }
    }
}
