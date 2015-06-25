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

        public static void InsertProtocolComments(ProtocolTitle title, string comments, string userName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("ProtocolCommentsInsert", connection))
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

        public static IList SelectProtocolComments(ProtocolTitle title)
        {
            IList results = new ArrayList();
            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    string query = @"SELECT Comments, CreatedBy, CreatedDate
                                 FROM ProtocolComments
                                 WHERE ProtocolRequestID = @ProtocolRequestID
                                 AND ProtocolTitleID = @ProtocolTitleID
                                 AND IsActive = 1
                                 ORDER BY CreatedDate DESC";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.Text;

                        command.Parameters.Clear();
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
                ErrorHandler.CreateLogFile(ErrorFormName, "SelectProtocolComments", ex);
            }
            return results;
        }

        public static DataTable SelectProtocolCommentsDataTable(ProtocolTitle title)
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    string query = @"SELECT CONVERT(varchar(10), CreatedDate, 101) AS AddedDate, 
                                            CreatedBy AS AddedBy,
                                            Comments
                                 FROM ProtocolComments
                                 WHERE ProtocolRequestID = @ProtocolRequestID
                                 AND ProtocolTitleID = @ProtocolTitleID
                                 AND IsActive = 1
                                 ORDER BY CreatedDate ASC";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.Text;

                        command.Parameters.Clear();
                        command.Parameters.Add("@ProtocolRequestID", SqlDbType.Int).Value = title.ProtocolRequestID;
                        command.Parameters.Add("@ProtocolTitleID", SqlDbType.Int).Value = title.ID;
                        dataTable.Load(command.ExecuteReader());
                    }
                }
            }
            catch(SqlException sqlEx)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "SelectProtocolCommentsDataTable", sqlEx);
            }
            catch (FormatException formatEx)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "SelectProtocolCommentsDataTable", formatEx);
            }
            return dataTable;
        }
    }
}
