using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toxikon.ProtocolManager.Models;

namespace Toxikon.ProtocolManager.Queries
{
    public class QLastSequenceNumber
    {
        private static string connectionString = Utility.GetTPMConnectionString();
        private const string ErrorFormName = "QLastSequenceNumber";

        public static int InsertLastSequenceNumber()
        {
            int result = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("LastSequenceNumberInsert", connection))
                    {
                        string year = DateTime.Now.ToString("yy");
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ID", year);

                        result = (int)command.ExecuteScalar();
                    }
                }
            }
            catch (SqlException ex)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "InsertLastSequenceNumber", ex);
            }
            return result;
        }

        public static void UpdateSequenceNumber(int year, int value)
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("LastSequenceNumberUpdate", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@ID", SqlDbType.Int).Value = year;
                        command.Parameters.Add("@Value", SqlDbType.Int).Value = value;

                        int result = command.ExecuteNonQuery();
                    }
                }
            }
            catch(SqlException ex)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "UpdateSequenceNumber", ex);
            }
        }
    }
}
