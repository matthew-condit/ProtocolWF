using Protocols.Models;
using System;
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

        public static void InsertProtocolRequest(ProtocolRequest request)
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using(SqlCommand command = new SqlCommand("ProtocolRequestsInsert", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("RequestedDate", SqlDbType.DateTime).Value = request.RequestedDate;
                        command.Parameters.Add("RequestedBy", SqlDbType.NVarChar).Value = request.RequestedBy;
                        command.Parameters.Add("MatrixSponsorCode", SqlDbType.NVarChar).Value = 
                                               request.MatrixSponsorCode;
                        command.Parameters.Add("Guidelines", SqlDbType.NVarChar).Value = request.Guidelines;
                        command.Parameters.Add("Compliance", SqlDbType.NVarChar).Value = request.Compliance;
                        command.Parameters.Add("ProtocolType", SqlDbType.NVarChar).Value = request.ProtocolType;
                        command.Parameters.Add("DueDate", SqlDbType.DateTime).Value = request.DueDate;
                        command.Parameters.Add("SendVia", SqlDbType.NVarChar).Value = request.SendMethod;
                        command.Parameters.Add("BillTo", SqlDbType.NVarChar).Value = request.BillTo;

                        int result = command.ExecuteNonQuery();
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
        }

        public static void InsertProtocolRequestTitles(ProtocolRequest request, string userFullName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("ProtocolRequestTitlesInsert", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        foreach(string title in request.Titles)
                        {
                            command.Parameters.Add("ProtocolRequestID", SqlDbType.Int).Value = request.ID;
                            command.Parameters.Add("Title", SqlDbType.NVarChar).Value = title;
                            command.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = userFullName;
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

        public static void InsertProtocolRequestComments(ProtocolRequest request, string userFullName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("ProtocolRequestCommentsInsert", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        foreach (string comment in request.Comments)
                        {
                            command.Parameters.Add("ProtocolRequestID", SqlDbType.Int).Value = request.ID;
                            command.Parameters.Add("Comments", SqlDbType.NVarChar).Value = comment;
                            command.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = userFullName;
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
    }
}
