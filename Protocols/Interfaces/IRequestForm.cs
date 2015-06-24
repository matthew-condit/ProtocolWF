using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.ProtocolManager.Controllers;

namespace Toxikon.ProtocolManager.Interfaces
{
    public interface IRequestForm
    {
        void SetController(RequestFormController controller);
        void ClearView();

        string RequestedBy { get; set; }
        string RequestedDate { get; set; }
        string ContactName { get; set; }
        string SponsorName { get; set; }
        string Email { get; set; }
        string Address { get; set; }
        string City { get; set; }
        string State { get; set; }
        string ZipCode { get; set; }
        string PhoneNumber { get; set; }
        string FaxNumber { get; set; }
        string PONumber { get; set; }
        string Guidelines { get; set; }
        string Compliance { get; set; }
        string ProtocolType { get; set; }
        DateTime DueDate { get; set; }
        string SendVia { get; set; }
        string BillTo { get; set; }
        string Comments { get; set; }
        string AssignedTo { get; set; }

        Control ParentControl { get; }
    }
}
