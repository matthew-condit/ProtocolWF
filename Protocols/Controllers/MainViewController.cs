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
using Toxikon.ProtocolManager.Views.Templates;

namespace Toxikon.ProtocolManager.Controllers
{
    public class MainViewController
    {
        IMainView view;
        LoginInfo loginInfo;

        public MainViewController(IMainView view)
        {
            this.view = view;
            this.view.SetController(this);
            loginInfo = LoginInfo.GetInstance();
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
            UCToolStripListView1 subView = new UCToolStripListView1();
            DepartmentListController subViewController = new DepartmentListController(subView);
            subViewController.LoadView();

            view.AddControlToMainPanel(subView);
        }

        public void LoadRoleListView()
        {
            UCToolStripListView1 subView = new UCToolStripListView1();
            RoleListController subViewController = new RoleListController(subView);
            subViewController.LoadView();

            view.AddControlToMainPanel(subView);
        }

        public void LoadUserListView()
        {
            UCToolStripListView1 subView = new UCToolStripListView1();
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

        public void LoadProtocolRequestDetailView(ProtocolRequest request)
        {
            if(request.RequestStatus != RequestStatuses.Closed)
            {
                LoadProtocolRequestDetailByRoleID(request);
            }
            else
            {
                LoadProtocolRequestReadOnlyView(request);
            }
        }

        private void LoadProtocolRequestDetailByRoleID(ProtocolRequest request)
        {
            switch (loginInfo.Role.RoleID)
            {
                case UserRoles.IT:
                    LoadProtocolRequestEditView(request);
                    break;
                case UserRoles.CSR:
                    LoadProtocolRequestReadOnlyView(request);
                    break;
                case UserRoles.DocControl:
                    LoadProtocolRequestEditView(request);
                    break;
                case UserRoles.Manager:
                    LoadRequestDetail_ManagerView(request);
                    break;
                default:
                    LoadProtocolRequestReadOnlyView(request);
                    break;
            }
        }

        private void LoadRequestDetail_ManagerView(ProtocolRequest request)
        {
            ProtocolRequestManagerView subView = new ProtocolRequestManagerView();
            RequestDetailController subViewController = new RequestDetailController(subView);
            subViewController.LoadView(request);
            view.AddControlToMainPanel(subView);
        }

        public void LoadProtocolRequestReadOnlyView(ProtocolRequest request)
        {
            ProtocolRequestReadOnlyView subView = new ProtocolRequestReadOnlyView();
            RequestDetailController subViewController = new RequestDetailController(subView);
            subViewController.LoadView(request);

            view.AddControlToMainPanel(subView);
        }

        public void LoadProtocolRequestEditView(ProtocolRequest request)
        {
            ProtocolRequestEditView subView = new ProtocolRequestEditView();
            RequestDetailController subViewController = new RequestDetailController(subView);
            subViewController.LoadView(request);

            view.AddControlToMainPanel(subView);
        }

        public void LoadProtocolEventsView()
        {
            UCToolStripListView1 subView = new UCToolStripListView1();
            ProtocolEventsController subViewController = new ProtocolEventsController(subView);
            subViewController.LoadView();

            view.AddControlToMainPanel(subView);
        }

        public void LoadHistoryView()
        {
            HistoryView subView = new HistoryView();
            HistoryController subViewController = new HistoryController(subView);
            subViewController.LoadView();

            view.AddControlToMainPanel(subView);
        }

        public void LoadListNameView()
        {
            UCToolStripListView1 subView = new UCToolStripListView1();
            ListNameController subViewController = new ListNameController(subView);
            subViewController.LoadView();
            view.AddControlToMainPanel(subView);
        }

        public void LoadTemplateGroupsView()
        {
            UCToolStripListView1 subView = new UCToolStripListView1();
            TemplateGroupsController subViewController = new TemplateGroupsController(subView);
            subViewController.LoadView();

            view.AddControlToMainPanel(subView);
        }

        public void LoadTemplatesView()
        {
            UCTemplate2View subView = new UCTemplate2View();
            TemplateListController subViewController = new TemplateListController(subView);
            subViewController.LoadView();

            view.AddControlToMainPanel(subView);
        }

        public void LoadProtocolNumberUpdateView()
        {
            ProtocolNumberUpdateView subView = new ProtocolNumberUpdateView();
            ProtocolNumberUpdateController subViewController = new ProtocolNumberUpdateController(subView);
            view.AddControlToMainPanel(subView);
        }
    }
}
