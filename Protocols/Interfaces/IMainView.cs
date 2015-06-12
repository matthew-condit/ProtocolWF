using Protocols.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Protocols.Interfaces
{
    public interface IMainView
    {
        void SetController(MainViewController controller);

        void AddControlToMainPanel(Control control);
    }
}
