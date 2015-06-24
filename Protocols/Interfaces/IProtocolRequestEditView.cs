using Protocols.Controllers;
using Protocols.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Protocols.Interfaces
{
    public interface IProtocolRequestEditView
    {
        void SetController(ProtocolRequestEditController controller);
        void SetControlVisibleByUserRole(int roleID);
        void AddTitleToView(ProtocolTitle title);
        void SetListViewAutoResizeColumns();
        void ClearProtocolTitleListView();
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

        IList SelectedTitleIndexes { get; }

        Control ParentControl { get; }
    }
}
