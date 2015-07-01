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
    public class RoleListController : UCToolStripListView1Controller
    {
        IUCToolStripListView1 view;
        IList roles;
        Role selectedRole;
        LoginInfo loginInfo;

        public RoleListController(IUCToolStripListView1 view)
        {
            this.view = view;
            this.view.SetController(this);
            roles = new ArrayList();
            loginInfo = LoginInfo.GetInstance();
        }

        public override void LoadView()
        {
            this.roles.Clear();
            this.view.ClearView();
            IList columns = new ArrayList() { "ID", "Role Name", "Active" };
            this.view.AddListViewColumns(columns);
            this.view.ListTitle = "Roles";
            this.roles = QRoles.SelectItems();
            AddRolesToView();
            SetColumnsHeaderSize();
        }

        private void AddRolesToView()
        {
            foreach (Role role in roles)
            {
                this.view.AddItemToListView(role);
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
            this.selectedRole = (Role)this.roles[selectedIndex];
        }

        public override void NewButtonClicked()
        {
            Role role = new Role();
            Item result = ShowPopup(role);
            if (result.Value != String.Empty)
            {
                role.Submit(result.Value, result.IsActive);
                MessageBox.Show("New role is added.");
                LoadView();
            }
        }

        public override void UpdateButtonClicked()
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
                    this.selectedRole.Update(result.Value, result.IsActive);
                    LoadView();
                }
            }
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
