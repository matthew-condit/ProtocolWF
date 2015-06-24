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
        private const string SelectProtocolActivitiesQuery1 = @"SELECT ProtocolActivities.ProtocolEventID,
                                                        ProtocolEvents.EventDescription,
                                                        ProtocolActivities.CreatedBy,
                                                        ProtocolActivities.CreatedDate
                                                  FROM ProtocolActivities
                                                  INNER JOIN ProtocolEvents
                                                  ON ProtocolActivities.ProtocolEventID = ProtocolEvents.ID
                                                  WHERE ProtocolActivities.ProtocolRequestID = @ProtocolRequestID
                                                  AND ProtocolActivities.ProtocolTitleID = @ProtocolTitleID
                                                  ORDER BY ProtocolActivities.CreatedDate DESC";

        public static void InsertProtocolActivities(IList protocolActivities)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("ProtocolActivitiesInsert", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    foreach(ProtocolActivity activity in protocolActivities)
                    {
                        command.Parameters.Clear();
                        command.Parameters.Add("@ProtocolRequestID", SqlDbType.Int).Value = activity.ProtocolRequestID;
                        command.Parameters.Add("@ProtocolTitleID", SqlDbType.Int).Value = activity.ProtocolTitleID;
                        command.Parameters.Add("@ProtocolEventID", SqlDbType.Int).Value = activity.ProtocolEvent.ID;
                        command.Parameters.Add("@CreatedBy", SqlDbType.NVarChar).Value = activity.CreatedBy;

                        int result = command.ExecuteNonQuery();
                    }
                }
            }
        }

        public static void InsertFromProtocolRequest(ProtocolRequest request, string userName)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("ProtocolActivitiesInsert", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    foreach (ProtocolTitle title in request.Titles)
                    {
                        command.Parameters.Clear();
                        command.Parameters.Add("@ProtocolRequestID", SqlDbType.Int).Value = request.ID;
                        command.Parameters.Add("@ProtocolTitleID", SqlDbType.Int).Value = title.ID;
                        command.Parameters.Add("@ProtocolEventID", SqlDbType.Int).Value = 1;
                        command.Parameters.Add("@CreatedBy", SqlDbType.NVarChar).Value = userName;

                        int result = command.ExecuteNonQuery();
                    }
                }
            }
        }

        public static void InsertProtocolActivity(ProtocolActivity activity)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("ProtocolActivitiesInsert", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Clear();
                    command.Parameters.Add("@ProtocolRequestID", SqlDbType.Int).Value = activity.ProtocolRequestID;
                    command.Parameters.Add("@ProtocolTitleID", SqlDbType.Int).Value = activity.ProtocolTitleID;
                    command.Parameters.Add("@ProtocolEventID", SqlDbType.Int).Value = activity.ProtocolEvent.ID;
                    command.Parameters.Add("@CreatedBy", SqlDbType.NVarChar).Value = activity.CreatedBy;

                    int result = command.ExecuteNonQuery();
                }
            }
        }

        public static IList SelectProtocolActivity(int requestID, int titleID)
        {
            IList results = new List<ProtocolActivity>() { };
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(SelectProtocolActivitiesQuery1, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@ProtocolRequestID", SqlDbType.Int).Value = requestID;
                    command.Parameters.Add("@ProtocolTitleID", SqlDbType.Int).Value = titleID;

                    SqlDataReader reader = command.ExecuteReader();
                    while(reader.Read())
                    {
                        ProtocolActivity activity = new ProtocolActivity();
                        activity.ProtocolRequestID = requestID;
                        activity.ProtocolTitleID = titleID;
                        activity.ProtocolEvent.ID = Convert.ToInt32(reader[0].ToString());
                        activity.ProtocolEvent.Description = reader[1].ToString();
                        activity.CreatedBy = reader[2].ToString();
                        activity.CreatedDate = Convert.ToDateTime(reader[3].ToString());

                        results.Add(activity);
                    }
                }
            }
            return results;
        }

        public static DataTable SelectProtocolActivitiesDataTable(int requestID, int titleID)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                string query = @"SELECT CONVERT(varchar(10), ProtocolActivities.CreatedDate, 101) AS AddedDate,
                                        ProtocolActivities.CreatedBy AS AddedBy,
                                        ProtocolEvents.EventDescription AS Event
                                    FROM ProtocolActivities
                                    INNER JOIN ProtocolEvents
                                    ON ProtocolActivities.ProtocolEventID = ProtocolEvents.ID
                                    WHERE ProtocolActivities.ProtocolRequestID = @ProtocolRequestID
                                    AND ProtocolActivities.ProtocolTitleID = @ProtocolTitleID
                                    ORDER BY ProtocolActivities.CreatedDate ASC";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@ProtocolRequestID", SqlDbType.Int).Value = requestID;
                    command.Parameters.Add("@ProtocolTitleID", SqlDbType.Int).Value = titleID;

                    dataTable.Load(command.ExecuteReader());
                }
            }
            return dataTable;
        }
    }
}
