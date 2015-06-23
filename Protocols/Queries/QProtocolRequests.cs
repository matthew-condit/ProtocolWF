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
    public static class QProtocolRequests
    {
        private static string connectionString = Utility.GetTPMConnectionString();

        public static int InsertProtocolRequest(ProtocolRequest request, string userName)
        {
            int result = -1;
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using(SqlCommand command = new SqlCommand("ProtocolRequestsInsert", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@RequestedBy", SqlDbType.NVarChar).Value = userName;
                        command.Parameters.Add("@SponsorCode", SqlDbType.NVarChar).Value = 
                                               request.SponsorCode;
                        command.Parameters.Add("@Guidelines", SqlDbType.NVarChar).Value = request.Guidelines;
                        command.Parameters.Add("@Compliance", SqlDbType.NVarChar).Value = request.Compliance;
                        command.Parameters.Add("@ProtocolType", SqlDbType.NVarChar).Value = request.ProtocolType;
                        command.Parameters.Add("@DueDate", SqlDbType.DateTime).Value = request.DueDate;
                        command.Parameters.Add("@SendVia", SqlDbType.NVarChar).Value = request.SendMethod;
                        command.Parameters.Add("@BillTo", SqlDbType.NVarChar).Value = request.BillTo;
                        command.Parameters.Add("@Comments", SqlDbType.NVarChar).Value = request.Comments;
                        command.Parameters.Add("@AssignedTo", SqlDbType.NVarChar).Value = request.AssignedTo;

                        result = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            catch(InvalidOperationException ioe)
            {
                Debug.WriteLine(ioe.ToString());
            }
            catch(SqlException e)
            {
                Debug.WriteLine(e.ToString());
            }
            return result;
        }

        public static IList GetProtocolRequestsByStatus(string status)
        {
            IList results = new ArrayList();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("ProtocolRequestSelect", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@RequestStatus", SqlDbType.NVarChar).Value = status;
                        SqlDataReader reader = command.ExecuteReader();
                        while(reader.Read())
                        {
                            ProtocolRequest request = CreateNewProtocolRequest(reader);
                            results.Add(request);
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

        public static IList GetActiveProtocolRequests()
        {
            IList results = new ArrayList();
            try
            {
                string query = @"SELECT ProtocolRequests.ID, ProtocolRequests.SponsorCode, 
                                        ProtocolRequests.Guidelines, ProtocolRequests.Compliance, 
                                        ProtocolRequests.ProtocolType, ProtocolRequests.DueDate, 
                                        ProtocolRequests.SendVia, ProtocolRequests.BillTo,
                                        ProtocolRequests.Comments,
                                        ProtocolRequests.AssignedTo, 
                                        ProtocolRequests.RequestStatus, Users.FullName,
		                                ProtocolRequests.RequestedDate, ProtocolRequests.UpdatedBy, 
                                        ProtocolRequests.UpdatedDate
	                             FROM ProtocolRequests
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
                            ProtocolRequest request = CreateNewProtocolRequest(reader);
                            results.Add(request);
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

        public static ProtocolRequest CreateNewProtocolRequest(SqlDataReader reader)
        {
            ProtocolRequest request = new ProtocolRequest();
            request.ID = Convert.ToInt32(reader[0].ToString());
            request.SponsorCode = reader[1].ToString();
            request.SetSponsor();
            request.Guidelines = reader[2].ToString();
            request.Compliance = reader[3].ToString();
            request.ProtocolType = reader[4].ToString();
            request.DueDate = Convert.ToDateTime(reader[5].ToString());
            request.SendMethod = reader[6].ToString();
            request.BillTo = reader[7].ToString();
            request.Comments = reader[8].ToString();
            request.AssignedTo = reader[9].ToString();
            request.RequestStatus = reader[10].ToString();
            request.RequestedBy = reader[11].ToString();
            request.RequestedDate = Convert.ToDateTime(reader[12].ToString());
            return request;
        }
    }
}
