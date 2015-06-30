using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.ProtocolManager.Controllers.Templates;
using Toxikon.ProtocolManager.Interfaces.Protocols;
using Toxikon.ProtocolManager.Models;
using Toxikon.ProtocolManager.Models.Reports;
using Toxikon.ProtocolManager.Queries;
using Toxikon.ProtocolManager.Views.Templates;

namespace Toxikon.ProtocolManager.Controllers.Protocols
{
    public class ProtocolRequestReadOnlyController
    {
        IProtocolRequestReadOnlyView view;
        ProtocolRequest protocolRequest;
        SponsorContact sponsor;
        LoginInfo loginInfo;
        RequestFormController requestFormController;
        string SelectOneMessage = "Please select one title and try it again.";

        public ProtocolRequestReadOnlyController(IProtocolRequestReadOnlyView view)
        {
            this.view = view;
            this.view.SetController(this);
            loginInfo = LoginInfo.GetInstance();
            this.requestFormController = new RequestFormController(this.view.GetRequestForm);
            requestFormController.ClearForm();
        }

        public void LoadView(ProtocolRequest protocolRequest)
        {
            this.protocolRequest = protocolRequest;
            this.sponsor = protocolRequest.Contact;
            this.requestFormController.LoadView(this.protocolRequest);
            this.RefreshTitleListView();
        }

        public void ClearView()
        {
            this.requestFormController.ClearForm();
            this.view.ClearView();
        }

        private void AddTilesToView()
        {
            this.view.ClearProtocolTitleListView();
            foreach (ProtocolTitle item in protocolRequest.Titles)
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

        public void ShowListViewPopup(string itemType, IList items)
        {
            if (items.Count != 0)
            {
                ListViewPopup popup = new ListViewPopup();
                ListViewPopupController popupController = new ListViewPopupController(popup, itemType, items);
                popupController.LoadView();
                DialogResult dialogResult = popup.ShowDialog(this.view.ParentControl);
                popup.Dispose();
            }
            else
            {
                MessageBox.Show("No records found.");
            }
        }

        /********************************* PROTOCOL ACTIVITIES ***********************/
        public void ViewEventsButtonClicked()
        {
            if (this.view.SelectedTitleIndexes.Count == 1)
            {
                int selectedIndex = Convert.ToInt32(this.view.SelectedTitleIndexes[0]);
                ProtocolTitle title = this.protocolRequest.Titles[selectedIndex];
                IList events = QProtocolActivities.SelectItems(this.protocolRequest.ID, title.ID);
                ShowListViewPopup(ListViewPopupItemTypes.ProtocolEvent, events);
            }
            else
            {
                MessageBox.Show(this.SelectOneMessage);
            }
        }

        /*************************** COMMENTS EVENTS ***************************/
        public void ViewCommentsButtonClicked()
        {
            if (this.view.SelectedTitleIndexes.Count == 1)
            {
                int selectedIndex = Convert.ToInt32(this.view.SelectedTitleIndexes[0]);
                ProtocolTitle title = this.protocolRequest.Titles[selectedIndex];
                IList comments = QProtocolComments.SelectItems(title);
                ShowListViewPopup(ListViewPopupItemTypes.ProtocolComment, comments);
            }
            else
            {
                MessageBox.Show(this.SelectOneMessage);
            }
        }

        /*************************** DOWNLOAD PROTOCOL REQUEST REPORT ********************/
        public void DownloadRequestReportButtonClicked()
        {
            ProtocolRequestReport reportTemplate = new ProtocolRequestReport(this.protocolRequest);
            reportTemplate.Create();
            MessageBox.Show("Download Complete!");
        }

        public void OpenFileButtonClicked()
        {
            if (this.view.SelectedTitleIndexes.Count == 1)
            {
                int selectedIndex = Convert.ToInt32(this.view.SelectedTitleIndexes[0]);
                ProtocolTitle title = this.protocolRequest.Titles[selectedIndex];
                if (title.FilePath != String.Empty && File.Exists(title.FilePath))
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
    }
}
