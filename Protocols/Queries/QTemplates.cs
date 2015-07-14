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
    public class QTemplates
    {
        private static string connectionString = Utility.GetTPMConnectionString();
        private static string className = "QTemplates";

        public static void InsertItem(int groupID, string title, string userName)
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using(SqlCommand command = new SqlCommand("t_insert_template", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@GroupID", SqlDbType.Int).Value = groupID;
                        command.Parameters.Add("@Title", SqlDbType.NVarChar).Value = title;
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

        public static IList GetItemsByGroupID(int groupID)
        {
            IList results = new ArrayList();
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using(SqlCommand command = new SqlCommand("t_select_templates_by_groupid", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@GroupID", SqlDbType.Int).Value = groupID;
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
                ErrorHandler.CreateLogFile(className, "GetItemsByGroupID", ex);
            }
            return results;
        }

        private static Item CreateItem(SqlDataReader reader)
        {
            if (reader == null) throw new ArgumentNullException();
            Item item = new Item();
            item.ID = Convert.ToInt32(reader[0].ToString());
            item.Text = reader[1].ToString();
            item.Value = reader[1].ToString();
            return item;
        }

        public static void UpdateItem(Item item, string userName)
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using(SqlCommand command = new SqlCommand("t_update_template", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@ID", SqlDbType.Int).Value = item.ID;
                        command.Parameters.Add("@Title", SqlDbType.NVarChar).Value = item.Value;
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
