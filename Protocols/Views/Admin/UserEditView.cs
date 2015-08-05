using Toxikon.ProtocolManager.Controllers.Admin;
using Toxikon.ProtocolManager.Interfaces.Admin;
using Toxikon.ProtocolManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Toxikon.ProtocolManager.Views.Admin
{
    public partial class UserEditView : Form, IUserEditView
    {
        UserEditController controller;

        public UserEditView()
        {
            InitializeComponent();
            this.DepartmentComboBox.DisplayMember = "Name";
        }

        public void SetController(UserEditController controller)
        {
            this.controller = controller;
        }

        public void SetUpdateMode()
        {
            this.MainContainer.Panel1.Enabled = true;
            this.SetIsActiveRadioButtonGroup_Enable(true);
            this.SearchToolStrip.Enabled = false;
        }

        public void SetNewMode()
        {
            this.MainContainer.Panel1.Enabled = true;
            this.SetIsActiveRadioButtonGroup_Enable(true);
            this.SearchToolStrip.Enabled = true;
        }

        private void SetIsActiveRadioButtonGroup_Enable(bool value)
        {
            this.IsActiveRadioButtonGroup.Enabled = value;
        }

        public void SetDialogResult(DialogResult dialogResult)
        {
            this.DialogResult = dialogResult;
        }

        public void AddDepartmentToComboBox(Department department)
        {
            this.DepartmentComboBox.Items.Add(department);
        }

        public void AddRoleToComboBox(Role role)
        {
            this.RoleComboBox.Items.Add(role);
        }

        public string UserName
        {
            get { return this.UserNameTextBox.Text; }
            set { this.UserNameTextBox.Text = value; }
        }
        public string FirstName
        {
            get { return this.FirstNameTextBox.Text; }
            set { this.FirstNameTextBox.Text = value; }
        }
        public string LastName
        {
            get { return this.LastNameTextBox.Text; }
            set { this.LastNameTextBox.Text = value; }
        }
        public string FullName
        {
            get { return this.FullNameTextBox.Text; }
            set { this.FullNameTextBox.Text = value; }
        }

        public string EmailAddress
        {
            get { return this.EmailTextBox.Text; }
            set { this.EmailTextBox.Text = value; }
        }

        public Department Department
        {
            get { return (Department)this.DepartmentComboBox.SelectedItem; }
            set { this.DepartmentComboBox.SelectedItem = value; }
        }
        public Role Role
        {
            get { return (Role)this.RoleComboBox.SelectedItem; }
            set { this.RoleComboBox.SelectedItem = value; }
        }
        public bool IsActive
        {
            get { return this.TrueRadioButton.Checked; }
            set
            {
                this.TrueRadioButton.Checked = value;
                this.FalseRadioButton.Checked = value == true ? false : true;
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            this.controller.SearchButtonClicked(this.SearchTextBox.Text);
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            this.controller.SubmitButtonClicked();
        }
    }
}
