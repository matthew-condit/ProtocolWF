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
using System.Windows.Forms;

namespace Toxikon.ProtocolManager.Queries
{
    public class QProtocolComments
    {
        private static string CONNECTION_STRING = Utility.GetTPMConnectionString();
        private const string ErrorFormName = "QProtocolComments";

        public static void InsertComments(ProtocolTitle title, string comments, string userName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("pc_insert_comments", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Clear();
                        command.Parameters.Add("@ProtocolRequestID", SqlDbType.Int).Value = title.ProtocolRequestID;
                        command.Parameters.Add("@ProtocolTitleID", SqlDbType.Int).Value = title.ID;
                        command.Parameters.Add("@Comments", SqlDbType.NVarChar).Value = comments;
                        command.Parameters.Add("@CreatedBy", SqlDbType.NVarChar).Value = userName;

                        int result = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "InsertProtocolComments", ex);
            }
        }

        public static IList SelectActiveComments(ProtocolTitle title)
        {
            IList results = new ArrayList();
            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("pc_select_active_comments", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@ProtocolRequestID", SqlDbType.Int).Value = title.ProtocolRequestID;
                        command.Parameters.Add("@ProtocolTitleID", SqlDbType.Int).Value = title.ID;
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Comment comment = new Comment();
                            comment.Content = reader[0].ToString();
                            comment.CreatedBy = reader[1].ToString();
                            comment.CreatedDate = Convert.ToDateTime(reader[2].ToString());

                            results.Add(comment);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "SelectActiveComments", ex);
            }
            return results;
        }

        public static DataTable SelectActiveCommentsDataTable(ProtocolTitle title)
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("pc_select_active_comments_datatable", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Clear();
                        command.Parameters.Add("@ProtocolRequestID", SqlDbType.Int).Value = title.ProtocolRequestID;
                        command.Parameters.Add("@ProtocolTitleID", SqlDbType.Int).Value = title.ID;
                        dataTable.Load(command.ExecuteReader());
                    }
                }
            }
            catch(SqlException sqlEx)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "SelectActiveCommentsDataTable", sqlEx);
            }
            return dataTable;
        }
    }
}
