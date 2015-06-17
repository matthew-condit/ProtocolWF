using Protocols.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocols.Queries
{
    public class QProtocols
    {
        private static string connectionString = Utility.GetTPMConnectionString();

        public static IList GetInProcessProtocols()
        {
            IList results = new ArrayList();
            try
            {
                string query = @"SELECT ProtocolRequests.ID,ProtocolRequestTitles.Title,ProtocolRequests.SponsorCode, 
                                        ProtocolRequests.RequestStatus, Users.FullName,
		                                ProtocolRequests.RequestedDate, ProtocolRequests.UpdatedBy, 
                                        ProtocolRequests.UpdatedDate
	                             FROM ProtocolRequestTitles
	                             INNER JOIN ProtocolRequests
	                             ON ProtocolRequestTitles.ProtocolRequestID = ProtocolRequests.ID
                                 INNER JOIN Users
                                 ON ProtocolRequests.RequestedBy = Users.UserName
	                             WHERE ProtocolRequests.IsActive = 1";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.Text;

                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Protocol protocol = CreateNewProtocol(reader);
                            protocol.WorkflowType = WorkflowTypes.Protocol;
                            results.Add(protocol);
                        }
                    }
                }
            }
            catch (InvalidOperationException ioe)
            {
                Debug.WriteLine(ioe.ToString());
            }
            catch (SqlException e)
            {
                Debug.WriteLine(e.ToString());
            }
            return results;
        }

        public static Protocol CreateNewProtocol(SqlDataReader reader)
        {
            Protocol protocol = new Protocol();
            protocol.ProtocolRequestID = Convert.ToInt32(reader[0].ToString());
            protocol.Title = reader[1].ToString();
            protocol.RequestedBy = reader[4].ToString();
            protocol.RequestedDate = Convert.ToDateTime(reader[5].ToString());
            return protocol;
        }
    }
}
