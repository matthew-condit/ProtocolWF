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
                        command.Parameters.Add("@RequestID", SqlDbType.Int).Value = item.RequestID;
                        command.Parameters.Add("@TemplateID", SqlDbType.Int).Value = item.TemplateID;
                        command.Parameters.Add("@SponsorCode", SqlDbType.NVarChar).Value = item.SponsorCode;
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
                        command.Parameters.Add("@RequestID", SqlDbType.Int).Value = item.RequestID;
                        command.Parameters.Add("@TemplateID", SqlDbType.Int).Value = item.TemplateID;

                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            item.FullCode = reader[0].ToString().Trim();
                            item.YearNumber = Convert.ToInt32(reader[1].ToString());
                            item.SequenceNumber = Convert.ToInt32(reader[2].ToString());
                            item.RevisedNumber = Convert.ToInt32(reader[3].ToString());
                            item.ProtocolType = reader[4].ToString().Trim();
                            item.IsActive = Convert.ToBoolean(reader[5].ToString());
                            item.SponsorCode = reader[6].ToString().Trim();
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "SetProtocolNumber", ex);
            }
        }

        public static void GetExistSequenceNumber(ProtocolNumber item)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("pn_select_exist_protocol_number", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@TemplateID", SqlDbType.Int).Value = item.TemplateID;
                        command.Parameters.Add("@SponsorCode", SqlDbType.NVarChar).Value = item.SponsorCode;
                        command.Parameters.Add("@ProtocolType", SqlDbType.NChar).Value = item.ProtocolType;
                        command.Parameters.Add("@YearNumber", SqlDbType.Int).Value = item.YearNumber;

                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            item.SequenceNumber = Convert.ToInt32(reader[1].ToString());
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "GetExistingProtocolNumber", ex);
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
                        command.Parameters.Add("@RequestID", SqlDbType.Int).Value = item.RequestID;
                        command.Parameters.Add("@TemplateID", SqlDbType.Int).Value = item.TemplateID;
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

        public static void UpdateAdvancedItem(ProtocolNumber item, string userName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("pn_admin_update_protocol_number", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@RequestID", SqlDbType.Int).Value = item.RequestID;
                        command.Parameters.Add("@TemplateID", SqlDbType.Int).Value = item.TemplateID;
                        command.Parameters.Add("@ProtocolNumber", SqlDbType.NVarChar).Value = item.FullCode;
                        command.Parameters.Add("@YearNumber", SqlDbType.Int).Value = item.YearNumber;
                        command.Parameters.Add("@SequenceNumber", SqlDbType.Int).Value = item.SequenceNumber;
                        command.Parameters.Add("@RevisedNumber", SqlDbType.Int).Value = item.RevisedNumber;
                        command.Parameters.Add("@ProtocolType", SqlDbType.NChar).Value = item.ProtocolType;
                        command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = item.IsActive;
                        command.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = userName;

                        int result = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "UpdateAdvancedItem", ex);
            }
        }

        public static void UpdateItem_IsActive(int requestID, int templateID, bool isActive, string userName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("pn_update_isactive", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@RequestID", SqlDbType.Int).Value = requestID;
                        command.Parameters.Add("@TemplateID", SqlDbType.Int).Value = templateID;
                        command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = isActive;
                        command.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = userName;

                        int result = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException e)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "UpdateItem_IsActive", e);
            }
        }
    }
}
