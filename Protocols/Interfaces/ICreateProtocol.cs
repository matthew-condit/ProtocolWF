using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.ProtocolManager.Controllers;

namespace Toxikon.ProtocolManager.Interfaces
{
    public interface ICreateProtocol
    {
        void SetController(CreateProtocolController controller);
        void SetDialogResult(DialogResult dialogResult);

        string SourceFile { get; set; }
        string DestFolder { get; set; }
    }
}
