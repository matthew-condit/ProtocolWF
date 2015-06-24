using Toxikon.ProtocolManager.Controllers.Protocols;
using Toxikon.ProtocolManager.Models;
using Toxikon.ProtocolManager.Views.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toxikon.ProtocolManager.Views.RequestForms;

namespace Toxikon.ProtocolManager.Interfaces.Protocols
{
    public interface IProtocolRequestAddView
    {
        void SetController(ProtocolRequestAddController controller);
        void AddSponsorToSearchResultList(Sponsor sponsor);
        void ClearView();

        string SearchSponsorName { get; set; }
        List<string> Titles { get; }
        RequestFormAdd GetRequestForm { get; }
    }
}
