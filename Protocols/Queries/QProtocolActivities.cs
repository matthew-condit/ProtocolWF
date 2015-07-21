using Toxikon.ProtocolManager.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toxikon.ProtocolManager.Queries
{
    public class QProtocolActivities
    {
        private static string CONNECTION_STRING = Utility.GetTPMConnectionString();
        private const string ErrorFormName = "QProtocolActivities";

        public static void InsertItems(IList protocolActivities)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("pa_insert_activity", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        foreach (ProtocolActivity activity in protocolActivities)
                        {
                            command.Parameters.Clear();
                            command.Parameters.Add("@RequestID", SqlDbType.Int).Value = activity.RequestID;
                            command.Parameters.Add("@TemplateID", SqlDbType.Int).Value = activity.TemplateID;
                            command.Parameters.Add("@EventID", SqlDbType.Int).Value = activity.ProtocolEvent.ID;
                            command.Parameters.Add("@CreatedBy", SqlDbType.NVarChar).Value = activity.CreatedBy;

                            int result = command.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "InsertProtocolActivities", ex);
            }
        }

        public static void InsertItem(ProtocolRequest request, IList templates, string userName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("pa_insert_activity", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        foreach (Template item in templates)
                        {
                            command.Parameters.Clear();
                            command.Parameters.Add("@RequestID", SqlDbType.Int).Value = request.ID;
                            command.Parameters.Add("@TemplateID", SqlDbType.Int).Value = item.ID;
                            command.Parameters.Add("@EventID", SqlDbType.Int).Value = 1;
                            command.Parameters.Add("@CreatedBy", SqlDbType.NVarChar).Value = userName;

                            int result = command.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "InsertFromProtocolRequest", ex);
            }
        }

        public static void InsertItem(ProtocolActivity activity)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("pa_insert_activity", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@RequestID", SqlDbType.Int).Value = activity.RequestID;
                        command.Parameters.Add("@TemplateID", SqlDbType.Int).Value = activity.TemplateID;
                        command.Parameters.Add("@EventID", SqlDbType.Int).Value = activity.ProtocolEvent.ID;
                        command.Parameters.Add("@CreatedBy", SqlDbType.NVarChar).Value = activity.CreatedBy;

                        int result = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "InsertProtocolActivity", ex);
            }
        }

        public static IList SelectItems(int requestID, int templateID)
        {
            IList results = new List<ProtocolActivity>() { };
            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("pa_select_all_activities", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@RequestID", SqlDbType.Int).Value = requestID;
                        command.Parameters.Add("@TemplateID", SqlDbType.Int).Value = templateID;
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            ProtocolActivity activity = CreateNewProtocolActivity(requestID, templateID, reader);
                            results.Add(activity);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "SelectProtocolActivity", ex);
            }
            return results;
        }

        private static ProtocolActivity CreateNewProtocolActivity(int requestID, int templateID, SqlDataReader reader)
        {
            ProtocolActivity activity = new ProtocolActivity();
            activity.RequestID = requestID;
            activity.TemplateID = templateID;
            activity.ProtocolEvent.ID = Convert.ToInt32(reader[0].ToString());
            activity.ProtocolEvent.Description = reader[1].ToString();
            activity.CreatedBy = reader[2].ToString();
            activity.CreatedDate = Convert.ToDateTime(reader[3].ToString());

            return activity;
        }

        public static DataTable SelectItemsToDataTable(int requestID, int templateID)
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("pa_select_all_activities_datatable", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@RequestID", SqlDbType.Int).Value = requestID;
                        command.Parameters.Add("@TemplateID", SqlDbType.Int).Value = templateID;

                        dataTable.Load(command.ExecuteReader());
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "SelectProtocolActivitiesDataTable", ex);
            }
            return dataTable;
        }
    }
}
