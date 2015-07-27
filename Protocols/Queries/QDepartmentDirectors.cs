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
                        command.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = item.DepartmentName;
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

        public static IList SelectItems()
        {
            IList results = new ArrayList();
            try
            {

            }
            catch (SqlException ex)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "SelectItems", ex);
            }
            return results;
        }
    }
}
