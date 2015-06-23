using Protocols.Interfaces;
using Protocols.Models;
using Protocols.Queries;
using Protocols.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Protocols.Controllers
{
    public class ProtocolRequestEditController
    {
        IProtocolRequestEditView view;
        ProtocolRequest protocolRequest;
        Sponsor sponsor;
        LoginInfo loginInfo;
        string SelectOneMessage = "Please select one title and try it again.";

        public ProtocolRequestEditController(IProtocolRequestEditView view)
        {
            this.view = view;
            this.view.SetController(this);
            loginInfo = LoginInfo.GetInstance();
        }

        public void LoadView(ProtocolRequest protocolRequest)
        {
            this.protocolRequest = protocolRequest;
            this.sponsor = protocolRequest.Sponsor;
            UpdateViewWithProtocolRequest();
            this.RefreshTitleListView();
            UpdateViewWithSponsor();
        }

        private void UpdateViewWithProtocolRequest()
        {
            this.view.RequestedBy = protocolRequest.RequestedBy;
            this.view.RequestedDate = protocolRequest.RequestedDate.ToString("MM/dd/yyyy");
            this.view.Guidelines = protocolRequest.Guidelines;
            this.view.Compliance = protocolRequest.Compliance;
            this.view.ProtocolType = protocolRequest.ProtocolType;
            this.view.BillTo = protocolRequest.BillTo;
            this.view.SendVia = protocolRequest.SendMethod;
            this.view.DueDate = protocolRequest.DueDate;
            this.view.Comments = protocolRequest.Comments;
            this.view.AssignedTo = protocolRequest.AssignedTo;
        }

        private void AddTilesToView()
        {
            this.view.ClearProtocolTitleListView();
            foreach(ProtocolTitle item in protocolRequest.Titles)
            {
                this.view.AddTitleToView(item);
            }
        }

        private void UpdateViewWithSponsor()
        {
            this.view.ContactName = sponsor.SponsorContact;
            this.view.SponsorName = sponsor.SponsorName;
            this.view.Email = sponsor.Email;
            this.view.Address = sponsor.Address;
            this.view.City = sponsor.City;
            this.view.State = sponsor.State;
            this.view.ZipCode = sponsor.ZipCode;
            this.view.PhoneNumber = sponsor.PhoneNumber;
            this.view.FaxNumber = sponsor.FaxNumber;
            this.view.PONumber = sponsor.PONumber;
        }

        public void OpenCheckBoxOptions(string listName, IList items)
        {
            CheckBoxOptionsView popup = new CheckBoxOptionsView();
            CheckBoxOptionsController popupController = new CheckBoxOptionsController(popup, items);
            popupController.LoadView();

            DialogResult dialogResult = popup.ShowDialog(this.view.ParentControl);
            if (dialogResult == DialogResult.OK)
            {
                string itemsString = String.Join(", ", popupController.SelectedItems);
                SetListSelectedItems(listName, itemsString);
            }
            popup.Dispose();
        }

        public void OpenListBoxOptions(string listName, IList items)
        {
            ListBoxOptionsView popup = new ListBoxOptionsView();
            ListBoxOptionsController popupController = new ListBoxOptionsController(popup, items);
            popupController.LoadView();

            DialogResult dialogResult = popup.ShowDialog(this.view.ParentControl);
            if (dialogResult == DialogResult.OK)
            {
                SetListSelectedItems(listName, popupController.SelectedItem);
            }
            popup.Dispose();
        }

        private void SetListSelectedItems(string listName, string items)
        {
            switch (listName)
            {
                case ListNames.Guidelines:
                    this.protocolRequest.Guidelines = items;
                    this.view.Guidelines = items;
                    break;
                case ListNames.Compliance:
                    this.protocolRequest.Compliance = items;
                    this.view.Compliance = items;
                    break;
                case ListNames.ProtocolType:
                    this.protocolRequest.ProtocolType = items;
                    this.view.ProtocolType = items;
                    break;
                case ListNames.AssignedTo:
                    this.protocolRequest.AssignedTo = items;
                    this.view.AssignedTo = items;
                    break;
                default:
                    break;
            }
        }

        private void RefreshTitleListView()
        {
            this.protocolRequest.RefreshProtocolTitles();
            AddTilesToView();
            this.view.SetListViewAutoResizeColumns();
        }

        public string ShowOneTextBoxPopup(string textBoxLabel, string textBoxValue)
        {
            string result = "";
            OneTextBoxFormView popup = new OneTextBoxFormView();
            OneTextBoxFormController popupController = new OneTextBoxFormController(popup, textBoxLabel);
            popupController.TextBoxValue = textBoxValue;
            popupController.LoadView();

            DialogResult dialogResult = popup.ShowDialog(this.view.ParentControl);
            if (dialogResult == DialogResult.OK)
            {
                result = popupController.TextBoxValue;
            }
            popup.Dispose();
            return result;
        }

        public void ShowListViewPopup(string itemType, IList items)
        {
            if(items.Count != 0)
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

        /************************** PROTOCOL TITLE EVENTS ***************************/
        public void AddTitleButtonClicked()
        {
            string popupResult = ShowOneTextBoxPopup("Title: ", "");
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
            title.ID = QProtocolTitles.Insert(title, loginInfo.UserName);
            SubmitProtocolActivityToDB(title.ID);
        }

        private void SubmitProtocolActivityToDB(int titleID)
        {
            ProtocolActivity activity = new ProtocolActivity();
            activity.ProtocolRequestID = this.protocolRequest.ID;
            activity.ProtocolTitleID = titleID;
            activity.ProtocolEvent.ID = 1;
            activity.CreatedBy = loginInfo.UserName;

            QProtocolActivities.InsertProtocolActivity(activity);
        }

        public void EditTitleButtonClicked()
        {
            if(this.view.SelectedTitleIndexes.Count == 1)
            {
                int selectedIndex = Convert.ToInt32(this.view.SelectedTitleIndexes[0]);
                ProtocolTitle title = this.protocolRequest.Titles[selectedIndex];
                string popupResult = ShowOneTextBoxPopup("Title: ", title.Description);
                if (popupResult != String.Empty)
                {
                    title.Description = popupResult;
                    QProtocolTitles.Update(title, loginInfo.UserName);
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
            QProtocolActivities.InsertProtocolActivities(protocolActivities);
        }

        public void ViewEventsButtonClicked()
        {
            if (this.view.SelectedTitleIndexes.Count == 1)
            {
                int selectedIndex = Convert.ToInt32(this.view.SelectedTitleIndexes[0]);
                ProtocolTitle title = this.protocolRequest.Titles[selectedIndex];
                IList events = QProtocolActivities.SelectProtocolActivity(this.protocolRequest.ID, title.ID);
                ShowListViewPopup(ListViewPopupItemTypes.ProtocolEvent, events);
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
                string popupResult = ShowOneTextBoxPopup("Comments: ", "");
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
            QProtocolComments.InsertProtocolComments(title, comments, loginInfo.UserName);
        }

        public void ViewCommentsButtonClicked()
        {
            if(this.view.SelectedTitleIndexes.Count == 1)
            {
                int selectedIndex = Convert.ToInt32(this.view.SelectedTitleIndexes[0]);
                ProtocolTitle title = this.protocolRequest.Titles[selectedIndex];
                IList comments = QProtocolComments.SelectProtocolComments(title);
                ShowListViewPopup(ListViewPopupItemTypes.ProtocolComment, comments);
            }
            else
            {
                MessageBox.Show(this.SelectOneMessage);
            }
        }

        /**************************** SAVE CHANGES *************************/
        public void SaveChangedButtonClicked()
        {
            UpdateProtocolRequestWithViewValues();
            QProtocolRequests.Update(this.protocolRequest, loginInfo.UserName);
            MessageBox.Show("Updated!");
        }

        private void UpdateProtocolRequestWithViewValues()
        {
            this.protocolRequest.Guidelines = this.view.Guidelines;
            this.protocolRequest.Compliance = this.view.Compliance;
            this.protocolRequest.ProtocolType = this.view.ProtocolType;
            this.protocolRequest.DueDate = this.view.DueDate;
            this.protocolRequest.SendMethod = this.view.SendVia;
            this.protocolRequest.BillTo = this.view.BillTo;
            this.protocolRequest.AssignedTo = this.view.AssignedTo;
        }

        /*************************** PROTOCOL NUMBERS *************************/
        public void AddProtocolNumberButtonClicked()
        {
            if(this.view.SelectedTitleIndexes.Count == 1)
            {
                ProtocolNumber protocolNumber = CreateNewProtocolNumber();
                QProtocolNumbers.InsertProtocolNumber(protocolNumber, loginInfo.UserName);
                this.RefreshTitleListView();
            }
            else
            {
                MessageBox.Show(this.SelectOneMessage);
            }
        }

        private ProtocolNumber CreateNewProtocolNumber()
        {
            int selectedIndex = Convert.ToInt32(this.view.SelectedTitleIndexes[0]);
            ProtocolTitle title = this.protocolRequest.Titles[selectedIndex];
            ProtocolNumber protocolNumber = new ProtocolNumber();
            protocolNumber.SequenceNumber = QProtocolNumbers.InsertLastSequenceNumber();
            protocolNumber.ProtocolRequestID = this.protocolRequest.ID;
            protocolNumber.ProtocolTitleID = title.ID;
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
            ProtocolNumber protocolNumber = QProtocolNumbers.SelectProtocolNumber(this.protocolRequest.ID,
                               title.ID, title.ProtocolNumber);
            protocolNumber.RevisedNumber += 1;
            protocolNumber.SetFullCode();
            QProtocolNumbers.UpdateProtocolNumber(protocolNumber, loginInfo.UserName);
        }
    }
}
