using Protocols.Interfaces;
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
    }
}
