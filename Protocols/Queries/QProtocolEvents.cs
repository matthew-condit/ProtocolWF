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

        public static void InsertProtocolEvent(ProtocolEvent protocolEvent, string userName)
        {
            using(SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand("ProtocolEventsInsert", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@EventType", SqlDbType.NVarChar).Value = protocolEvent.Type;
                    command.Parameters.Add("@EventDescription", SqlDbType.NVarChar).Value = protocolEvent.Description;
                    command.Parameters.Add("@CreatedBy", SqlDbType.NVarChar).Value = userName;

                    int result = command.ExecuteNonQuery();
                }
            }
        }

        public static IList SelectProtocolEvents()
        {
            IList results = new ArrayList();
            string query = @"SELECT ID, EventType, EventDescription, IsActive
                             FROM ProtocolEvents";
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    while(reader.Read())
                    {
                        ProtocolEvent protocolEvent = new ProtocolEvent();
                        protocolEvent.ID = Convert.ToInt32(reader[0].ToString());
                        protocolEvent.Type = reader[1].ToString();
                        protocolEvent.Description = reader[2].ToString();
                        protocolEvent.IsActive = Convert.ToBoolean(reader[3].ToString());
                        results.Add(protocolEvent);
                    }
                }
            }
            return results;
        }

        public static IList SelectProtocolEventsByType(string eventType)
        {
            IList results = new ArrayList();
            string query = @"SELECT ID, EventType, EventDescription, IsActive
                             FROM ProtocolEvents
                             WHERE EventType = @EventType";
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@EventType", SqlDbType.NVarChar).Value = eventType;
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ProtocolEvent protocolEvent = new ProtocolEvent();
                        protocolEvent.ID = Convert.ToInt32(reader[0].ToString());
                        protocolEvent.Type = reader[1].ToString();
                        protocolEvent.Description = reader[2].ToString();
                        protocolEvent.IsActive = Convert.ToBoolean(reader[3].ToString());
                        results.Add(protocolEvent);
                    }
                }
            }
            return results;
        }

        public static void UpdateProtocolEvent(ProtocolEvent protocolEvent, string userName)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("ProtocolEventsUpdate", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@EventID", SqlDbType.Int).Value = protocolEvent.ID;
                    command.Parameters.Add("@EventType", SqlDbType.NVarChar).Value = protocolEvent.Type;
                    command.Parameters.Add("@EventDescription", SqlDbType.NVarChar).Value = protocolEvent.Description;
                    command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = protocolEvent.IsActive;
                    command.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = userName;

                    int result = command.ExecuteNonQuery();
                }
            }
        }
    }
}
