using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toxikon.ProtocolManager.Models.Admin
{
    public class AuditItemUtility
    {
        public static AuditItem GetListNameUpdate(string fieldName, string pkValue, string oldValue, string newValue)
        {
            LoginInfo loginInfo = LoginInfo.GetInstance();
            AuditItem item = new AuditItem();
            item.TableName = "ListNames";
            item.Type = "U";
            item.PK = "Name";
            item.PKValue = pkValue;
            item.FieldName = fieldName;
            item.OldValue = oldValue.Trim() == String.Empty ? "N/A" : oldValue;
            item.NewValue = newValue;
            item.UpdatedBy = loginInfo.UserName;
            item.Reason = "Admin List Name Update.";

            return item;
        }
    }
}
