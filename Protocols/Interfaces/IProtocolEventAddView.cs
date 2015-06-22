using Protocols.Controllers;
using Protocols.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Protocols.Interfaces
{
    public interface IProtocolEventAddView
    {
        void SetController(ProtocolEventAddController controller);
        void AddProtocolEventTypeToView(string eventType);
        void SetSelectedProtocolEventType(int selectedIndex);
        void AddProtocolEventToView(ProtocolEvent protocolEvent);
        void ClearListBox();
        void SetDialogResult(DialogResult dialogResult);
    }
}
