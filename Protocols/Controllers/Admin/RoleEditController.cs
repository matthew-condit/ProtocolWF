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
    public class RoleEditController
    {
        IRoleEditView view;
        public Role Role { get; private set; }

        public RoleEditController(IRoleEditView view)
        {
            this.view = view;
            this.view.SetController(this);
            this.view.IsActive = true;
            this.view.SetIsActiveRadioButtonGroup_Enable(false);

            this.Role = new Role();
        }

        public RoleEditController(IRoleEditView view, Role role)
        {
            this.view = view;
            this.view.SetController(this);
            this.view.RoleName = role.RoleName;
            this.view.IsActive = role.IsActive;
            this.view.SetIsActiveRadioButtonGroup_Enable(true);
            this.Role = role;
        }

        public void SubmitButtonClicked()
        {
            try
            {
                if (view.RoleName.Trim() == "")
                {
                    view.SetDialogResult(DialogResult.Retry);
                    ShowMessage("Role name is required.");
                }
                else
                {
                    this.Role.RoleName = view.RoleName;
                    this.Role.IsActive = view.IsActive;
                    view.SetDialogResult(DialogResult.OK);
                }
            }
            catch (Exception e)
            {
                ShowMessage(e.Message);
            }
        }

        private void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
