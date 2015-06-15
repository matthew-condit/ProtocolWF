using Protocols.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocols.Queries
{
    public class QListItems
    {
        private static string CONNECTION_STRING = Utility.GetTPMConnectionString();

        public static void InsertListItem(ListItem listItem, string userName)
        {
            using(SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand("ListItemsInsert", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@ListName", SqlDbType.NVarChar).Value = listItem.ListName;
                    command.Parameters.Add("@ItemName", SqlDbType.NVarChar).Value = listItem.ItemName;
                    command.Parameters.Add("@CreatedBy", SqlDbType.NVarChar).Value = userName;

                    int result = command.ExecuteNonQuery();
                }
            }
        }

        public static IList GetListItems(string listName)
        {
            IList results = new ArrayList();
            string query = @"SELECT ItemName, IsActive 
                             FROM ListItems
                             WHERE ListName = @ListName";
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@ListName", SqlDbType.NVarChar).Value = listName;

                    SqlDataReader reader = command.ExecuteReader();
                    while(reader.Read())
                    {
                        ListItem listItem = new ListItem();
                        listItem.ListName = listName;
                        listItem.ItemName = reader[0].ToString();
                        listItem.IsActive = Convert.ToBoolean(reader[1].ToString());
                        results.Add(listItem);
                    }
                }
            }
            return results;
        }

        public static void UpdateListItem(ListItem listItem, string userName)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("ListItemsUpdate", connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@ListName", SqlDbType.NVarChar).Value = listItem.ListName;
                    command.Parameters.Add("@ItemName", SqlDbType.NVarChar).Value = listItem.ItemName;
                    command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = listItem.IsActive;
                    command.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = userName;
                    int result = command.ExecuteNonQuery();
                }
            }
        }
    }
}
