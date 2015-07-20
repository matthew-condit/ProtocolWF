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
using Toxikon.ProtocolManager.Models.Protocols;

namespace Toxikon.ProtocolManager.Queries
{
    public static class QProtocolRequests
    {
        private static string connectionString = Utility.GetTPMConnectionString();
        private const string ErrorFormName = "QProtocolRequests";

        public static int InsertItem(ProtocolRequest request, string userName)
        {
            int result = -1;
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using(SqlCommand command = new SqlCommand("pr_insert_request", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@RequestedBy", SqlDbType.NVarChar).Value = userName;
                        command.Parameters.Add("@SponsorCode", SqlDbType.NVarChar).Value = 
                                                request.Contact.SponsorCode;
                        command.Parameters.Add("@ContactCode", SqlDbType.NVarChar).Value =
                                                request.Contact.ContactCode;
                        command.Parameters.Add("@Guidelines", SqlDbType.NVarChar).Value = request.Guidelines;
                        command.Parameters.Add("@Compliance", SqlDbType.NVarChar).Value = request.Compliance;
                        command.Parameters.Add("@ProtocolType", SqlDbType.NVarChar).Value = request.ProtocolType;
                        command.Parameters.Add("@DueDate", SqlDbType.DateTime).Value = request.DueDate;
                        command.Parameters.Add("@SendVia", SqlDbType.NVarChar).Value = request.SendVia;
                        command.Parameters.Add("@BillTo", SqlDbType.NVarChar).Value = request.BillTo;
                        command.Parameters.Add("@Cost", SqlDbType.NVarChar).Value = request.Cost;
                        command.Parameters.Add("@Comments", SqlDbType.NVarChar).Value = request.Comments;
                        command.Parameters.Add("@PO", SqlDbType.NVarChar).Value = request.PO;
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

        public static IList SelectItemsByStatus(string status)
        {
            IList results = new ArrayList();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("pr_select_requests_by_status", connection))
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

        public static IList SelectAllNewRequests()
        {
            IList results = new ArrayList();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("pr_admin_select_new_requests", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

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
                ErrorHandler.CreateLogFile(ErrorFormName, "SelectAllNewRequests", e);
            }
            return results;
        }

        public static IList SelectItemsByRequestedBy(string userName)
        {
            IList results = new ArrayList();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("pr_select_new_requestedby_requests", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
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

        public static IList SelectItemsByAssignedTo(string userName)
        {
            IList results = new ArrayList();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("pr_select_new_assignedto_requests", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
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

        public static IList SelectClosedRequests(string requestedBy, string assignedTo)
        {
            IList results = new ArrayList();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("pr_select_closed_requests", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@RequestedBy", SqlDbType.NVarChar).Value = requestedBy;
                        command.Parameters.Add("@AssignedTo", SqlDbType.NVarChar).Value = assignedTo;

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
                ErrorHandler.CreateLogFile(ErrorFormName, "SelectClosedRequests", e);
            }
            return results;
        }

        public static IList AdminSelectClosedRequests(string requestedBy)
        {
            IList results = new ArrayList();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("pr_admin_select_closed_requests", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@RequestedBy", SqlDbType.NVarChar).Value = requestedBy;

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
                ErrorHandler.CreateLogFile(ErrorFormName, "AdminSelectClosedRequests", e);
            }
            return results;
        }

        public static IList GetSponsorCodes(string requestStatus)
        {
            IList results = new ArrayList();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("pr_select_sponsorcodes", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@RequestStatus", SqlDbType.NVarChar).Value = requestStatus;

                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Item item = new Item();
                            item.Name = reader[0].ToString();
                            results.Add(item);
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "GetSponsorCodes", e);
            }
            return results;
        }

        public static IList GetProtocolRequests_BySponsorCode(string sponsorCode)
        {
            IList results = new ArrayList();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("pr_select_requests_by_sponsorcode", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@SponsorCode", SqlDbType.NVarChar).Value = sponsorCode;

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
                ErrorHandler.CreateLogFile(ErrorFormName, "GetProtocolRequests_BySponsorCode", e);
            }
            return results;
        }

        public static ProtocolRequest CreateNewProtocolRequest(SqlDataReader reader)
        {
            ProtocolRequest request = new ProtocolRequest();
            request.ID = Convert.ToInt32(reader[0].ToString());
            request.SetContact(reader[17].ToString().Trim());
            request.Guidelines = reader[2].ToString();
            request.Compliance = reader[3].ToString();
            request.ProtocolType = reader[4].ToString();
            request.DueDate = Convert.ToDateTime(reader[5].ToString());
            request.SendVia = reader[6].ToString();
            request.BillTo = reader[7].ToString();
            request.Cost = reader[8].ToString().Trim();
            request.Comments = reader[9].ToString();
            request.PO = reader[10].ToString().Trim();
            request.AssignedTo = reader[11].ToString();
            request.RequestStatus = reader[12].ToString();
            request.RequestedBy = reader[13].ToString();
            request.RequestedDate = Convert.ToDateTime(reader[14].ToString());
            return request;
        }

        public static void UpdateItem(ProtocolRequest request, string userName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("pr_update_request", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@ProtocolRequestID", SqlDbType.Int).Value = request.ID;
                        command.Parameters.Add("@ContactCode", SqlDbType.NVarChar).Value = 
                                           request.Contact.ContactCode;
                        command.Parameters.Add("@Guidelines", SqlDbType.NVarChar).Value = request.Guidelines;
                        command.Parameters.Add("@Compliance", SqlDbType.NVarChar).Value = request.Compliance;
                        command.Parameters.Add("@ProtocolType", SqlDbType.NVarChar).Value = request.ProtocolType;
                        command.Parameters.Add("@DueDate", SqlDbType.NVarChar).Value = request.DueDate;
                        command.Parameters.Add("@SendVia", SqlDbType.NVarChar).Value = request.SendVia;
                        command.Parameters.Add("@BillTo", SqlDbType.NVarChar).Value = request.BillTo;
                        command.Parameters.Add("@Cost", SqlDbType.NVarChar).Value = request.Cost;
                        command.Parameters.Add("@PO", SqlDbType.NVarChar).Value = request.PO;
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

        public static void UpdateRequestStatus(ProtocolRequest request, string updatedBy)
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using(SqlCommand command = new SqlCommand("pr_update_request_status", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@ProtocolRequestID", SqlDbType.Int).Value = request.ID;
                        command.Parameters.Add("@RequestStatus", SqlDbType.NVarChar).Value = request.RequestStatus;
                        command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = request.IsActive;
                        command.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = updatedBy;

                        int result = command.ExecuteNonQuery();
                    }
                }
            }
            catch(SqlException sqlEx)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "UpdateRequestStatus", sqlEx);
            }
        }
    }
}
