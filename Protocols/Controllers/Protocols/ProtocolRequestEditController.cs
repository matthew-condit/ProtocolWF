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
        ProtocolRequest request;
        SponsorContact contact;
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
            this.request = protocolRequest;
            this.contact = protocolRequest.Contact;
            this.requestFormController.LoadView(this.request);
            this.RefreshTitleListView();
        }

        private void AddTilesToView()
        {
            this.view.ClearProtocolTitleListView();
            foreach(ProtocolTitle item in request.Titles)
            {
                this.view.AddTitleToView(item);
            }
        }

        private void RefreshTitleListView()
        {
            this.request.RefreshProtocolTitles();
            AddTilesToView();
            this.view.SetListViewAutoResizeColumns();
        }

        private ProtocolTitle GetSelectedTitleFromView()
        {
            int selectedIndex = Convert.ToInt32(this.view.SelectedTitleIndexes[0]);
            ProtocolTitle title = this.request.Titles[selectedIndex];
            return title;
        }

        public void AddTitleButtonClicked()
        {
            string description = TemplatesController.ShowOneTextBoxForm("Title: ", "", this.view.ParentControl);
            if(description != String.Empty)
            {
                ProtocolTitle title = new ProtocolTitle(this.request.ID, description);
                title.Submit();
                ProtocolActivity submittedRequest = new ProtocolActivity(title, 1, loginInfo.UserName);
                submittedRequest.Submit();
                RefreshTitleListView();
            }           
        }

        public void EditTitleButtonClicked()
        {
            if(this.view.SelectedTitleIndexes.Count == 1)
            {
                ProtocolTitle title = GetSelectedTitleFromView();
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

        public void AddEventButtonClicked()
        {
            if(this.view.SelectedTitleIndexes.Count != 0)
            {
                ProtocolEvent popupResult = ShowProtocolEventAddView();
                if (popupResult.Description != "")
                {
                    IList protocolActivities = CreateProtocolActivityList(popupResult.ID);
                    QProtocolActivities.InsertItems(protocolActivities);
                    MessageBox.Show("Submitted!");
                    RefreshTitleListView();
                }
            }
            else
            {
                MessageBox.Show("Please select at least one title and try it again.");
            }
        }

        private ProtocolEvent ShowProtocolEventAddView()
        {
            ProtocolEvent result = new ProtocolEvent();
            ProtocolEventAddView popup = new ProtocolEventAddView();
            ProtocolEventAddController popupController = new ProtocolEventAddController(popup);
            popupController.LoadView();
            DialogResult dialogResult = popup.ShowDialog(this.view.ParentControl);
            if (dialogResult == DialogResult.OK)
            {
                result = popupController.SelectedProtocolEvent;
            }
            return result;
        }

        private IList CreateProtocolActivityList(int eventID)
        {
            IList protocolActivities = new List<ProtocolActivity>() { };
            foreach (int titleIndex in this.view.SelectedTitleIndexes)
            {
                ProtocolTitle title = this.request.Titles[titleIndex];
                ProtocolActivity protocolActivity = new ProtocolActivity(title, eventID, loginInfo.UserName);
                protocolActivities.Add(protocolActivity);
            }
            return protocolActivities;
        }

        public void ViewEventsButtonClicked()
        {
            if (this.view.SelectedTitleIndexes.Count == 1)
            {
                ProtocolTitle title = GetSelectedTitleFromView();
                IList events = QProtocolActivities.SelectItems(this.request.ID, title.ID);
                IList columns = new ArrayList() { "Date", "User", "Event" };
                TemplatesController.ShowListViewFormReadOnly(columns, events, view.ParentControl);
            }
            else
            {
                MessageBox.Show(this.SelectOneMessage);
            }
        }

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
            ProtocolTitle title = this.request.Titles[selectedIndex];
            QProtocolComments.InsertItem(title, comments, loginInfo.UserName);
        }

        public void ViewCommentsButtonClicked()
        {
            if(this.view.SelectedTitleIndexes.Count == 1)
            {
                ProtocolTitle title = GetSelectedTitleFromView();
                IList comments = QProtocolComments.SelectItems(title);
                IList columns = new ArrayList() { "Date", "User", "Comments" };
                TemplatesController.ShowListViewFormReadOnly(columns, comments, view.ParentControl);
            }
            else
            {
                MessageBox.Show(this.SelectOneMessage);
            }
        }

        public void SaveChangedButtonClicked()
        {
            this.requestFormController.UpdateRequestWithViewValues();
            this.requestFormController.UpdateRequest();
            MessageBox.Show("Updated!");
        }

        public void AddProtocolNumberButtonClicked()
        {
            if(this.view.SelectedTitleIndexes.Count == 1)
            {
                ProtocolTitle title = GetSelectedTitleFromView();
                AddProtocolNumber(title);
            }
            else
            {
                MessageBox.Show(this.SelectOneMessage);
            }
        }

        private void AddProtocolNumber(ProtocolTitle title)
        {
            if (title.ProtocolNumber != String.Empty)
            {
                MessageBox.Show("Protocol Number already exists.\nTry Revised Protocol button instead.");
            }
            else
            {
                ProtocolNumber protocolNumber = ProtocolNumber.Create(title, this.request.ProtocolType);
                QProtocolNumbers.InsertItem(protocolNumber, loginInfo.UserName);
                this.RefreshTitleListView();
            }
        }

        public void RevisedProtocolButtonClicked()
        {
            if (this.view.SelectedTitleIndexes.Count == 1)
            {
                ProtocolTitle title = GetSelectedTitleFromView();
                if(title.ProtocolNumber != String.Empty)
                {
                    ProtocolNumber.Update(title, loginInfo.UserName);
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

        public void DownloadRequestReportButtonClicked()
        {
            ProtocolRequestReport reportTemplate = new ProtocolRequestReport(this.request);
            reportTemplate.Create();
            MessageBox.Show("Download Complete!");
        }

        public void CloseRequestButtonClicked()
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to close this request?",
                                        "Close Protocol Request",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question);
            if(dialogResult == DialogResult.Yes)
            {
                this.request.CloseRequest();
                QProtocolRequests.UpdateRequestStatus(this.request, loginInfo.UserName);
                MainView mainView = (MainView)this.view.ParentControl;
                mainView.Invoke(mainView.LoadProtocolRequestViewDelegate, new object[] { this.request });
            }
        }

        public void UpdateFilePathButtonClicked(string filePath)
        {
            if (this.view.SelectedTitleIndexes.Count == 1)
            {
                ProtocolTitle title = GetSelectedTitleFromView();
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
                ProtocolTitle title = GetSelectedTitleFromView();
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

        public void UpdateProjectNumberButtonClicked()
        {
            if (this.view.SelectedTitleIndexes.Count == 1)
            {
                ProtocolTitle title = GetSelectedTitleFromView();
                string result = TemplatesController.ShowOneTextBoxForm("Project Number: ", "", 
                                this.view.ParentControl);
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
