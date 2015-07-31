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
        private static List<AuditItem> auditItems;
 
        public AuditHandler()
        {
            auditItems = new List<AuditItem>();
        }

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

        public static void Insert_RemoveTitle_AuditItem(int requestID, int templateID, string userName)
        {
            AuditItem item = new AuditItem();
            item.TableName = "ProtocolRequestTemplates";
            item.Type = "U";
            item.PK = "RequestID,TemplateID";
            item.PKValue = requestID + "," + templateID;
            item.FieldName = "IsActive";
            item.OldValue = "true";
            item.NewValue = "false";
            item.UpdatedBy = userName;
            item.Reason = "Remove Title button clicked.";

            InsertAuditItem(item);
        }

        public static void Insert_ProtocolNumber_AuditItem(ProtocolNumber protocolNumber, string userName)
        {
            AuditItem item = new AuditItem();
            item.TableName = "ProtocolNumbers";
            item.Type = "I";
            item.PK = "RequestID,TemplateID";
            item.PKValue = protocolNumber.RequestID + "," + protocolNumber.TemplateID;
            item.FieldName = "ProtocolNumber";
            item.OldValue = "N/A";
            item.NewValue = protocolNumber.FullCode;
            item.UpdatedBy = userName;
            item.Reason = "Protocol Number button clicked.";

            InsertAuditItem(item);
        }

        public static void Insert_ReviseProtocol_AuditItem(string oldValue, 
                      ProtocolNumber protocolNumber, string userName)
        {
            AuditItem item = new AuditItem();
            item.TableName = "ProtocolNumbers";
            item.Type = "U";
            item.PK = "RequestID,TemplateID";
            item.PKValue = protocolNumber.RequestID + "," + protocolNumber.TemplateID;
            item.FieldName = "ProtocolNumber";
            item.OldValue = oldValue;
            item.NewValue = protocolNumber.FullCode;
            item.UpdatedBy = userName;
            item.Reason = "Revise Protocol button clicked.";

            InsertAuditItem(item);
        }

        public static void Insert_Department_AuditItem(string oldValue, ProtocolTemplate template, 
                                string userName)
        {
            AuditItem item = new AuditItem();
            item.TableName = "ProtocolRequestTemplates";
            item.Type = "U";
            item.PK = "RequestID,TemplateID";
            item.PKValue = template.RequestID + "," + template.TemplateID;
            item.FieldName = "DepartmentID";
            item.OldValue = oldValue == String.Empty ? "N/A" : oldValue;
            item.NewValue = template.Department.ID.ToString();
            item.UpdatedBy = userName;
            item.Reason = "Update using Department button.";

            InsertAuditItem(item);
        }

        public static void Insert_ProjectNumber_AuditItem(string oldValue, ProtocolTemplate template,
                                string userName)
        {
            AuditItem item = new AuditItem();
            item.TableName = "ProtocolRequestTemplates";
            item.Type = "U";
            item.PK = "RequestID,TemplateID";
            item.PKValue = template.RequestID + "," + template.TemplateID;
            item.FieldName = "ProjectNumber";
            item.OldValue = oldValue == String.Empty ? "N/A" : oldValue;
            item.NewValue = template.ProjectNumber;
            item.UpdatedBy = userName;
            item.Reason = "Update using Project Number button.";

            InsertAuditItem(item);
        }

        public static void Insert_UpdateFilePath_AuditItem(string oldValue, ProtocolTemplate template,
                                string userName)
        {
            AuditItem item = new AuditItem();
            item.TableName = "ProtocolRequestTemplates";
            item.Type = "U";
            item.PK = "RequestID,TemplateID";
            item.PKValue = template.RequestID + "," + template.TemplateID;
            item.FieldName = "FilePath";
            item.OldValue = oldValue == String.Empty ? "N/A" : oldValue;
            item.NewValue = template.FilePath;
            item.UpdatedBy = userName;
            item.Reason = "Update using Update File Path button.";

            InsertAuditItem(item);
        }

        public static void InsertAuditItems(List<AuditItem> auditItems)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("audit_insert", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        foreach(AuditItem item in auditItems)
                        {
                            command.Parameters.Clear();
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
            }
            catch (SqlException sqlEx)
            {
                ErrorHandler.CreateLogFile("AuditHandler", "InsertAuditItems", sqlEx);
            }
        }
    }
}
