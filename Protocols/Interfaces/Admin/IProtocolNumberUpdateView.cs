using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toxikon.ProtocolManager.Controllers.Admin;

namespace Toxikon.ProtocolManager.Interfaces.Admin
{
    public interface IProtocolNumberUpdateView
    {
        void SetController(ProtocolNumberUpdateController controller);
        void SetAdminView(bool value);
        void ClearView();

        string RequestID { get; set; }
        string TemmplateID { get; set; }
        string ProtocolNumber { get; set; }
        string YearNumber { get; set; }
        string SequenceNumber { get; set; }
        string RevisedNumber { get; set; }
        string ProtocolType { get; set; }
        bool IsActive { get; set; }
    }
}
