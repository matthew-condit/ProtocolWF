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
using Toxikon.ProtocolManager.Controllers.Templates;
using Toxikon.ProtocolManager.Interfaces.Templates;

namespace Toxikon.ProtocolManager.Controllers.Admin
{
    public class UserListController : UCToolStripListView1Controller
    {
        IUCToolStripListView1 view;
        IList userList;
        User selectedUser;

        public UserListController(IUCToolStripListView1 view)
        {
            this.view = view;
            this.view.SetController(this);
            this.userList = new ArrayList();
        }

        public override void LoadView()
        {
            this.userList.Clear();
            view.ClearView();

            IList columns = new ArrayList() { "Username", "Full Name", "Department", "Role Name", "Active" };
            this.view.AddListViewColumns(columns);
            this.view.ListTitle = "Users";

            this.userList = QUsers.SelectItems();
            AddUsersToView();
            SetColumnsHeaderSize();
        }

        private void AddUsersToView()
        {
            foreach (User user in userList)
            {
                view.AddItemToListView(user);
            }
        }

        private void SetColumnsHeaderSize()
        {
            this.view.SetListViewAutoResizeColumns(0, ColumnHeaderAutoResizeStyle.ColumnContent);
            this.view.SetListViewAutoResizeColumns(1, ColumnHeaderAutoResizeStyle.ColumnContent);
            this.view.SetListViewAutoResizeColumns(2, ColumnHeaderAutoResizeStyle.ColumnContent);
            this.view.SetListViewAutoResizeColumns(3, ColumnHeaderAutoResizeStyle.ColumnContent);
            this.view.SetListViewAutoResizeColumns(4, ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        public override void ListViewSelectedIndexChanged(int selectedIndex)
        {
            this.selectedUser = (User)this.userList[selectedIndex];
        }

        public override void NewButtonClicked()
        {
            User user = new User();
            user = ShowPopup(user);
            if (user.UserName != String.Empty)
            {
                InsertNewUser(user);
                LoadView();
            }
        }

        private void InsertNewUser(User user)
        {
            LoginInfo loginInfo = LoginInfo.GetInstance();
            QUsers.InsertItem(user, loginInfo.UserName);
            MessageBox.Show("New user is added.");
        }

        public override void UpdateButtonClicked()
        {
            if (this.selectedUser == null)
            {
                MessageBox.Show("Please select one user and try it again.");
            }
            else
            {
                this.selectedUser = ShowPopup(this.selectedUser);
                if(this.selectedUser.UserName != String.Empty)
                {
                    UpdateSelectedUser();
                    LoadView();
                }
            }
        }

        private User ShowPopup(User user)
        {
            UserEditView popup = new UserEditView();
            UserEditController popupController = new UserEditController(popup, user);
            popupController.LoadView();
            DialogResult dialogResult = popup.ShowDialog(view.ParentControl);
            if(dialogResult != DialogResult.OK)
            {
                popupController.User.UserName = "";
            }
            popup.Dispose();
            return popupController.User;
        }

        private void UpdateSelectedUser()
        {
            LoginInfo loginInfo = LoginInfo.GetInstance();
            QUsers.UpdateUser(selectedUser, loginInfo.UserName);
        }
    }
}
