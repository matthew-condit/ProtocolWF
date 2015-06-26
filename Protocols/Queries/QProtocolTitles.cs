﻿using Toxikon.ProtocolManager.Models;
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

        public static void InsertFromProtocolRequest(ProtocolRequest request, string userName)
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

        public static int Insert(ProtocolTitle title, string userName)
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
            catch (SqlException e)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "Insert", e);
            }
            return result;
        }

        public static void Update(ProtocolTitle title, string userName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("ProtocolRequestTitlesUpdate", connection))
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

        public static IList SelectByRequestID(int protocolRequestID)
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
                            title.CommentsCount = reader[5].ToString() == "" ? 0 :
                                                  Convert.ToInt32(reader[5].ToString());
                            title.ProtocolNumber = reader[6].ToString();
                            title.FileName = reader[7].ToString();
                            title.FilePath = reader[8].ToString();
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
        
        public static void UpdateFileInfo(ProtocolTitle title, string userName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("pr_titles_update_fileinfo", connection))
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
    }
}
