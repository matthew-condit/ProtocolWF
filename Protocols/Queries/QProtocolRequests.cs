using Toxikon.ProtocolManager.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toxikon.ProtocolManager.Queries
{
    public static class QProtocolRequests
    {
        private static string connectionString = Utility.GetTPMConnectionString();
        private const string ErrorFormName = "QProtocolRequests";

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
                                                request.Contact.SponsorCode;
                        command.Parameters.Add("@Guidelines", SqlDbType.NVarChar).Value = request.Guidelines;
                        command.Parameters.Add("@Compliance", SqlDbType.NVarChar).Value = request.Compliance;
                        command.Parameters.Add("@ProtocolType", SqlDbType.NVarChar).Value = request.ProtocolType;
                        command.Parameters.Add("@DueDate", SqlDbType.DateTime).Value = request.DueDate;
                        command.Parameters.Add("@SendVia", SqlDbType.NVarChar).Value = request.SendVia;
                        command.Parameters.Add("@BillTo", SqlDbType.NVarChar).Value = request.BillTo;
                        command.Parameters.Add("@Comments", SqlDbType.NVarChar).Value = request.Comments;
                        command.Parameters.Add("@AssignedTo", SqlDbType.NVarChar).Value = request.AssignedTo;

                        result = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            catch(SqlException ex)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "InsertProtocolRequest", ex);
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
            catch (SqlException e)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "GetProtocolRequestsByStatus", e);
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
	                             WHERE ProtocolRequests.IsActive = 1
                                 ORDER BY ProtocolRequests.RequestedDate DESC";
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
            catch (SqlException e)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "GetActiveProtocolRequests", e);
            }
            return results;
        }

        public static IList SelectProtocolRequestByRequestedBy(string userName)
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
	                             WHERE ProtocolRequests.IsActive = 1
                                 AND ProtocolRequests.RequestedBy = @RequestedBy
                                 ORDER BY ProtocolRequests.RequestedDate DESC";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add("@RequestedBy", SqlDbType.NVarChar).Value = userName;
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            ProtocolRequest request = CreateNewProtocolRequest(reader);
                            results.Add(request);
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "SelectProtocolRequestByRequestedBy", e);
            }
            return results;
        }

        public static IList SelectProtocolRequestByAssignedTo(string userName)
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
	                             WHERE ProtocolRequests.IsActive = 1
                                 AND ProtocolRequests.AssignedTo = @UserName
                                 ORDER BY ProtocolRequests.RequestedDate DESC";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = userName;
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            ProtocolRequest request = CreateNewProtocolRequest(reader);
                            results.Add(request);
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "SelectProtocolRequestByAssignedTo", e);
            }
            return results;
        }

        public static ProtocolRequest CreateNewProtocolRequest(SqlDataReader reader)
        {
            ProtocolRequest request = new ProtocolRequest();
            request.ID = Convert.ToInt32(reader[0].ToString());
            request.SetContact(reader[1].ToString());
            request.Guidelines = reader[2].ToString();
            request.Compliance = reader[3].ToString();
            request.ProtocolType = reader[4].ToString();
            request.DueDate = Convert.ToDateTime(reader[5].ToString());
            request.SendVia = reader[6].ToString();
            request.BillTo = reader[7].ToString();
            request.Comments = reader[8].ToString();
            request.AssignedTo = reader[9].ToString();
            request.RequestStatus = reader[10].ToString();
            request.RequestedBy = reader[11].ToString();
            request.RequestedDate = Convert.ToDateTime(reader[12].ToString());
            return request;
        }

        public static void Update(ProtocolRequest request, string userName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("ProtocolRequestsUpdate", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@ProtocolRequestID", SqlDbType.Int).Value = request.ID;
                        command.Parameters.Add("@SponsorCode", SqlDbType.NVarChar).Value = request.Contact.ContactCode;
                        command.Parameters.Add("@Guidelines", SqlDbType.NVarChar).Value = request.Guidelines;
                        command.Parameters.Add("@Compliance", SqlDbType.NVarChar).Value = request.Compliance;
                        command.Parameters.Add("@ProtocolType", SqlDbType.NVarChar).Value = request.ProtocolType;
                        command.Parameters.Add("@DueDate", SqlDbType.NVarChar).Value = request.DueDate;
                        command.Parameters.Add("@SendVia", SqlDbType.NVarChar).Value = request.SendVia;
                        command.Parameters.Add("@BillTo", SqlDbType.NVarChar).Value = request.BillTo;
                        command.Parameters.Add("@AssignedTo", SqlDbType.NVarChar).Value = request.AssignedTo;
                        command.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = userName;

                        int result = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException e)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "Update", e);
            }
        }
    }
}
