using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toxikon.ProtocolManager.Models;
using Toxikon.ProtocolManager.Models.Admin;

namespace Toxikon.ProtocolManager.Queries
{
    public class QDepartmentDirectors
    {
        private static string connectionString = Utility.GetTPMConnectionString();
        private const string ErrorFormName = "QDepartmentDirectors";

        public static void InsertItem(DepartmentDirector item)
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using(SqlCommand command = new SqlCommand("dd_insert_department_director", connection))
                    {
                        LoginInfo loginInfo = LoginInfo.GetInstance();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = item.DepartmentID;
                        command.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = item.UserName;
                        command.Parameters.Add("@CreatedBy", SqlDbType.NVarChar).Value = loginInfo.UserName;
                        int result = command.ExecuteNonQuery();
                    }
                }
            }
            catch(SqlException ex)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "InsertItem", ex);
            }
        }

        public static IList SelectAllItems()
        {
            IList results = new ArrayList();
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using(SqlCommand command = new SqlCommand("dd_select_department_directors", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        SqlDataReader reader = command.ExecuteReader();
                        while(reader.Read())
                        {
                            DepartmentDirector item = new DepartmentDirector();
                            item.ID = Convert.ToInt32(reader[0].ToString());
                            item.DepartmentID = Convert.ToInt32(reader[1].ToString());
                            item.DepartmentName = reader[2].ToString();
                            item.UserName = reader[3].ToString();
                            item.FullName = reader[4].ToString();
                            item.IsActive = Convert.ToBoolean(reader[5].ToString());
                            results.Add(item);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "SelectAllItems", ex);
            }
            catch(FormatException fe)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "SelectAllItems", fe);
            }
            return results;
        }
    }
}
