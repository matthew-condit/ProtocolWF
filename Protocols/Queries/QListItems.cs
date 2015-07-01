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
    public class QListItems
    {
        private static string CONNECTION_STRING = Utility.GetTPMConnectionString();

        public static void InsertItem(Item listItem, string userName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("li_insert_listitem", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@ListName", SqlDbType.NVarChar).Value = listItem.Name;
                        command.Parameters.Add("@ItemName", SqlDbType.NVarChar).Value = listItem.Text;
                        command.Parameters.Add("@CreatedBy", SqlDbType.NVarChar).Value = userName;

                        int result = command.ExecuteNonQuery();
                    }
                }
            }
            catch(SqlException sqlEx)
            {
                ErrorHandler.CreateLogFile("QListItems", "InsertListItem", sqlEx);
            }
        }

        public static IList SelectItems(string listName)
        {
            IList results = new ArrayList();
            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("li_select_listitems_by_listname", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@ListName", SqlDbType.NVarChar).Value = listName;

                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Item listItem = new Item();
                            listItem.Name = listName;
                            listItem.Text = reader[0].ToString();
                            listItem.Value = reader[0].ToString();
                            listItem.IsActive = Convert.ToBoolean(reader[1].ToString());
                            results.Add(listItem);
                        }
                    }
                }
            }
            catch(SqlException sqlEx)
            {
                ErrorHandler.CreateLogFile("QListItems", "GetListItems", sqlEx);
            }
            return results;
        }

        public static void UpdateItem(Item listItem, string oldItemName, string userName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("li_update_listitem", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@ListName", SqlDbType.NVarChar).Value = listItem.Name;
                        command.Parameters.Add("@OldItemName", SqlDbType.NVarChar).Value = oldItemName;
                        command.Parameters.Add("@NewItemName", SqlDbType.NVarChar).Value = listItem.Value;
                        command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = listItem.IsActive;
                        command.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = userName;
                        int result = command.ExecuteNonQuery();
                    }
                }
            }
            catch(SqlException sqlEx)
            {
                ErrorHandler.CreateLogFile("QListItems", "UpdateListItem", sqlEx);
            }
        }
    }
}
