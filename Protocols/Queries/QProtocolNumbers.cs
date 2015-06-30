using Toxikon.ProtocolManager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toxikon.ProtocolManager.Queries
{
    public class QProtocolNumbers
    {
        private static string connectionString = Utility.GetTPMConnectionString();
        private const string ErrorFormName = "QProtocolNumbers";

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

        public static void InsertItem(ProtocolNumber item, string userName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("pn_insert_protocol_number", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@ProtocolRequestID", SqlDbType.Int).Value = item.ProtocolRequestID;
                        command.Parameters.Add("@ProtocolTitleID", SqlDbType.Int).Value = item.ProtocolTitleID;
                        command.Parameters.Add("@ProtocolNumber", SqlDbType.NVarChar).Value = item.FullCode;
                        command.Parameters.Add("@YearNumber", SqlDbType.Int).Value = item.YearNumber;
                        command.Parameters.Add("@SequenceNumber", SqlDbType.Int).Value = item.SequenceNumber;
                        command.Parameters.Add("@RevisedNumber", SqlDbType.Int).Value = item.RevisedNumber;
                        command.Parameters.Add("@ProtocolType", SqlDbType.NChar).Value = item.ProtocolType;
                        command.Parameters.Add("@CreatedBy", SqlDbType.NVarChar).Value = userName;

                        int result = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "InsertProtocolNumber", ex);
            }
        }

        public static void SelectItem(ProtocolNumber item)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("pn_select_protocol_number", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@ProtocolRequestID", SqlDbType.Int).Value = item.ProtocolRequestID;
                        command.Parameters.Add("@ProtocolTitleID", SqlDbType.Int).Value = item.ProtocolTitleID;
                        command.Parameters.Add("@ProtocolNumber", SqlDbType.NVarChar).Value = item.FullCode;

                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            item.YearNumber = Convert.ToInt32(reader[0].ToString());
                            item.SequenceNumber = Convert.ToInt32(reader[1].ToString());
                            item.RevisedNumber = Convert.ToInt32(reader[2].ToString());
                            item.ProtocolType = reader[3].ToString();
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "SetProtocolNumber", ex);
            }
        }

        public static void UpdateItem(ProtocolNumber item, string userName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("pn_update_protocol_number", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@ProtocolRequestID", SqlDbType.Int).Value = item.ProtocolRequestID;
                        command.Parameters.Add("@ProtocolTitleID", SqlDbType.Int).Value = item.ProtocolTitleID;
                        command.Parameters.Add("@ProtocolNumber", SqlDbType.NVarChar).Value = item.FullCode;
                        command.Parameters.Add("@RevisedNumber", SqlDbType.Int).Value = item.RevisedNumber;
                        command.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = userName;

                        int result = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "UpdateProtocolNumber", ex);
            }
        }
    }
}
