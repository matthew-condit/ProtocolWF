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
        LoginInfo loginInfo;

        public RoleListController(IRoleListView view)
        {
            this.view = view;
            this.view.SetController(this);
            roles = new ArrayList();
            loginInfo = LoginInfo.GetInstance();
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
            Role role = new Role();
            Item result = ShowPopup(role);
            if (result.Value != String.Empty)
            {
                InsertNewRole(role, result);
                LoadView();
            }
        }

        private void InsertNewRole(Role role, Item result)
        {
            role.RoleName = result.Value;
            role.IsActive = result.IsActive;
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
                Item result = ShowPopup(this.selectedRole);
                if (result.Value != String.Empty)
                {
                    UpdateSelectedRole(result);
                    LoadView();
                }
            }
        }

        private void UpdateSelectedRole(Item result)
        {
            this.selectedRole.RoleName = result.Value;
            this.selectedRole.IsActive = result.IsActive;
            QRoles.UpdateItem(selectedRole, loginInfo.UserName);
        }

        private Item ShowPopup(Role item)
        {
            Item textBoxItem = new Item("Role: ", item.RoleName);
            Item trueFalseItem = new Item("Active: ", item.IsActive.ToString());
            Item result = TemplatesController.ShowOneTextBoxTrueFalseForm(textBoxItem, trueFalseItem,
                               this.view.ParentControl);
            return result;
        }
    }
}
