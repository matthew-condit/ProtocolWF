using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toxikon.ProtocolManager.Queries;

namespace Toxikon.ProtocolManager.Models
{
    public class ProtocolTitle
    {
        public int ID { get; set; }
        public int ProtocolRequestID { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public ProtocolActivity LatestActivity { get; set; }
        public int CommentsCount { get; set; }
        public string ProtocolNumber { get; set; }
        public int DepartmentID { get; set; }
        public string ProjectNumber { get; set; }

        public string FileName { get; set; }
        public string FilePath { get; set; }

        public ProtocolTitle()
        {
            this.ID = 0;
            this.ProtocolRequestID = 0;
            this.Description = "";
            this.IsActive = false;
            this.LatestActivity = new ProtocolActivity();
            this.CommentsCount = 0;
            this.ProtocolNumber = "";
            this.DepartmentID = 0;
            this.ProjectNumber = "";
            this.FileName = "";
            this.FilePath = "";
        }

        public ProtocolTitle(int requestID, string description)
        {
            this.ProtocolRequestID = requestID;
            this.Description = description;
        }

        public void Submit()
        {
            LoginInfo loginInfo = LoginInfo.GetInstance();
            this.ID = QProtocolTitles.InsertItem(this, loginInfo.UserName);
        }
    }
}
