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
    public class QUsers
    {
        private static string connectionString = Utility.GetTPMConnectionString();
        private const string ErrorFormName = "QUsers";

        public static Int32 InsertItem(User user, string userName)
        {
            Int32 result = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("u_insert_user", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserName", user.UserName);
                        command.Parameters.AddWithValue("@FirstName", user.FirstName);
                        command.Parameters.AddWithValue("@LastName", user.LastName);
                        command.Parameters.AddWithValue("@FullName", user.FullName);
                        command.Parameters.AddWithValue("@EmailAddress", user.EmailAddress);
                        command.Parameters.AddWithValue("@DepartmentID", user.Department.ID);
                        command.Parameters.AddWithValue("@RoleID", user.Role.RoleID);
                        command.Parameters.AddWithValue("@CreatedBy", userName);

                        result = command.ExecuteNonQuery();
                    }
                }
            }
            catch(SqlException sqlEx)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "InsertUser", sqlEx);
            }
            
            return result;
        }

        public static IList SelectItems()
        {
            IList results = new ArrayList();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("u_select_all_users", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            User user = CreateNewUser(reader);
                            results.Add(user);
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "GetUsers", sqlEx);
            }
            return results;
        }

        public static IList GetToxikonContacts()
        {
            IList results = new ArrayList();
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using(SqlCommand command = new SqlCommand("u_select_contact_users", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        
                    }
                }
            }
            catch(SqlException ex)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "GetToxikonContacts", ex);
            }
            return results;
        }

        public static IList SelectUsersByRoleID(int roleID)
        {
            IList results = new ArrayList();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("u_select_users_by_roleid", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@RoleID", SqlDbType.Int).Value = roleID;
                        command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = true;

                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Item item = new Item();
                            item.Value = reader[0].ToString();
                            item.Text = reader[3].ToString();
                            results.Add(item);
                        }
                    }
                }
            }
            catch(SqlException sqlEx)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "GetUsersByRoleID", sqlEx);
            }
            return results;
        }

        public static User SelectUser(string username)
        {
            User user = new User();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("u_select_user_by_username", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = username;
                        command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = true;

                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            user = CreateNewUser(reader);
                        }
                    }
                }
            }
            catch(SqlException sqlEx)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "GetUser", sqlEx);
            }

            return user;
        }

        private static User CreateNewUser(SqlDataReader reader)
        {
            User user = new User();
            user.UserName = reader[0].ToString();
            user.FirstName = reader[1].ToString();
            user.LastName = reader[2].ToString();
            user.FullName = reader[3].ToString();
            user.EmailAddress = reader[4].ToString();
            user.Department.SetDepartment(reader[5].ToString(), reader[6].ToString());
            user.Role.SetRole(reader[7].ToString(), reader[8].ToString());
            user.IsActive = Convert.ToBoolean(reader[9].ToString());

            return user;
        }

        public static void UpdateUser(User user, string userName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("u_update_user", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = user.UserName;
                        command.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = user.FirstName;
                        command.Parameters.Add("@LastName", SqlDbType.NChar).Value = user.LastName;
                        command.Parameters.Add("@FullName", SqlDbType.NVarChar).Value = user.FullName;
                        command.Parameters.Add("@EmailAddress", SqlDbType.NVarChar).Value = user.EmailAddress;
                        command.Parameters.Add("@DepartmentID", SqlDbType.NChar).Value = user.Department.ID;
                        command.Parameters.Add("@RoleID", SqlDbType.Int).Value = user.Role.RoleID;
                        command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = user.IsActive;
                        command.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = userName;

                        int result = command.ExecuteNonQuery();
                    }
                }
            }
            catch(SqlException sqlEx)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "UpdateUser", sqlEx);
            }
        }
    }
}
