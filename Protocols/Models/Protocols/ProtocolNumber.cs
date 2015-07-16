using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toxikon.ProtocolManager.Queries;

namespace Toxikon.ProtocolManager.Models
{
    public class ProtocolNumber
    {
        public int RequestID { get; set; }
        public int TemplateID { get; set; }
        public string FullCode { get; set; }
        public int YearNumber { get; set; }
        public int SequenceNumber { get; set; }
        public string ProtocolType { get; set; } // A: File Copy or B: Single Copy
        public int RevisedNumber { get; set; }
        public bool IsActive { get; set; }

        public ProtocolNumber()
        {
            this.RequestID = 0;
            this.TemplateID = 0;
            this.FullCode = "";
            this.ProtocolType = "A";
            this.SequenceNumber = 0;
            this.RevisedNumber = 0;
            this.IsActive = false;
            this.YearNumber = Convert.ToInt32(DateTime.Now.ToString("yy"));
        }

        public void SetFullCode()
        {
            this.FullCode = "P" + this.YearNumber.ToString() + "-" + this.SequenceNumber.ToString("0000") + "-" +
                            this.RevisedNumber.ToString("00") + this.ProtocolType;
        }

        public void Create(ProtocolTemplate title, string type)
        {
            this.SequenceNumber = QLastSequenceNumber.InsertLastSequenceNumber();
            this.RequestID = title.RequestID;
            this.TemplateID = title.TemplateID;
            this.ProtocolType = type == "File Copy" ? "A" : "B";
            this.RevisedNumber = 0;
            this.IsActive = true;
            this.SetFullCode();
        }

        public void Update()
        {
            QProtocolNumbers.SelectItem(this);
            LoginInfo loginInfo = LoginInfo.GetInstance();
            this.RevisedNumber += 1;
            this.SetFullCode();
            QProtocolNumbers.UpdateItem(this, loginInfo.UserName);
        }

    }
}
