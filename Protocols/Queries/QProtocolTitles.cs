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
    public class QProtocolTitles
    {
        private static string connectionString = Utility.GetTPMConnectionString();
        private const string ErrorFormName = "QProtocolTitles";

        public static void InsertItem(ProtocolRequest request, string userName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    foreach (ProtocolTitle item in request.Titles)
                    {
                        using (SqlCommand command = new SqlCommand("prt_insert_title", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Add("@ProtocolRequestID", SqlDbType.Int).Value = request.ID;
                            command.Parameters.Add("@Title", SqlDbType.NVarChar).Value = item.Description;
                            command.Parameters.Add("@CreatedBy", SqlDbType.NVarChar).Value = userName;
                            item.ID = Convert.ToInt32(command.ExecuteScalar());
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "InsertFromProtocolRequest", e);
            }
        }

        public static int InsertItem(ProtocolTitle title, string userName)
        {
            int result = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("prt_insert_title", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@ProtocolRequestID", SqlDbType.Int).Value = title.ProtocolRequestID;
                        command.Parameters.Add("@Title", SqlDbType.NVarChar).Value = title.Description;
                        command.Parameters.Add("@CreatedBy", SqlDbType.NVarChar).Value = userName;
                        result = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            catch (SqlException e)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "Insert", e);
            }
            return result;
        }

        public static void UpdateTitle(ProtocolTitle title, string userName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("prt_update_title", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@ID", SqlDbType.Int).Value = title.ID;
                        command.Parameters.Add("@Description", SqlDbType.NVarChar).Value = title.Description;
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

        public static IList SelectItems(int protocolRequestID)
        {
            IList results = new List<ProtocolTitle>() { };
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("prt_select_title", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@ProtocolRequestID", SqlDbType.Int).Value = protocolRequestID;
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            ProtocolTitle title = CreateNewProtocolTitle(protocolRequestID, reader);
                            results.Add(title);
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "SelectByRequestID", e);
            }
            return results;
        }

        private static ProtocolTitle CreateNewProtocolTitle(int protocolRequestID, SqlDataReader reader)
        {
            ProtocolTitle title = new ProtocolTitle();
            title.ID = Convert.ToInt32(reader[0].ToString());
            title.ProtocolRequestID = protocolRequestID;
            title.Description = reader[1].ToString();
            title.LatestActivity.ProtocolEvent.Description = reader[2].ToString();
            title.LatestActivity.CreatedBy = reader[3].ToString();
            title.LatestActivity.CreatedDate = reader[4].ToString() == "" ? DateTime.Now :
                                               Convert.ToDateTime(reader[4].ToString());
            title.CommentsCount = reader[5].ToString() == "" ? 0 :
                                  Convert.ToInt32(reader[5].ToString());
            title.ProtocolNumber.ProtocolRequestID = title.ProtocolRequestID;
            title.ProtocolNumber.ProtocolTitleID = title.ID;
            title.ProtocolNumber.FullCode = reader[6].ToString().Trim();
            title.FileName = reader[7].ToString().Trim();
            title.FilePath = reader[8].ToString().Trim();

            return title;
        }
        
        public static void UpdateFileInfo(ProtocolTitle title, string userName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("prt_update_fileinfo", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@TitleID", SqlDbType.Int).Value = title.ID;
                        command.Parameters.Add("@FileName", SqlDbType.NVarChar).Value = title.FileName;
                        command.Parameters.Add("@FilePath", SqlDbType.NVarChar).Value = title.FilePath;
                        command.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = userName;

                        int result = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException e)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "UpdateFileInfo", e);
            }
        }

        public static void UpdateProjectNumber(ProtocolTitle title, string userName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("prt_update_projectnumber", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@TitleID", SqlDbType.Int).Value = title.ID;
                        command.Parameters.Add("@ProjectNumber", SqlDbType.NVarChar).Value = title.ProjectNumber;
                        command.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = userName;

                        int result = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException e)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "UpdateProjectNumber", e);
            }
        }
    }
}
