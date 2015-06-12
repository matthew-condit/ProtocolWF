using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocols.Models
{
    internal class Utility
    {
        internal static string GetLIMSConnectionString()
        {
            string result = "";
            ConnectionStringSettings settings =
                ConfigurationManager.ConnectionStrings["Protocols.Properties.Settings.LIMSConnectionString"];
            if (settings != null)
            {
                result = settings.ConnectionString;
            }
            return result;
        }
    }
}
