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
    public class QDepartments
    {
        private static string CONNECTION_STRING = Utility.GetTPMConnectionString();
        private const string ErrorFormName = "QDepartments";

        public static Int32 InsertItem(Department department, string userName)
        {
            Int32 result = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    using (SqlCommand commamd = new SqlCommand("d_insert_department", connection))
                    {
                        commamd.CommandType = CommandType.StoredProcedure;
                        commamd.Parameters.AddWithValue("@DepartmentName", department.Name);
                        commamd.Parameters.AddWithValue("@CreatedBy", userName);

                        result = commamd.ExecuteNonQuery();
                    }
                }
            }
            catch(SqlException sqlEx)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "InsertDepartment", sqlEx);
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
                    using (SqlCommand command = new SqlCommand("d_select_all_departments", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Department department = new Department();
                            department.ID = Convert.ToInt32(reader[0].ToString());
                            department.Name = reader[1].ToString();
                            department.IsActive = Convert.ToBoolean(reader[2].ToString());
                            results.Add(department);
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "GetDepartments", sqlEx);
            }
            
            return results;
        }

        public static IList SelectItems2()
        {
            IList results = new ArrayList();
            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("d_select_all_departments", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Item item = new Item();
                            item.Value = reader[0].ToString();
                            item.Text = reader[1].ToString();
                            results.Add(item);
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "GetDepartments", sqlEx);
            }

            return results;
        }

        public static void UpdateItem(Department department, string userName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("d_update_department", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@ID", SqlDbType.Int).Value = department.ID;
                        command.Parameters.Add("@DepartmentName", SqlDbType.NVarChar).Value = department.Name;
                        command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = department.IsActive;
                        command.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = userName;

                        Int32 result = command.ExecuteNonQuery();
                    }
                }
            }
            catch(SqlException sqlEx)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "UpdateDepartment", sqlEx);
            }
        }
    }
}
