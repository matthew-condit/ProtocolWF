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
    public class UserListController
    {
        IUserListView view;
        IList userList;
        User selectedUser;

        public UserListController(IUserListView view)
        {
            this.view = view;
            this.view.SetController(this);
            this.userList = new ArrayList();
        }

        public void LoadView()
        {
            this.userList.Clear();
            view.ClearView();
            this.userList = QUsers.SelectItems();
            foreach (User user in userList)
            {
                view.AddItemToListView(user);
            }
        }

        public void ListViewSelectedIndexChanged(int selectedIndex)
        {
            this.selectedUser = (User)this.userList[selectedIndex];
        }

        public void NewButtonClicked()
        {
            User user = new User();
            DialogResult dialogResult = ShowPopup(user);
            if (dialogResult == DialogResult.OK)
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

        public void UpdateButtonClicked()
        {
            if (this.selectedUser == null)
            {
                MessageBox.Show("Please select one user and try it again.");
            }
            else
            {
                DialogResult dialogResult = ShowPopup(this.selectedUser);
                if (dialogResult == DialogResult.OK)
                {
                    UpdateSelectedUser();
                    LoadView();
                }
            }
        }

        private DialogResult ShowPopup(User user)
        {
            UserEditView popup = new UserEditView();
            UserEditController popupController = new UserEditController(popup, user);
            popupController.LoadView();
            DialogResult dialogResult = popup.ShowDialog(view.ParentControl);
            popup.Dispose();
            return dialogResult;
        }

        private void UpdateSelectedUser()
        {
            LoginInfo loginInfo = LoginInfo.GetInstance();
            QUsers.UpdateUser(selectedUser, loginInfo.UserName);
        }
    }
}
