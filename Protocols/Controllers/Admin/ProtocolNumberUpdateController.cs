using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toxikon.ProtocolManager.Interfaces.Admin;
using Toxikon.ProtocolManager.Models;
using Toxikon.ProtocolManager.Queries;

namespace Toxikon.ProtocolManager.Controllers.Admin
{
    public class ProtocolNumberUpdateController
    {
        private IProtocolNumberUpdateView view;
        private ProtocolNumber item;
        private const string className = "ProtocolNumberUpdateController";

        public ProtocolNumberUpdateController(IProtocolNumberUpdateView view)
        {
            this.view = view;
            this.view.SetController(this);
            this.item = new ProtocolNumber();
        }

        public void SearchButtonClicked()
        {
            try
            {
                this.item.RequestID = Convert.ToInt32(this.view.RequestID);
                this.item.TemplateID = Convert.ToInt32(this.view.TemmplateID);
                QProtocolNumbers.SelectItem(item);
                UpdateView_WithProtocolNumberValues();
            }
            catch(FormatException ex)
            {
                ErrorHandler.CreateLogFile(className, "SearchButtonClicked", ex);
            }
        }

        private void UpdateView_WithProtocolNumberValues()
        {
            this.view.ProtocolNumber = this.item.FullCode;
            this.view.YearNumber = this.item.YearNumber.ToString();
            this.view.SequenceNumber = this.item.SequenceNumber.ToString();
            this.view.RevisedNumber = this.item.RevisedNumber.ToString();
            this.view.ProtocolType = this.item.ProtocolType;
            this.view.IsActive = this.item.IsActive;
        }

        private void UpdateProtocolNumber_WithViewValues()
        {
            try
            {
                this.item.FullCode = this.view.ProtocolNumber;
                this.item.YearNumber = Convert.ToInt32(this.view.YearNumber);
                this.item.SequenceNumber = Convert.ToInt32(this.view.SequenceNumber);
                this.item.RevisedNumber = Convert.ToInt32(this.view.RevisedNumber);
                this.item.ProtocolType = this.view.ProtocolType;
                this.item.IsActive = this.view.IsActive;
            }
            catch(FormatException ex)
            {
                ErrorHandler.CreateLogFile(className, "UpdateProtocolNumber_WithViewValues", ex);
            }
        }

        public void UpdateButtonClicked()
        {
            UpdateProtocolNumber_WithViewValues();
            LoginInfo loginInfo = LoginInfo.GetInstance();
            QProtocolNumbers.UpdateAdvancedItem(this.item, loginInfo.UserName);
            this.view.ClearView();
        }
    }
}
