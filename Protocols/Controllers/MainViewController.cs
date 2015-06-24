using Toxikon.ProtocolManager.Controllers.Admin;
using Toxikon.ProtocolManager.Controllers.Protocols;
using Toxikon.ProtocolManager.Interfaces;
using Toxikon.ProtocolManager.Interfaces.Protocols;
using Toxikon.ProtocolManager.Models;
using Toxikon.ProtocolManager.Views;
using Toxikon.ProtocolManager.Views.Admin;
using Toxikon.ProtocolManager.Views.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toxikon.ProtocolManager.Controllers
{
    public class MainViewController
    {
        IMainView view;

        public MainViewController(IMainView view)
        {
            this.view = view;
            this.view.SetController(this);
            LoginInfo loginInfo = LoginInfo.GetInstance();
            this.view.SetMenuStripItemVisibleByUserRole(loginInfo.Role.RoleID);
        }

        public void LoadView()
        {
            LoadDashboardView();
        }

        public void LoadProtocolRequestAddView()
        {
            ProtocolRequestAddView subView = new ProtocolRequestAddView();
            ProtocolRequestAddController subViewController = new ProtocolRequestAddController(subView);
            subViewController.LoadView();

            this.view.AddControlToMainPanel(subView);
        }

        public void LoadDepartmentListView()
        {
            DepartmentListView subView = new DepartmentListView();
            DepartmentListController subViewController = new DepartmentListController(subView);
            subViewController.LoadView();

            view.AddControlToMainPanel(subView);
        }

        public void LoadRoleListView()
        {
            RoleListView subView = new RoleListView();
            RoleListController subViewController = new RoleListController(subView);
            subViewController.LoadView();

            view.AddControlToMainPanel(subView);
        }

        public void LoadUserListView()
        {
            UserListView subView = new UserListView();
            UserListController subViewController = new UserListController(subView);
            subViewController.LoadView();

            view.AddControlToMainPanel(subView);
        }

        public void LoadListItemsView()
        {
            ListItemsView subView = new ListItemsView();
            ListItemsController subViewController = new ListItemsController(subView);
            subViewController.LoadView();

            view.AddControlToMainPanel(subView);
        }

        public void LoadDashboardView()
        {
            DashboardView subView = new DashboardView();
            DashboardController subViewController = new DashboardController(subView);
            subViewController.LoadView();

            view.AddControlToMainPanel(subView);
        }

        public void LoadProtocolRequestEditView(ProtocolRequest request)
        {
            ProtocolRequestEditView subView = new ProtocolRequestEditView();
            ProtocolRequestEditController subViewController = new ProtocolRequestEditController(subView);
            subViewController.LoadView(request);

            view.AddControlToMainPanel(subView);
        }

        public void LoadProtocolEventsView()
        {
            ProtocolEventsView subView = new ProtocolEventsView();
            ProtocolEventsController subViewController = new ProtocolEventsController(subView);
            subViewController.LoadView();

            view.AddControlToMainPanel(subView);
        }
    }
}
