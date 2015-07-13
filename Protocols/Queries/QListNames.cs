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
    public class QListNames
    {
        private static string CONNECTION_STRING = Utility.GetTPMConnectionString();
        private const string ErrorFormName = "QListNames";

        public static void InsertItem(string listName, string userName)
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    using(SqlCommand command = new SqlCommand("ln_insert_listname", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@ListName", SqlDbType.NVarChar).Value = listName;
                        command.Parameters.Add("@CreatedBy", SqlDbType.NVarChar).Value = userName;

                        int result = command.ExecuteNonQuery();
                    }
                }
            }
            catch(SqlException sqlEx)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "InsertListName", sqlEx);
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
                    using (SqlCommand command = new SqlCommand("ln_select_all_listnames", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        SqlDataReader reader = command.ExecuteReader();
                        while(reader.Read())
                        {
                            Item listName = new Item();
                            listName.Name = reader[0].ToString();
                            listName.Value = reader[0].ToString();
                            listName.IsActive = Convert.ToBoolean(reader[1].ToString());

                            results.Add(listName);
                        }
                    }
                }
            }
            catch(SqlException sqlEx)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "SelectAll", sqlEx);
            }
            catch(FormatException formatEx)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "SelectAll", formatEx);
            }
            return results;
        }

        public static void UpdateItem(Item oldItem, Item newItem, string userName)
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    using(SqlCommand command = new SqlCommand("ln_update_listname", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@OldListName", SqlDbType.NVarChar).Value = oldItem.Name;
                        command.Parameters.Add("@NewListName", SqlDbType.NVarChar).Value = newItem.Value;
                        command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = newItem.IsActive;
                        command.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = userName;

                        int result = command.ExecuteNonQuery();
                    }
                }
            }
            catch(SqlException sqlEx)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "UpdateItem", sqlEx);
            }
        }
    }
}
