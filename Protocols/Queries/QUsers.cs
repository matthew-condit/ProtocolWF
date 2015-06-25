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
        private static string CONNECTION_STRING = Utility.GetTPMConnectionString();

        public static Int32 InsertUser(User user, string userName)
        {
            Int32 result = 0;
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("UsersInsert", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@UserName", user.UserName);
                    command.Parameters.AddWithValue("@FirstName", user.FirstName);
                    command.Parameters.AddWithValue("@LastName", user.LastName);
                    command.Parameters.AddWithValue("@FullName", user.FullName);
                    command.Parameters.AddWithValue("@EmailAddress", user.EmailAddress);
                    command.Parameters.AddWithValue("@DepartmentID", user.Department.DepartmentID);
                    command.Parameters.AddWithValue("@RoleID", user.Role.RoleID);
                    command.Parameters.AddWithValue("@CreatedBy", userName);

                    result = command.ExecuteNonQuery();
                }
            }
            return result;
        }

        public static IList GetUsers()
        {
            IList results = new ArrayList();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                string query = @"SELECT Users.UserName, Users.FirstName, Users.LastName,
                                        Users.FullName, Users.EmailAddress, 
                                        Users.DepartmentID, Departments.DepartmentName, 
                                        Users.RoleID, Roles.RoleName, Users.IsActive
	                             FROM Users
	                             INNER JOIN Departments
	                             ON Users.DepartmentID = Departments.ID
	                             INNER JOIN Roles
	                             ON Users.RoleID = Roles.ID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        User user = CreateNewUser(reader);
                        results.Add(user);
                    }
                }
            }

            return results;
        }

        public static IList GetUsersByRoleID(int roleID, string listName)
        {
            IList results = new ArrayList();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                string query = @"SELECT Users.UserName, Users.FirstName, Users.LastName,
                                        Users.FullName, Users.EmailAddress, 
                                        Users.DepartmentID, Departments.DepartmentName, 
                                        Users.RoleID, Roles.RoleName, Users.IsActive
	                             FROM Users
	                             INNER JOIN Departments
	                             ON Users.DepartmentID = Departments.ID
	                             INNER JOIN Roles
	                             ON Users.RoleID = Roles.ID
                                 WHERE Users.RoleID = @RoleID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@RoleID", SqlDbType.Int).Value = roleID;

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ListItem item = new ListItem();
                        item.ListName = listName;
                        item.ItemName = reader[3].ToString() + '-' + reader[0].ToString();
                        results.Add(item);
                    }
                }
            }

            return results;
        }

        public static User GetUser(string username)
        {
            User user = new User();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                string query = @"SELECT Users.UserName, Users.FirstName, Users.LastName,
                                        Users.FullName, Users.EmailAddress, 
                                        Users.DepartmentID, Departments.DepartmentName, 
                                        Users.RoleID, Roles.RoleName, Users.IsActive
	                             FROM Users
	                             INNER JOIN Departments
	                             ON Users.DepartmentID = Departments.ID
	                             INNER JOIN Roles
	                             ON Users.RoleID = Roles.ID
                                 WHERE Users.UserName = @UserName
                                 AND Users.IsActive = 1";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = username;
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        user = CreateNewUser(reader);
                    }
                }
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
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("UsersUpdate", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = user.UserName;
                    command.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = user.FirstName;
                    command.Parameters.Add("@LastName", SqlDbType.NChar).Value = user.LastName;
                    command.Parameters.Add("@FullName", SqlDbType.NVarChar).Value = user.FullName;
                    command.Parameters.Add("@EmailAddress", SqlDbType.NVarChar).Value = user.EmailAddress;
                    command.Parameters.Add("@DepartmentID", SqlDbType.NChar).Value = user.Department.DepartmentID;
                    command.Parameters.Add("@RoleID", SqlDbType.Int).Value = user.Role.RoleID;
                    command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = user.IsActive;
                    command.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = userName;

                    Int32 result = command.ExecuteNonQuery();
                }
            }
        }
    }
}
