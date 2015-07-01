using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.ProtocolManager.Controllers.Admin;

namespace Toxikon.ProtocolManager.Interfaces.Admin
{
    public interface IProtocolEventEditView
    {
        void SetController(ProtocolEventEditController controller);
        void SetIsActiveRadioButtonGroup_Enable(bool value);
        void SetDialogResult(DialogResult dialogResult);

        string EventType { get; set; }
        string EventDescription { get; set; }
        bool IsActive { get; set; }
    }
}
