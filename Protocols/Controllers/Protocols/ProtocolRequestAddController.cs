using Toxikon.ProtocolManager.Interfaces.Protocols;
using Toxikon.ProtocolManager.Models;
using Toxikon.ProtocolManager.Queries;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Toxikon.ProtocolManager.Views.Templates;
using Toxikon.ProtocolManager.Controllers.Templates;
using Toxikon.ProtocolManager.Views.Protocols;
using Toxikon.ProtocolManager.Models.Admin;

namespace Toxikon.ProtocolManager.Controllers.Protocols
{
    public class ProtocolRequestAddController
    {
        private IProtocolRequestAddView view;
        private IList sponsorContacts;
        private ProtocolRequest request;
        private IList selectedTemplates;

        private RequestFormController requestFormController;
        private LoginInfo loginInfo;
        
        public ProtocolRequestAddController(IProtocolRequestAddView view)
        {
            this.view = view;
            this.view.SetController(this);
            this.sponsorContacts = new ArrayList();
            this.request = new ProtocolRequest();
            this.requestFormController = new RequestFormController(this.view.GetRequestForm);
            this.loginInfo = LoginInfo.GetInstance();
            this.selectedTemplates = new ArrayList();
        }

        public void LoadView()
        {
            InitProtocolRequest();
        }

        private void InitProtocolRequest()
        {
            LoginInfo loginInfo = LoginInfo.GetInstance();
            this.request.RequestedBy = loginInfo.FullName;
            this.request.RequestedDate = DateTime.Now;
        }

        public void SearchButtonClicked()
        {
            if(this.view.SearchSponsorName.Trim() == String.Empty)
            {
                MessageBox.Show("Sponsor name is required.");
            }
            else
            {
                DoSearch();
            }
        }

        private void DoSearch()
        {
            this.sponsorContacts.Clear();
            sponsorContacts = QMatrix.GetSponsorContacts(this.view.SearchSponsorName);
            if (sponsorContacts.Count == 0)
            {
                MessageBox.Show("No record found.");
            }
            else
            {
                this.view.ClearView();
                IList items = CreateContactList();
                int selectedIndex = ShowPopup(items);
                ContactListSelectedIndex(selectedIndex);
            }
        }

        private IList CreateContactList()
        {
            IList items = new ArrayList();
            foreach(SponsorContact contact in this.sponsorContacts)
            {
                Item item = new Item();
                item.Text = contact.ContactName;
                items.Add(item);
            }
            return items;
        }

        private int ShowPopup(IList items)
        {
            int result = -1;
            ListBoxForm popup = new ListBoxForm();
            ListBoxOptionsController popupController = new ListBoxOptionsController(popup, items);
            popupController.LoadView();
            DialogResult dialogResult = popup.ShowDialog();
            if(dialogResult == DialogResult.OK)
            {
                result = popupController.SelectedIndex;
            }
            return result;
        }

        public void ContactListSelectedIndex(int selectedIndex)
        {
            if(selectedIndex >= 0 && selectedIndex < this.sponsorContacts.Count)
            {
                this.request.SetContact((SponsorContact)this.sponsorContacts[selectedIndex]);
                this.requestFormController.LoadView(this.request);
            }
        }

        public void FindTemplateButtonClicked()
        {
            ShowTemplateOptionsPopup();
        }

        private void ShowTemplateOptionsPopup()
        {
            TemplateOptionsForm form = new TemplateOptionsForm();
            TemplateOptionsController formController = new TemplateOptionsController(form);
            formController.SubmitSelectedItemDelegate = new 
                TemplateOptionsController.SubmitSelectedItem(this.AddSelectedItemToDataGrid);
            formController.LoadView();
            DialogResult dialogResult = form.ShowDialog(this.view.ParentControl);
            
            form.Dispose();
        }

        private void AddSelectedItemToDataGrid(Template item)
        {
            this.selectedTemplates.Add(item);
            this.view.AddItemToDataGrid(item);
        }

        public void RemoveItemFromTemplates(int selectedIndex)
        {
            if(selectedIndex > -1 && selectedIndex < this.selectedTemplates.Count)
            {
                this.selectedTemplates.RemoveAt(selectedIndex);
            }
        }

        public void SubmitButtonClicked()
        {
            this.requestFormController.UpdateRequestWithViewValues();
            if (this.request.Contact.SponsorCode == String.Empty)
            {
                MessageBox.Show("No sponsor selected.");
            }
            else if (this.request.AssignedTo.UserName == String.Empty)
            {
                MessageBox.Show("Assigned To is required.");
            }
            else
            {
                SubmitFormWithConfirmation();
            }
        }

        private void SubmitFormWithConfirmation()
        {
            DialogResult dialogResult = ShowConfirmation();
            if (dialogResult == DialogResult.Yes)
            {
                this.requestFormController.SubmitRequest();
                QProtocolActivities.InsertItem(this.request, this.selectedTemplates, loginInfo.UserName);
                QProtocolRequestTemplates.InsertItems(this.request.ID, this.selectedTemplates, loginInfo.UserName);
                //EmailHandler.SendEmailTo_AssignedToUser(this.request, this.selectedTemplates);
                this.requestFormController.ClearForm();
                this.Clear();
                MessageBox.Show("Submitted!");
            }
        }

        private DialogResult ShowConfirmation()
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to submit the form?",
                "Confirmation",
                MessageBoxButtons.YesNo);
            return dialogResult;
        }

        private void Clear()
        {
            InitProtocolRequest();
            this.sponsorContacts.Clear();
            this.view.ClearView();
            this.selectedTemplates.Clear();
        }
    }
}
