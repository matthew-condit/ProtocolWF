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

        public static int InsertItem(int groupID, string title, string userName)
        {
            int result = 0;
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
                        result = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            catch(SqlException ex)
            {
                ErrorHandler.CreateLogFile(className, "InsertItem", ex);
            }
            return result;
        }

        public static IList GetActiveItemsByGroupID(int groupID)
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
                            Template item = CreateItem(groupID, reader);
                            results.Add(item);
                        }
                    }
                }
            }
            catch(SqlException ex)
            {
                ErrorHandler.CreateLogFile(className, "GetItemsByGroupID", ex);
            }
            catch (FormatException fe)
            {
                ErrorHandler.CreateLogFile(className, "GetAllItemsByGroupID", fe);
            }
            return results;
        }

        public static IList GetAllItemsByGroupID(int groupID)
        {
            IList results = new ArrayList();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("t_admin_select_templates_by_groupid", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@GroupID", SqlDbType.Int).Value = groupID;
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Template item = CreateItem(groupID, reader);
                            results.Add(item);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                ErrorHandler.CreateLogFile(className, "GetAllItemsByGroupID", ex);
            }
            catch(FormatException fe)
            {
                ErrorHandler.CreateLogFile(className, "GetAllItemsByGroupID", fe);
            }
            return results;
        }

        private static Template CreateItem(int groupID, SqlDataReader reader)
        {
            if (reader == null) throw new ArgumentNullException();
            Template item = new Template();
            item.ID = Convert.ToInt32(reader[0].ToString());
            item.GroupID = groupID;
            item.Title = reader[1].ToString();
            item.IsActive = Convert.ToBoolean(reader[2].ToString());
            return item;
        }

        public static void UpdateItem(Template item, string userName)
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
                        command.Parameters.Add("@GroupID", SqlDbType.Int).Value = item.GroupID;
                        command.Parameters.Add("@Title", SqlDbType.NVarChar).Value = item.Title;
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
