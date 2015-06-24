using Toxikon.ProtocolManager.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Toxikon.ProtocolManager.Interfaces
{
    public interface IMainView
    {
        void SetController(MainViewController controller);
        void SetMenuStripItemVisibleByUserRole(int roleID);
        void AddControlToMainPanel(Control control);
    }
}
