using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toxikon.ProtocolManager.Models
{
    public class ProtocolEventTypes
    {
        public const string Protocol = "Protocol";
        public const string ProtocolRequest = "Protocol Request";
        public const string Draft = "Draft";
        public static IList EventTypeList = new ArrayList(){ ProtocolEventTypes.ProtocolRequest, 
                           ProtocolEventTypes.Draft, ProtocolEventTypes.Protocol };
    }
}
