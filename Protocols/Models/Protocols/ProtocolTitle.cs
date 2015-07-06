using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        public ProtocolNumber ProtocolNumber { get; set; }
        public Department Department { get; set; }
        public string ProjectNumber { get; set; }

        public string FileName { get; set; }
        public string FilePath { get; set; }

        LoginInfo loginInfo;

        public ProtocolTitle()
        {
            this.ID = 0;
            this.ProtocolRequestID = 0;
            this.Description = "";
            this.IsActive = false;
            this.LatestActivity = new ProtocolActivity();
            this.CommentsCount = 0;
            this.ProtocolNumber = new ProtocolNumber();
            this.Department = new Department();
            this.ProjectNumber = "";
            this.FileName = "";
            this.FilePath = "";
            loginInfo = LoginInfo.GetInstance();
        }

        public ProtocolTitle(int requestID, string description)
        {
            this.ProtocolRequestID = requestID;
            this.Description = description;
        }

        public void Submit()
        {
            this.ID = QProtocolTitles.InsertItem(this, loginInfo.UserName);
        }

        public void UpdateDescription(string description)
        {
            this.Description = description;
            QProtocolTitles.UpdateTitle(this, loginInfo.UserName);
        }

        public void UpdateFileInfo(string filePath)
        {
            this.FileName = Path.GetFileName(filePath);
            this.FilePath = filePath;
            QProtocolTitles.UpdateFileInfo(this, loginInfo.UserName);
        }

        public void AddProtocolNumber(string protocolType)
        {
            if (this.ProtocolNumber.FullCode != String.Empty)
            {
                MessageBox.Show("Protocol Number already exists.");
            }
            else
            {
                this.ProtocolNumber = new ProtocolNumber();
                this.ProtocolNumber.Create(this, protocolType);
                QProtocolNumbers.InsertItem(this.ProtocolNumber, loginInfo.UserName);
            }
        }

        public void AddProjectNumber(string projectNumber)
        {
            this.ProjectNumber = projectNumber;
            QProtocolTitles.UpdateProjectNumber(this, loginInfo.UserName);
        }

        public void UpdateDepartment(int departmentID)
        {
            this.Department.ID = departmentID;
            QProtocolTitles.UpdateDepartmentID(this, loginInfo.UserName);
        }

        public void OpenFile()
        {
            if (this.FilePath != String.Empty && File.Exists(this.FilePath))
            {
                System.Diagnostics.Process.Start(this.FilePath);
            }
            else
            {
                MessageBox.Show("File does not exist.");
            }
        }
    }
}
