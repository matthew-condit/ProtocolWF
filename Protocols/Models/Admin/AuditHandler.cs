using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toxikon.ProtocolManager.Models.Admin
{
    public class AuditHandler
    {
        private static string connectionString = Utility.GetTPMConnectionString();

        public static void InsertAuditItem(AuditItem item)
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using(SqlCommand command = new SqlCommand("audit_insert", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@TableName", SqlDbType.NVarChar).Value = item.TableName;
                        command.Parameters.Add("@Type", SqlDbType.NChar).Value = item.Type;
                        command.Parameters.Add("@PK", SqlDbType.NVarChar).Value = item.PK;
                        command.Parameters.Add("@PKValue", SqlDbType.NVarChar).Value = item.PKValue;
                        command.Parameters.Add("@FieldName", SqlDbType.NVarChar).Value = item.FieldName;
                        command.Parameters.Add("@OldValue", SqlDbType.NVarChar).Value = item.OldValue;
                        command.Parameters.Add("@NewValue", SqlDbType.NVarChar).Value = item.NewValue;
                        command.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = item.UpdatedBy;
                        command.Parameters.Add("@Reason", SqlDbType.NVarChar).Value = item.Reason;

                        int dbResult = command.ExecuteNonQuery();
                    }
                }
            }
            catch(SqlException sqlEx)
            {
                ErrorHandler.CreateLogFile("AuditHandler", "InsertAuditItem", sqlEx);
            }
        }
    }
}
