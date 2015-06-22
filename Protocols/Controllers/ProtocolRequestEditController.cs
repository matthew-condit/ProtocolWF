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
            AddTilesToView();
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

        public void OpenCheckBoxOptions(string listName)
        {
            IList items = QListItems.GetListItems(listName);
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

        public void OpenListBoxOptions(string listName)
        {
            IList items = QListItems.GetListItems(listName);
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
                default:
                    break;
            }
        }

        private void RefreshTitleListView()
        {
            this.protocolRequest.RefreshProtocolTitles();
            AddTilesToView();
        }

        /************************** PROTOCOL TITLE EVENTS ***************************/
        public void AddTitleButtonClicked()
        {
            OneTextBoxFormView popup = new OneTextBoxFormView();
            OneTextBoxFormController popupController = new OneTextBoxFormController(popup, "Title: ");
            popupController.LoadView();

            DialogResult dialogResult = popup.ShowDialog(this.view.ParentControl);
            if(dialogResult == DialogResult.OK)
            {
                ProtocolTitle title = CreateNewProtocolTitle(popupController.TextBoxValue);
                SubmitNewProtocolTitleToDB(title);
                RefreshTitleListView();
            }
            popup.Dispose();
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
            title.ID = QProtocolRequests.InsertProtocolTitle(title, loginInfo.UserName);
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
                OneTextBoxFormView popup = new OneTextBoxFormView();
                OneTextBoxFormController popupController = new OneTextBoxFormController(popup, "Title: ");
                popupController.TextBoxValue = title.Description;
                popupController.LoadView();

                DialogResult dialogResult = popup.ShowDialog(this.view.ParentControl);
                if (dialogResult == DialogResult.OK)
                {
                    title.Description = popupController.TextBoxValue;
                    QProtocolTitles.UpdateProtocolTitle(title, loginInfo.UserName);
                    RefreshTitleListView();
                }
                popup.Dispose();
            }
            else
            {
                MessageBox.Show("Please select 1 title and try it again.");
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
                MessageBox.Show("Please select at least 1 title and try it again.");
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
    }
}
