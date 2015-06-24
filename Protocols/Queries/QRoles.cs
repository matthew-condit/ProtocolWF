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

        public static Int32 InsertRole(string roleName, string userName)
        {
            Int32 result = 0;

            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("RolesInsert", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@RoleName", roleName);
                    command.Parameters.AddWithValue("@CreatedBy", userName);

                    result = command.ExecuteNonQuery();
                }
            }
            return result;
        }

        public static IList GetRoles()
        {
            IList results = new ArrayList();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                string query = @"SELECT ID, RoleName, IsActive
                                 FROM Roles";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.Text;
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
            return results;
        }

        public static void UpdateRole(Role role, string userName)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("RolesUpdate", connection))
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
    }
}
