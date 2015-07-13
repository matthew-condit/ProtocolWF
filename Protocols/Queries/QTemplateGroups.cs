using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toxikon.ProtocolManager.Models;

namespace Toxikon.ProtocolManager.Queries
{
    public class QTemplateGroups
    {
        private static string connectionString = Utility.GetTPMConnectionString();
        private static string className = "QTemplateGroups";

        public static void InsertItem(string groupName, string userName)
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using(SqlCommand command = new SqlCommand("tg_insert_template_group", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@TemplateGroupName", SqlDbType.NVarChar).Value = groupName;
                        command.Parameters.Add("@CreatedBy", SqlDbType.NVarChar).Value = userName;

                        int result = command.ExecuteNonQuery();
                    }
                }
            }
            catch(SqlException ex)
            {
                ErrorHandler.CreateLogFile(className, "InsertItem", ex);
            }
        }

        public static IList GetAllItems()
        {
            IList results = new ArrayList();
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using(SqlCommand command = new SqlCommand("tg_select_all_template_groups", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        SqlDataReader reader = command.ExecuteReader();
                        while(reader.Read())
                        {
                            Item item = CreateItem(reader);
                            results.Add(item);
                        }
                    }
                }
            }
            catch(SqlException ex)
            {
                ErrorHandler.CreateLogFile(className, "GetAllItems", ex);
            }
            return results;
        }

        public static IList GetActiveItems()
        {
            IList results = new ArrayList();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("tg_select_active_template_groups", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Item item = CreateItem(reader);
                            results.Add(item);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                ErrorHandler.CreateLogFile(className, "GetActiveItems", ex);
            }
            return results;
        }

        private static Item CreateItem(SqlDataReader reader)
        {
            if (reader == null) throw new ArgumentNullException();

            Item item = new Item();
            item.ID = Convert.ToInt32(reader[0].ToString());
            item.Value = reader[1].ToString();
            item.IsActive = Convert.ToBoolean(reader[2].ToString());
            return item;
        }

        public static void UpdateItem(Item item, string userName)
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using(SqlCommand command = new SqlCommand("tg_update_template_group", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@ID", SqlDbType.Int).Value = item.ID;
                        command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = item.Value;
                        command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = item.IsActive;
                        command.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = userName;
                        int result = command.ExecuteNonQuery();
                    }
                }
            }
            catch(SqlException ex)
            {
                ErrorHandler.CreateLogFile(className, "UpdateItem", ex);
            }
        }
    }
}
