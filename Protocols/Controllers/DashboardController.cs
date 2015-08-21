using Toxikon.ProtocolManager.Interfaces;
using Toxikon.ProtocolManager.Models;
using Toxikon.ProtocolManager.Queries;
using Toxikon.ProtocolManager.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toxikon.ProtocolManager.Controllers
{
    public class DashboardController
    {
        IDashboardView view;
        IList protocolRequests;

        public DashboardController(IDashboardView view)
        {
            this.view = view;
            this.view.SetController(this);
            this.protocolRequests = new ArrayList();
        }

        public void LoadView()
        {
            LoadProtocolRequestsByUserRole();
            AddProtocolRequestsToView();
        }

        private void LoadProtocolRequestsByUserRole()
        {
            LoginInfo loginInfo = LoginInfo.GetInstance();
            switch(loginInfo.Role.RoleID)
            {
                case UserRoles.IT:
                    this.protocolRequests = QProtocolRequests.SelectAllNewRequests();
                    break;
                case UserRoles.CSR:
                    this.protocolRequests = QProtocolRequests.SelectAllNewRequests();
                    break;
                case UserRoles.DocControl:
                    this.protocolRequests = QProtocolRequests.SelectAllNewRequests();
                    break;
                case UserRoles.Manager:
                    this.protocolRequests = QProtocolRequests.SelectAllNewRequests();
                    break;
                case UserRoles.DepartmentDirector:
                    this.protocolRequests = QProtocolRequests.SelectItemsByDirector(loginInfo.UserName);
                    break;
                default:
                    break;
            }
        }

        private void AddProtocolRequestsToView()
        {
            foreach(ProtocolRequest request in protocolRequests)
            {
                this.view.AddProtocolRequestToView(request);
            }
        }

        public void RequestDataGridViewCellDoubleClicked(int requestID)
        {
            ProtocolRequest request = this.protocolRequests.Cast<ProtocolRequest>().
                                      SingleOrDefault(x => x.ID == requestID);
            MainView mainView = (MainView)this.view.ParentControl;
            mainView.Invoke(mainView.LoadProtocolRequestViewDelegate, new object[] { request });
        }
    }
}
