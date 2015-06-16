using Protocols.Interfaces;
using Protocols.Models;
using Protocols.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocols.Controllers
{
    public class MainViewController
    {
        IMainView view;

        public MainViewController(IMainView view)
        {
            this.view = view;
            this.view.SetController(this);
        }

        public void LoadView()
        {
            LoadProtocolRequestAddView();
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

        public void LoadProtocolRequestEditView(Sponsor sponsor)
        {
            ProtocolRequestEditView subView = new ProtocolRequestEditView();
            ProtocolRequestDetailController subViewController = new ProtocolRequestDetailController(subView);
            subViewController.LoadView(sponsor);

            view.AddControlToMainPanel(subView);
        }
    }
}
