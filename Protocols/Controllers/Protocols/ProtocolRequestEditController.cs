using Toxikon.ProtocolManager.Controllers.Templates;
using Toxikon.ProtocolManager.Interfaces.Protocols;
using Toxikon.ProtocolManager.Models;
using Toxikon.ProtocolManager.Models.Reports;
using Toxikon.ProtocolManager.Queries;
using Toxikon.ProtocolManager.Views;
using Toxikon.ProtocolManager.Views.Protocols;
using Toxikon.ProtocolManager.Views.Templates;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Toxikon.ProtocolManager.Controllers.Protocols
{
    public class ProtocolRequestEditController
    {
        IProtocolRequestEditView view;
        ProtocolRequest protocolRequest;
        SponsorContact sponsor;
        LoginInfo loginInfo;
        RequestFormController requestFormController;
        string SelectOneMessage = "Please select one title and try it again.";

        public ProtocolRequestEditController(IProtocolRequestEditView view)
        {
            this.view = view;
            this.view.SetController(this);
            loginInfo = LoginInfo.GetInstance();
            this.requestFormController = new RequestFormController(this.view.GetRequestForm);
        }

        public void LoadView(ProtocolRequest protocolRequest)
        {
            this.protocolRequest = protocolRequest;
            this.sponsor = protocolRequest.Contact;
            this.requestFormController.LoadView(this.protocolRequest);
            this.RefreshTitleListView();
        }

        private void AddTilesToView()
        {
            this.view.ClearProtocolTitleListView();
            foreach(ProtocolTitle item in protocolRequest.Titles)
            {
                this.view.AddTitleToView(item);
            }
        }

        private void RefreshTitleListView()
        {
            this.protocolRequest.RefreshProtocolTitles();
            AddTilesToView();
            this.view.SetListViewAutoResizeColumns();
        }

        /************************** PROTOCOL TITLE EVENTS ***************************/
        public void AddTitleButtonClicked()
        {
            string popupResult = TemplatesController.ShowOneTextBoxForm("Title: ", "", this.view.ParentControl);
            if(popupResult != String.Empty)
            {
                ProtocolTitle title = CreateNewProtocolTitle(popupResult);
                SubmitNewProtocolTitleToDB(title);
                RefreshTitleListView();
            }           
        }

        private ProtocolTitle CreateNewProtocolTitle(string description)
        {
            ProtocolTitle title = new ProtocolTitle();
            title.ProtocolRequestID = this.protocolRequest.ID;
            title.Description = description;
            return title;
        }

        private void SubmitNewProtocolTitleToDB(ProtocolTitle title)
        {
            LoginInfo loginInfo = LoginInfo.GetInstance();
            title.ID = QProtocolTitles.InsertItem(title, loginInfo.UserName);
            SubmitProtocolActivityToDB(title.ID);
        }

        private void SubmitProtocolActivityToDB(int titleID)
        {
            ProtocolActivity activity = new ProtocolActivity();
            activity.ProtocolRequestID = this.protocolRequest.ID;
            activity.ProtocolTitleID = titleID;
            activity.ProtocolEvent.ID = 1;
            activity.CreatedBy = loginInfo.UserName;

            QProtocolActivities.InsertItem(activity);
        }

        public void EditTitleButtonClicked()
        {
            if(this.view.SelectedTitleIndexes.Count == 1)
            {
                int selectedIndex = Convert.ToInt32(this.view.SelectedTitleIndexes[0]);
                ProtocolTitle title = this.protocolRequest.Titles[selectedIndex];
                string popupResult = TemplatesController.ShowOneTextBoxForm("Title: ", title.Description, 
                                     this.view.ParentControl);
                if (popupResult != String.Empty)
                {
                    title.Description = popupResult;
                    QProtocolTitles.UpdateTitle(title, loginInfo.UserName);
                    RefreshTitleListView();
                }
            }
            else
            {
                MessageBox.Show(this.SelectOneMessage);
            }
        }

        /********************************* PROTOCOL ACTIVITIES ***********************/
        public void AddEventButtonClicked()
        {
            if(this.view.SelectedTitleIndexes.Count != 0)
            {
                ProtocolEventAddView popup = new ProtocolEventAddView();
                ProtocolEventAddController popupController = new ProtocolEventAddController(popup);
                popupController.LoadView();

                DialogResult dialogResult = popup.ShowDialog(this.view.ParentControl);
                if(dialogResult == DialogResult.OK)
                {
                    InsertProtocolActivitiesToDB(popupController.SelectedProtocolEvent);
                    MessageBox.Show("Submitted!");
                    RefreshTitleListView();
                }
            }
            else
            {
                MessageBox.Show("Please select at least one title and try it again.");
            }
        }

        private void InsertProtocolActivitiesToDB(ProtocolEvent selectedProtocolEvent)
        {
            IList protocolActivities = new List<ProtocolActivity>() { };

            foreach(int titleIndex in this.view.SelectedTitleIndexes)
            {
                ProtocolTitle title = this.protocolRequest.Titles[titleIndex];
                ProtocolActivity protocolActivity = new ProtocolActivity();
                protocolActivity.ProtocolRequestID = this.protocolRequest.ID;
                protocolActivity.ProtocolTitleID = title.ID;
                protocolActivity.ProtocolEvent.ID = selectedProtocolEvent.ID;
                protocolActivity.CreatedBy = loginInfo.UserName;

                protocolActivities.Add(protocolActivity);
            }
            QProtocolActivities.InsertItems(protocolActivities);
        }

        public void ViewEventsButtonClicked()
        {
            if (this.view.SelectedTitleIndexes.Count == 1)
            {
                int selectedIndex = Convert.ToInt32(this.view.SelectedTitleIndexes[0]);
                ProtocolTitle title = this.protocolRequest.Titles[selectedIndex];
                IList events = QProtocolActivities.SelectItems(this.protocolRequest.ID, title.ID);
                IList columns = new ArrayList() { "Date", "User", "Event" };
                TemplatesController.ShowListViewFormReadOnly(columns, events, view.ParentControl);
            }
            else
            {
                MessageBox.Show(this.SelectOneMessage);
            }
        }

        /*************************** COMMENTS EVENTS ***************************/
        public void AddCommentsButtonClicked()
        {
            if(this.view.SelectedTitleIndexes.Count == 1)
            {
                string popupResult = TemplatesController.ShowOneTextBoxForm("Comments: ", "", 
                                     this.view.ParentControl);
                if(popupResult != String.Empty)
                {
                    InsertProtocolCommentsIntoDB(popupResult);
                    RefreshTitleListView();
                }
            }
            else
            {
                MessageBox.Show(this.SelectOneMessage);
            }
        }

        private void InsertProtocolCommentsIntoDB(string comments)
        {
            int selectedIndex = Convert.ToInt32(this.view.SelectedTitleIndexes[0]);
            ProtocolTitle title = this.protocolRequest.Titles[selectedIndex];
            QProtocolComments.InsertItem(title, comments, loginInfo.UserName);
        }

        public void ViewCommentsButtonClicked()
        {
            if(this.view.SelectedTitleIndexes.Count == 1)
            {
                int selectedIndex = Convert.ToInt32(this.view.SelectedTitleIndexes[0]);
                ProtocolTitle title = this.protocolRequest.Titles[selectedIndex];
                IList comments = QProtocolComments.SelectItems(title);
                IList columns = new ArrayList() { "Date", "User", "Comments" };
                TemplatesController.ShowListViewFormReadOnly(columns, comments, view.ParentControl);
            }
            else
            {
                MessageBox.Show(this.SelectOneMessage);
            }
        }

        /**************************** SAVE CHANGES *************************/
        public void SaveChangedButtonClicked()
        {
            this.requestFormController.UpdateRequestWithViewValues();
            this.requestFormController.UpdateRequest();
            MessageBox.Show("Updated!");
        }

        /*************************** PROTOCOL NUMBERS *************************/
        public void AddProtocolNumberButtonClicked()
        {
            if(this.view.SelectedTitleIndexes.Count == 1)
            {
                int selectedIndex = Convert.ToInt32(this.view.SelectedTitleIndexes[0]);
                ProtocolTitle title = this.protocolRequest.Titles[selectedIndex];
                if(title.ProtocolNumber != String.Empty)
                {
                    MessageBox.Show("Protocol Number already exists.\nTry Revised Protocol button instead.");
                }
                else
                {
                    ProtocolNumber protocolNumber = CreateNewProtocolNumber(title.ID);
                    QProtocolNumbers.InsertItem(protocolNumber, loginInfo.UserName);
                    this.RefreshTitleListView();
                }
            }
            else
            {
                MessageBox.Show(this.SelectOneMessage);
            }
        }

        private ProtocolNumber CreateNewProtocolNumber(int titleID)
        {
            ProtocolNumber protocolNumber = new ProtocolNumber();
            protocolNumber.SequenceNumber = QProtocolNumbers.InsertLastSequenceNumber();
            protocolNumber.ProtocolRequestID = this.protocolRequest.ID;
            protocolNumber.ProtocolTitleID = titleID;
            protocolNumber.ProtocolType = this.protocolRequest.ProtocolType == "File Copy" ? "A" : "B";
            protocolNumber.RevisedNumber = 0;
            protocolNumber.IsActive = true;
            protocolNumber.SetFullCode();
            
            return protocolNumber;
        }

        public void RevisedProtocolButtonClicked()
        {
            if (this.view.SelectedTitleIndexes.Count == 1)
            {
                int selectedIndex = Convert.ToInt32(this.view.SelectedTitleIndexes[0]);
                ProtocolTitle title = this.protocolRequest.Titles[selectedIndex];
                if(title.ProtocolNumber != String.Empty)
                {
                    UpdateProtocolNumber(title);
                    this.RefreshTitleListView();
                    MessageBox.Show("Updated!");
                }
                else
                {
                    MessageBox.Show("Invalid Protocol Number.");
                }
            }
            else
            {
                MessageBox.Show(this.SelectOneMessage);
            }
        }

        private void UpdateProtocolNumber(ProtocolTitle title)
        {
            ProtocolNumber protocolNumber = new ProtocolNumber();
            protocolNumber.ProtocolRequestID = this.protocolRequest.ID;
            protocolNumber.ProtocolTitleID = title.ID;
            protocolNumber.FullCode = title.ProtocolNumber;
            QProtocolNumbers.SelectItem(protocolNumber);
            protocolNumber.RevisedNumber += 1;
            protocolNumber.SetFullCode();
            QProtocolNumbers.UpdateItem(protocolNumber, loginInfo.UserName);
        }

        /*************************** DOWNLOAD PROTOCOL REQUEST REPORT ********************/
        public void DownloadRequestReportButtonClicked()
        {
            ProtocolRequestReport reportTemplate = new ProtocolRequestReport(this.protocolRequest);
            reportTemplate.Create();
            MessageBox.Show("Download Complete!");
        }

        /************************** CLOSE PROTOCOL REQUEST ***************************/
        public void CloseRequestButtonClicked()
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to close this request?",
                                        "Close Protocol Request",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question);
            if(dialogResult == DialogResult.Yes)
            {
                this.protocolRequest.CloseRequest();
                QProtocolRequests.UpdateRequestStatus(this.protocolRequest, loginInfo.UserName);
                MainView mainView = (MainView)this.view.ParentControl;
                mainView.Invoke(mainView.LoadProtocolRequestViewDelegate, new object[] { this.protocolRequest });
            }
        }

        /****************************** FILE PATH **********************************/
        public void UpdateFilePathButtonClicked(string filePath)
        {
            if (this.view.SelectedTitleIndexes.Count == 1)
            {
                int selectedIndex = Convert.ToInt32(this.view.SelectedTitleIndexes[0]);
                ProtocolTitle title = this.protocolRequest.Titles[selectedIndex];
                title.FileName = Path.GetFileName(filePath);
                title.FilePath = filePath;
                QProtocolTitles.UpdateFileInfo(title, loginInfo.UserName);
                this.RefreshTitleListView();
            }
            else
            {
                MessageBox.Show(this.SelectOneMessage);
            }
        }

        public void OpenFileButtonClicked()
        {
            if (this.view.SelectedTitleIndexes.Count == 1)
            {
                int selectedIndex = Convert.ToInt32(this.view.SelectedTitleIndexes[0]);
                ProtocolTitle title = this.protocolRequest.Titles[selectedIndex];
                if(title.FilePath != String.Empty && File.Exists(title.FilePath))
                {
                    System.Diagnostics.Process.Start(title.FilePath);
                }
                else
                {
                    MessageBox.Show("File does not exist.");
                }
            }
            else
            {
                MessageBox.Show(this.SelectOneMessage);
            }
        }

        /*********************************** PROJECT NUMBER *************************/
        public void UpdateProjectNumberButtonClicked()
        {
            if (this.view.SelectedTitleIndexes.Count == 1)
            {
                int selectedIndex = Convert.ToInt32(this.view.SelectedTitleIndexes[0]);
                ProtocolTitle title = this.protocolRequest.Titles[selectedIndex];
                string result = TemplatesController.ShowOneTextBoxForm("Project Number: ", "", this.view.ParentControl);
                if(result != String.Empty)
                {
                    title.ProjectNumber = result;
                    QProtocolTitles.UpdateProjectNumber(title, loginInfo.UserName);
                    this.RefreshTitleListView();
                }
            }
            else
            {
                MessageBox.Show(this.SelectOneMessage);
            }
        }
    }
}
