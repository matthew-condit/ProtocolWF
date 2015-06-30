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
    public class QRoles
    {
        private static string CONNECTION_STRING = Utility.GetTPMConnectionString();
        private const string ErrorFormName = "QRoles";

        public static Int32 InsertItem(string roleName, string userName)
        {
            Int32 result = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("r_insert_role", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@RoleName", roleName);
                        command.Parameters.AddWithValue("@CreatedBy", userName);

                        result = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "InsertRole", sqlEx);
            }
            return result;
        }

        public static IList SelectItems()
        {
            IList results = new ArrayList();
            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("r_select_all_roles", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Role role = new Role();
                            role.RoleID = Convert.ToInt16(reader[0].ToString());
                            role.RoleName = reader[1].ToString();
                            role.IsActive = Convert.ToBoolean(reader[2].ToString());
                            results.Add(role);
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "GetRoles", sqlEx);
            }
            
            return results;
        }

        public static void UpdateItem(Role role, string userName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("r_update_role", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@ID", SqlDbType.Int).Value = role.RoleID;
                        command.Parameters.Add("@RoleName", SqlDbType.NVarChar).Value = role.RoleName;
                        command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = role.IsActive;
                        command.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = userName;

                        Int32 result = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "UpdateRole", sqlEx);
            }
        }
    }
}
