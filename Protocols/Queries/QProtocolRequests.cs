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

        public static void InsertProtocolRequestTitles(ProtocolRequest request, string userName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    foreach (ProtocolTitle item in request.Titles)
                    {
                        using (SqlCommand command = new SqlCommand("ProtocolRequestTitlesInsert", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            command.Parameters.Add("@ProtocolRequestID", SqlDbType.Int).Value = request.ID;
                            command.Parameters.Add("@Title", SqlDbType.NVarChar).Value = item.Description;
                            command.Parameters.Add("@CreatedBy", SqlDbType.NVarChar).Value = userName;
                            int result = command.ExecuteNonQuery();
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
        }

        public static int InsertProtocolTitle(ProtocolTitle title, string userName)
        {
            int result = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("ProtocolRequestTitlesInsert", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@ProtocolRequestID", SqlDbType.Int).Value = title.ProtocolRequestID;
                        command.Parameters.Add("@Title", SqlDbType.NVarChar).Value = title.Description;
                        command.Parameters.Add("@CreatedBy", SqlDbType.NVarChar).Value = userName;
                        result = Convert.ToInt32(command.ExecuteScalar());
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
            return result;
        }

        public static void InsertProtocolRequestComments(ProtocolRequest request, string userName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("ProtocolRequestCommentsInsert", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@ProtocolRequestID", SqlDbType.Int).Value = request.ID;
                        command.Parameters.Add("@Comments", SqlDbType.NVarChar).Value = request.Comments[0];
                        command.Parameters.Add("@CreatedBy", SqlDbType.NVarChar).Value = userName;
                        int result = command.ExecuteNonQuery();
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
            request.RequestStatus = reader[8].ToString();
            request.RequestedBy = reader[9].ToString();
            request.RequestedDate = Convert.ToDateTime(reader[10].ToString());
            return request;
        }

        public static IList GetProtocolRequestTitles(int protocolRequestID)
        {
            IList results = new List<ProtocolTitle>() { };
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("ProtocolRequestTitlesSelect", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@ProtocolRequestID", SqlDbType.Int).Value = protocolRequestID;
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            ProtocolTitle title = new ProtocolTitle();
                            title.ID = Convert.ToInt32(reader[0].ToString());
                            title.ProtocolRequestID = protocolRequestID;
                            title.Description = reader[1].ToString();
                            title.LatestActivity.ProtocolEvent.Description = reader[2].ToString();
                            title.LatestActivity.CreatedBy = reader[3].ToString();
                            title.LatestActivity.CreatedDate = reader[4].ToString() == "" ? DateTime.Now :
                                                               Convert.ToDateTime(reader[4].ToString());
                            results.Add(title);
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

        public static IList GetProtocolRequestComments(int protocolRequestID)
        {
            IList results = new List<Comment>() { };
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("ProtocolRequestCommentsSelect", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@ProtocolRequestID", SqlDbType.Int).Value = protocolRequestID;
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Comment comment = new Comment();
                            comment.Content = reader[1].ToString();
                            comment.AddedBy = reader[3].ToString();
                            comment.AddedDate = Convert.ToDateTime(reader[4].ToString());
                            results.Add(comment);
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
    }
}
