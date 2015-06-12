using Protocols.Controllers;
using Protocols.Models;
using Protocols.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocols.Interfaces
{
    public interface IProtocolRequestAddView
    {
        void SetController(ProtocolRequestAddController controller);
        void AddSponsorToSearchResultList(Sponsor sponsor);
        void ClearView();

        string SearchSponsorName { get; set; }
        ProtocolRequestDetailView GetProtocolRequestDetailView { get; }
    }
}
