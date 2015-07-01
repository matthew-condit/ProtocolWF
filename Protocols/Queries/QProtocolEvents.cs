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
    public class QProtocolEvents
    {
        private static string CONNECTION_STRING = Utility.GetTPMConnectionString();
        private const string ErrorFormName = "QProtocolEvents";

        public static void InsertItem(ProtocolEvent protocolEvent, string userName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("pe_insert_event", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@EventType", SqlDbType.NVarChar).Value = protocolEvent.Type;
                        command.Parameters.Add("@EventDescription", SqlDbType.NVarChar).Value = 
                                                protocolEvent.Description;
                        command.Parameters.Add("@CreatedBy", SqlDbType.NVarChar).Value = userName;

                        int result = command.ExecuteNonQuery();
                    }
                }
            }
            catch(SqlException ex)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "InsertProtocolEvent", ex);
            }
        }

        public static IList SelectItems()
        {
            IList results = new ArrayList();
            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("pe_select_all_events", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            ProtocolEvent protocolEvent = CreateNewProtocolEvent(reader);
                            results.Add(protocolEvent);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "SelectProtocolEvents", ex);
            }
            return results;
        }

        public static ProtocolEvent CreateNewProtocolEvent(SqlDataReader reader)
        {
            ProtocolEvent protocolEvent = new ProtocolEvent();
            protocolEvent.ID = Convert.ToInt32(reader[0].ToString());
            protocolEvent.Type = reader[1].ToString();
            protocolEvent.Description = reader[2].ToString();
            protocolEvent.IsActive = Convert.ToBoolean(reader[3].ToString());
            return protocolEvent;
        }

        public static IList SelectItemsByType(string eventType)
        {
            IList results = new ArrayList();
            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("pe_select_events_by_type", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@EventType", SqlDbType.NVarChar).Value = eventType;
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            ProtocolEvent protocolEvent = CreateNewProtocolEvent(reader);
                            results.Add(protocolEvent);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "SelectProtocolEventsByType", ex);
            }
            return results;
        }

        public static void UpdateItem(ProtocolEvent protocolEvent, string userName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("pe_update_event", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@EventID", SqlDbType.Int).Value = protocolEvent.ID;
                        command.Parameters.Add("@EventType", SqlDbType.NVarChar).Value = protocolEvent.Type;
                        command.Parameters.Add("@EventDescription", SqlDbType.NVarChar).Value = 
                                                protocolEvent.Description;
                        command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = protocolEvent.IsActive;
                        command.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = userName;

                        int result = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "UpdateProtocolEvent", ex);
            }
        }

        public static IList SelectTypes()
        {
            IList results = new ArrayList();
            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("pe_select_eventtypes", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            results.Add(reader[0].ToString());
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "SelectTypes", ex);
            }
            return results;
        }
    }
}
