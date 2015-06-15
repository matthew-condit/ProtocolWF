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
    public class QDepartments
    {
        private static string CONNECTION_STRING = Utility.GetTPMConnectionString();

        public static Int32 InsertDepartment(Department department, string userName)
        {
            Int32 result = 0;

            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand commamd = new SqlCommand("DepartmentsInsert", connection))
                {
                    commamd.CommandType = CommandType.StoredProcedure;
                    commamd.Parameters.AddWithValue("@DepartmentName", department.DepartmentName);
                    commamd.Parameters.AddWithValue("@CreatedBy", userName);

                    result = commamd.ExecuteNonQuery();
                }
            }
            return result;
        }

        public static IList GetDepartments()
        {
            IList results = new ArrayList();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                string query = @"SELECT ID, DepartmentName, IsActive
                                FROM Departments";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Department department = new Department();
                        department.DepartmentID = Convert.ToInt32(reader[0].ToString());
                        department.SetDepartmentName(reader[1].ToString());
                        department.IsActive = Convert.ToBoolean(reader[2].ToString());
                        results.Add(department);
                    }
                }
            }
            return results;
        }

        public static void UpdateDepartment(Department department, string userName)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("DepartmentsUpdate", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@ID", SqlDbType.Int).Value = department.DepartmentID;
                    command.Parameters.Add("@DepartmentName", SqlDbType.NVarChar).Value = department.DepartmentName;
                    command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = department.IsActive;
                    command.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = userName;

                    Int32 result = command.ExecuteNonQuery();
                }
            }
        }
    }
}
