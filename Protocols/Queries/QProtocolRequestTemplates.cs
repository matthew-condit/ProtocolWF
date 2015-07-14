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
    public class QProtocolRequestTemplates
    {
        private static string connectionString = Utility.GetTPMConnectionString();
        private const string ErrorFormName = "QProtocolRequestTemplates";

        public static void InsertItems(List<ProtocolTemplate> items, string userName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    foreach (ProtocolTemplate item in items)
                    {
                        using (SqlCommand command = new SqlCommand("prt_insert_template", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Add("@RequestID", SqlDbType.Int).Value = item.RequestID;
                            command.Parameters.Add("@TemplateID", SqlDbType.Int).Value = item.TemplateID;
                            command.Parameters.Add("@CreatedBy", SqlDbType.NVarChar).Value = userName;

                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "InsertItems", e);
            }
        }

        public static void InsertItem(ProtocolTemplate item, string userName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("prt_insert_template", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@RequestID", SqlDbType.Int).Value = item.RequestID;
                        command.Parameters.Add("@TemplateID", SqlDbType.Int).Value = item.TemplateID;
                        command.Parameters.Add("@CreatedBy", SqlDbType.NVarChar).Value = userName;

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException e)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "InsertItem", e);
            }
        }

        public static IList SelectItems(int protocolRequestID)
        {
            IList results = new List<ProtocolTemplate>() { };
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("prt_select_templates", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@RequestID", SqlDbType.Int).Value = protocolRequestID;
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            ProtocolTemplate item = CreateNewProtocolTemplate(protocolRequestID, reader);
                            results.Add(item);
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

        private static ProtocolTemplate CreateNewProtocolTemplate(int protocolRequestID, SqlDataReader reader)
        {
            ProtocolTemplate template = new ProtocolTemplate();
            template.TemplateID = Convert.ToInt32(reader[0].ToString());
            template.RequestID = protocolRequestID;
            template.Description = reader[1].ToString();
            template.LatestActivity.ProtocolEvent.Description = reader[2].ToString();
            template.LatestActivity.CreatedBy = reader[3].ToString();
            template.LatestActivity.CreatedDate = reader[4].ToString() == "" ? DateTime.Now :
                                               Convert.ToDateTime(reader[4].ToString());
            template.CommentsCount = reader[5].ToString() == "" ? 0 : Convert.ToInt32(reader[5].ToString());
            template.ProtocolNumber.RequestID = template.RequestID;
            template.ProtocolNumber.TemplateID = template.TemplateID;
            template.ProtocolNumber.FullCode = reader[6].ToString().Trim();
            template.FileName = reader[7].ToString().Trim();
            template.FilePath = reader[8].ToString().Trim();
            template.ProjectNumber = reader[9].ToString().Trim();
            template.Department.Name = reader[10].ToString().Trim();

            return template;
        }
        
        public static void UpdateFileInfo(ProtocolTemplate title, string userName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("prt_update_fileinfo", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@RequestID", SqlDbType.Int).Value = title.RequestID;
                        command.Parameters.Add("@TitleID", SqlDbType.Int).Value = title.TemplateID;
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

        public static void UpdateProjectNumber(ProtocolTemplate title, string userName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("prt_update_projectnumber", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@RequestID", SqlDbType.Int).Value = title.RequestID;
                        command.Parameters.Add("@TitleID", SqlDbType.Int).Value = title.TemplateID;
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

        public static void UpdateDepartmentID(ProtocolTemplate title, string userName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("prt_update_department_id", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@RequestID", SqlDbType.Int).Value = title.RequestID;
                        command.Parameters.Add("@TitleID", SqlDbType.Int).Value = title.TemplateID;
                        command.Parameters.Add("@DepartmentID", SqlDbType.NVarChar).Value = title.Department.ID;
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
