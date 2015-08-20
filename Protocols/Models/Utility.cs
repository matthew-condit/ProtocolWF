using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toxikon.ProtocolManager.Models
{
    internal class Utility
    {
        internal static string GetLIMSConnectionString()
        {
            string result = "";
            ConnectionStringSettings settings =
                ConfigurationManager.ConnectionStrings["Toxikon.ProtocolManager.Properties.Settings.LIMSConnectionString"];
            if (settings != null)
            {
                result = settings.ConnectionString;
            }
            return result;
        }

        internal static string GetTMSConnectionString()
        {
            string result = "";
            ConnectionStringSettings settings =
                ConfigurationManager.ConnectionStrings["Toxikon.ProtocolManager.Properties.Settings.TMSConnectionString"];
            if (settings != null)
            {
                result = settings.ConnectionString;
            }
            return result;
        }

        internal static string GetTPMConnectionString()
        {
            string TPM = @"Toxikon.ProtocolManager.Properties.Settings.TPMConnectionString";
            string TPMTest = @"Toxikon.ProtocolManager.Properties.Settings.TPMTestConnectionString";
            string result = "";
            ConnectionStringSettings settings =
                ConfigurationManager.ConnectionStrings[TPMTest];
            if (settings != null)
            {
                result = settings.ConnectionString;
            }
            return result;
        }
    }
}
