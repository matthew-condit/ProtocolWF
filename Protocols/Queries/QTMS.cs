using Toxikon.ProtocolManager.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toxikon.ProtocolManager.Queries
{
    public class QTMS
    {
        private static string GET_DEPARTMENTS =
        @"SELECT ListItems.Value AS DepartmentName
        FROM [TMS].[dbo].[tblValueListItems] AS ListItems
        INNER JOIN [TMS].[dbo].[tblValueList] AS List
        ON ListItems.ValueListID = List.ValueListID
        WHERE List.Name = 'DepartmentList'";

        private static string SEARCH_EMPLOYEE =
        @"
            SELECT Name As UserName, FirstName, LastName, FullName, 
                   ISNULL(EmailAddress, '') AS EmailAddress, PositionTitle
            FROM [TMS].[dbo].[tblUser]
            WHERE Name LIKE @SearchString
            AND IsActive = 1";

        private static string CONNECTION_STRING = Utility.GetTMSConnectionString();

        public static IList GetAllDepartments()
        {
            IList results = new ArrayList();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(GET_DEPARTMENTS, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        results.Add(reader[0].ToString());
                    }
                }
            }
            return results;
        }

        public static IList GetResultsFromSearchEmployee(string searchString)
        {
            searchString = "%" + searchString + "%";
            IList results = new ArrayList();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(SEARCH_EMPLOYEE, connection))
                {
                    command.Parameters.AddWithValue("@SearchString", searchString);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        User user = new User();
                        user.SetUserName(reader[0].ToString());
                        user.FirstName = reader[1].ToString();
                        user.LastName = reader[2].ToString();
                        user.FullName = reader[3].ToString();
                        user.EmailAddress = reader[4].ToString();
                        user.PositionTitle = reader[5].ToString();
                        results.Add(user);
                    }
                }
            }
            return results;
        }
    }
}
