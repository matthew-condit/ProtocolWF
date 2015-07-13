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
                ProtocolActivity activity = new ProtocolActivity(title, 1, loginInfo.UserName);
                activity.Submit();
                RefreshTitleListView();
            }
        }

        public void EditTitleButtonClicked()
        {
            if(this.view.SelectedTitleIndexes.Count == 1)
            {
                EditSelectedTitleDescription();
            }
            else
            {
                MessageBox.Show(this.SelectOneMessage);
            }
        }

        private void EditSelectedTitleDescription()
        {
            ProtocolTitle title = GetSelectedTitleFromView();
            string description = TemplatesController.ShowOneTextBoxForm("Title: ", title.Description,
                                 this.view.ParentControl);
            if (description != String.Empty)
            {
                title.UpdateDescription(description);
                RefreshTitleListView();
            }
        }

        public void AddEventButtonClicked()
        {
            if(this.view.SelectedTitleIndexes.Count != 0)
            {
                AddEventToSelectedTitle();
            }
            else
            {
                MessageBox.Show("Please select at least one title and try it again.");
            }
        }

        private void AddEventToSelectedTitle()
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
                ShowSelectedTitleEvents();
            }
            else
            {
                MessageBox.Show(this.SelectOneMessage);
            }
        }

        private void ShowSelectedTitleEvents()
        {
            ProtocolTitle title = GetSelectedTitleFromView();
            IList events = QProtocolActivities.SelectItems(this.request.ID, title.ID);
            IList columns = new ArrayList() { "Date", "User", "Event" };
            TemplatesController.ShowReadOnlyListViewForm(columns, events, view.ParentControl);
        }

        public void AddCommentsButtonClicked()
        {
            if(this.view.SelectedTitleIndexes.Count == 1)
            {
                AddCommentsToSelectedTitle();   
            }
            else
            {
                MessageBox.Show(this.SelectOneMessage);
            }
        }

        private void AddCommentsToSelectedTitle()
        {
            string popupResult = TemplatesController.ShowOneTextBoxForm("Comments: ", "",
                                     this.view.ParentControl);
            if (popupResult != String.Empty)
            {
                ProtocolTitle title = GetSelectedTitleFromView();
                QProtocolComments.InsertItem(title, popupResult, loginInfo.UserName);
                RefreshTitleListView();
            }
        }

        public void ViewCommentsButtonClicked()
        {
            if(this.view.SelectedTitleIndexes.Count == 1)
            {
                ShowSelectedTitleComments();
            }
            else
            {
                MessageBox.Show(this.SelectOneMessage);
            }
        }

        private void ShowSelectedTitleComments()
        {
            ProtocolTitle title = GetSelectedTitleFromView();
            IList comments = QProtocolComments.SelectItems(title);
            IList columns = new ArrayList() { "Date", "User", "Comments" };
            TemplatesController.ShowReadOnlyListViewForm(columns, comments, view.ParentControl);
        }

        public void AddProtocolNumberButtonClicked()
        {
            if(this.view.SelectedTitleIndexes.Count == 1)
            {
                AssignProtocolNumberToSelectedTitle();
                this.RefreshTitleListView();
            }
            else
            {
                MessageBox.Show(this.SelectOneMessage);
            }
        }

        private void AssignProtocolNumberToSelectedTitle()
        {
            ProtocolTitle title = GetSelectedTitleFromView();
            title.AddProtocolNumber(this.request.ProtocolType);
        }

        public void ReviseProtocolButtonClicked()
        {
            if (this.view.SelectedTitleIndexes.Count == 1)
            {
                ReviseSelectedTitleProtocolNumber();
            }
            else
            {
                MessageBox.Show(this.SelectOneMessage);
            }
        }

        private void ReviseSelectedTitleProtocolNumber()
        {
            ProtocolTitle title = GetSelectedTitleFromView();
            if (title.ProtocolNumber.FullCode != String.Empty)
            {
                title.ProtocolNumber.Update();
                this.RefreshTitleListView();
                MessageBox.Show("Updated!");
            }
            else
            {
                MessageBox.Show("Invalid Protocol Number.");
            }
        }

        public void UpdateFilePathButtonClicked(string filePath)
        {
            if (this.view.SelectedTitleIndexes.Count == 1)
            {
                UpdateSelectedTitleFilePath(filePath);
                this.RefreshTitleListView();
            }
            else
            {
                MessageBox.Show(this.SelectOneMessage);
            }
        }

        private void UpdateSelectedTitleFilePath(string filePath)
        {
            ProtocolTitle title = GetSelectedTitleFromView();
            title.UpdateFileInfo(filePath);
        }

        public void OpenFileButtonClicked()
        {
            if (this.view.SelectedTitleIndexes.Count == 1)
            {
                ProtocolTitle title = GetSelectedTitleFromView();
                title.OpenFile();
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
                UpdateSelectedTitleProjectNumber();
            }
            else
            {
                MessageBox.Show(this.SelectOneMessage);
            }
        }

        private void UpdateSelectedTitleProjectNumber()
        {
            ProtocolTitle title = GetSelectedTitleFromView();
            string projectNumber = TemplatesController.ShowOneTextBoxForm("Project Number: ",
                                   title.ProjectNumber, this.view.ParentControl);
            if (projectNumber != String.Empty)
            {
                title.AddProjectNumber(projectNumber);
                this.RefreshTitleListView();
            }
        }

        public void DepartmentButtonClicked()
        {
            if (this.view.SelectedTitleIndexes.Count == 1)
            {
                UpdateSelectedTitleDepartment();
                this.RefreshTitleListView();
            }
            else
            {
                MessageBox.Show(this.SelectOneMessage);
            }
        }

        private void UpdateSelectedTitleDepartment()
        {
            Item selectedItem = SelectDepartmentFromOptions();
            if (selectedItem.Value != "")
            {
                ProtocolTitle title = GetSelectedTitleFromView();
                title.UpdateDepartment(Convert.ToInt32(selectedItem.Value));
            }
        }

        private Item SelectDepartmentFromOptions()
        {
            IList items = QDepartments.SelectItems2();
            Item selectedItem = TemplatesController.ShowListBoxOptionsForm(items, view.ParentControl);
            return selectedItem;
        }

        public void SaveChangedButtonClicked()
        {
            this.requestFormController.UpdateRequestWithViewValues();
            this.requestFormController.UpdateRequest();
            MessageBox.Show("Updated!");
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
                MainView mainView = (MainView)this.view.ParentControl;
                mainView.Invoke(mainView.LoadProtocolRequestViewDelegate, new object[] { this.request });
            }
        }

        public void DownloadRequestReportButtonClicked()
        {
            ProtocolRequestReport reportTemplate = new ProtocolRequestReport(this.request);
            reportTemplate.Create();
            MessageBox.Show("Download Complete!");
        }

    }
}
