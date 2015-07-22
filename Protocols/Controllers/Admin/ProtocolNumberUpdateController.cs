using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toxikon.ProtocolManager.Interfaces.Admin;
using Toxikon.ProtocolManager.Models;
using Toxikon.ProtocolManager.Models.Admin;
using Toxikon.ProtocolManager.Queries;

namespace Toxikon.ProtocolManager.Controllers.Admin
{
    public class ProtocolNumberUpdateController
    {
        private IProtocolNumberUpdateView view;
        private ProtocolNumber protocolNumber;
        private const string className = "ProtocolNumberUpdateController";
        private LoginInfo loginInfo;
        private List<AuditItem> auditItems;

        public ProtocolNumberUpdateController(IProtocolNumberUpdateView view)
        {
            this.view = view;
            this.view.SetController(this);
            this.protocolNumber = new ProtocolNumber();
            loginInfo = LoginInfo.GetInstance();
            auditItems = new List<AuditItem>();
        }

        public void SearchButtonClicked()
        {
            try
            {
                this.protocolNumber.RequestID = Convert.ToInt32(this.view.RequestID);
                this.protocolNumber.TemplateID = Convert.ToInt32(this.view.TemmplateID);
                QProtocolNumbers.SelectItem(protocolNumber);
                UpdateView_WithProtocolNumberValues();
            }
            catch(FormatException ex)
            {
                ErrorHandler.CreateLogFile(className, "SearchButtonClicked", ex);
            }
        }

        private void UpdateView_WithProtocolNumberValues()
        {
            this.view.ProtocolNumber = this.protocolNumber.FullCode;
            this.view.YearNumber = this.protocolNumber.YearNumber.ToString();
            this.view.SequenceNumber = this.protocolNumber.SequenceNumber.ToString();
            this.view.RevisedNumber = this.protocolNumber.RevisedNumber.ToString();
            this.view.ProtocolType = this.protocolNumber.ProtocolType;
            this.view.IsActive = this.protocolNumber.IsActive;
        }

        private void UpdateProtocolNumber_WithViewValues()
        {
            try
            {
                this.protocolNumber.FullCode = this.view.ProtocolNumber;
                this.protocolNumber.YearNumber = Convert.ToInt32(this.view.YearNumber);
                this.protocolNumber.SequenceNumber = Convert.ToInt32(this.view.SequenceNumber);
                this.protocolNumber.RevisedNumber = Convert.ToInt32(this.view.RevisedNumber);
                this.protocolNumber.ProtocolType = this.view.ProtocolType;
                this.protocolNumber.IsActive = this.view.IsActive;
            }
            catch(FormatException ex)
            {
                ErrorHandler.CreateLogFile(className, "UpdateProtocolNumber_WithViewValues", ex);
            }
        }

        public void UpdateButtonClicked()
        {
            SubmitAuditItems();
            UpdateProtocolNumber_WithViewValues();
            QProtocolNumbers.UpdateAdvancedItem(this.protocolNumber, loginInfo.UserName);
            this.view.ClearView();
        }

        private void SubmitAuditItems()
        {
            CreateAuditItems();
            if (this.auditItems.Count != 0)
            {
                AuditHandler.InsertAuditItems(this.auditItems);
                this.auditItems.Clear();
            }
        }

        private void CreateAuditItems()
        {
            CheckAndAddToAuditItems("FullCode", this.protocolNumber.FullCode, this.view.ProtocolNumber);
            CheckAndAddToAuditItems("YearNumber", this.protocolNumber.YearNumber.ToString(), 
                                    this.view.YearNumber.ToString());
            CheckAndAddToAuditItems("SequenceNumber", this.protocolNumber.SequenceNumber.ToString(), 
                                    this.view.SequenceNumber.ToString());
            CheckAndAddToAuditItems("RevisedNumber", this.protocolNumber.RevisedNumber.ToString(), 
                                    this.view.RevisedNumber.ToString());
            CheckAndAddToAuditItems("ProtocolType", this.protocolNumber.ProtocolType, this.view.ProtocolType);
            CheckAndAddToAuditItems("IsActive", this.protocolNumber.IsActive.ToString(), 
                                    this.view.IsActive.ToString());
        }

        private void CheckAndAddToAuditItems(string fieldName, string oldValue, string newValue)
        {
            if (oldValue.Trim() != newValue.Trim())
            {
                AuditItem item = CreateAuditItem(fieldName, oldValue, newValue);
                this.auditItems.Add(item);
            }
        }

        private AuditItem CreateAuditItem(string fieldName, string oldValue, string newValue)
        {
            AuditItem item = new AuditItem();
            item.TableName = "ProtocolNumbers";
            item.Type = "U";
            item.PK = "RequestID,TemplateID";
            item.PKValue = this.protocolNumber.RequestID.ToString() + "," + this.protocolNumber.TemplateID.ToString();
            item.FieldName = fieldName;
            item.OldValue = oldValue.Trim() == String.Empty ? "N/A" : oldValue;
            item.NewValue = newValue;
            item.UpdatedBy = loginInfo.UserName;
            item.Reason = "Admin Protocol Number Update.";

            return item;
        }
    }
}
