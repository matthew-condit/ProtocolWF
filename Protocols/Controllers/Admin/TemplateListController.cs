using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.ProtocolManager.Controllers.Templates;
using Toxikon.ProtocolManager.Interfaces.Templates;
using Toxikon.ProtocolManager.Models;
using Toxikon.ProtocolManager.Models.Admin;
using Toxikon.ProtocolManager.Queries;
using Toxikon.ProtocolManager.Views.Templates;

namespace Toxikon.ProtocolManager.Controllers.Admin
{
    public class TemplateListController : Controller
    {
        private IUCTemplate2 view;
        private IList comboBoxItems;
        private IList listViewItems;
        private Item comboBoxSelectedItem;
        private Template selectedTemplate;
        private string className = "TemplateListController";
        private List<AuditItem> auditItems;

        public TemplateListController(IUCTemplate2 view)
        {
            this.view = view;
            this.view.SetController(this);
            this.comboBoxItems = new ArrayList();
            this.listViewItems = new ArrayList();
            this.auditItems = new List<AuditItem>();
        }

        public void LoadView()
        {
            IList columns = new ArrayList(){"ID", "Title", "Active"};
            this.view.AddListViewColumns(columns);
            this.comboBoxItems = QTemplateGroups.GetActiveItems();
            if(this.comboBoxItems.Count != 0)
            {
                AddItemsToComboBox();
                this.view.SetComboBoxDisplayMember("Value");
                this.view.SetComboBoxSelectedIndex(0);
            }
        }

        private void SetColumnsHeaderSize()
        {
            this.view.SetListViewAutoResizeColumns(0, ColumnHeaderAutoResizeStyle.ColumnContent);
            this.view.SetListViewAutoResizeColumns(1, ColumnHeaderAutoResizeStyle.ColumnContent);
            this.view.SetListViewAutoResizeColumns(2, ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void AddItemsToComboBox()
        {
            foreach (Item item in comboBoxItems)
            {
                this.view.AddItemToComboBox(item);
            }
        }

        public void ComboBoxSelectedIndexChanged(int selectedIndex)
        {
            if (selectedIndex > -1 && selectedIndex < this.comboBoxItems.Count)
            {
                this.comboBoxSelectedItem = this.comboBoxItems[selectedIndex] as Item;
                LoadListViewItems();
            }
        }

        private void LoadListViewItems()
        {
            this.ClearListView();
            this.listViewItems = QTemplates.GetAllItemsByGroupID(this.comboBoxSelectedItem.ID);
            AddItemsToListView();
            SetColumnsHeaderSize();
        }

        public void ClearListView()
        {
            this.listViewItems.Clear();
            this.view.ClearListView();
            this.selectedTemplate = null;
        }

        public void AddItemsToListView()
        {
            foreach (Template item in listViewItems)
            {
                string[] values = new string[] { item.ID.ToString(), item.Title, item.IsActive.ToString() };
                this.view.AddItemToListView(values);
            }
        }

        public void ListViewSelectedIndexChanged(int selectedIndex)
        {
            if (selectedIndex > -1 && selectedIndex < this.listViewItems.Count)
            {
                this.selectedTemplate = listViewItems[selectedIndex] as Template;
            }
        }

        public void AddButtonClicked()
        {
            if (this.comboBoxSelectedItem != null && view.TextBoxValue.Trim() != "")
            {
                InsertNewTemplate();
                LoadListViewItems();
                this.view.ClearTextBox();
            }
            else
            {
                MessageBox.Show("All fields are required!");
            }
        }

        private void InsertNewTemplate()
        {
            LoginInfo loginInfo = LoginInfo.GetInstance();
            int templateID = QTemplates.InsertItem(this.comboBoxSelectedItem.ID, this.view.TextBoxValue, loginInfo.UserName);
        }

        public void UpdateButtonClicked()
        {
            if(this.selectedTemplate != null)
            {
                ShowPopup();
            }
            else
            {
                MessageBox.Show("Please select one template and try it again.");
            }
        }

        private void ShowPopup()
        {
            try
            {
                Item textBox1 = new Item("Title: ", this.selectedTemplate.Title);
                Item textBox2 = new Item("Group ID: ", this.selectedTemplate.GroupID.ToString());
                Item trueFalse = new Item("Active: ", this.selectedTemplate.IsActive.ToString());

                TwoTextBoxTrueFalseForm popup = new TwoTextBoxTrueFalseForm();
                TwoTextBoxTrueFalseFormController popupController = new TwoTextBoxTrueFalseFormController(popup);
                popupController.SetLabelTexts(textBox1.Name, textBox2.Name, trueFalse.Name);
                popupController.SetTextBoxTexts(textBox1.Value, textBox2.Value);
                popupController.SetTrueFalseValue(Convert.ToBoolean(trueFalse.Value));

                DialogResult dialogResult = popup.ShowDialog(this.view.ParentControl);
                if(dialogResult == DialogResult.OK)
                {
                    string title = popupController.TextBox1Value;
                    int groupID = Convert.ToInt32(popupController.TextBox2Value);
                    bool isActive = popupController.TrueFalseValue;
                    SubmitAuditItem(title, groupID, isActive);
                    SetSelectedTemplateValues(title, groupID, isActive);
                    UpdateSelectedTemplate();
                }
                popup.Dispose();
                
            }
            catch(FormatException ex)
            {
                this.selectedTemplate.Title = "";
                MessageBox.Show("Invalid group ID value.");
                ErrorHandler.CreateLogFile(this.className, "ShowPopup", ex);
            }
        }

        private void SetSelectedTemplateValues(string title, int groupID, bool isActive)
        {
            this.selectedTemplate.Title = title;
            this.selectedTemplate.GroupID = groupID;
            this.selectedTemplate.IsActive = isActive;
        }

        private void UpdateSelectedTemplate()
        {
            LoginInfo loginInfo = LoginInfo.GetInstance();
            QTemplates.UpdateItem(this.selectedTemplate, loginInfo.UserName);
            this.LoadListViewItems();
        }

        private void SubmitAuditItem(string title, int groupID, bool isActive)
        {
            CreateAuditItems(title, groupID, isActive);
            if (this.auditItems.Count != 0)
            {
                AuditHandler.InsertAuditItems(this.auditItems);
                this.auditItems.Clear();
            }
        }

        private void CreateAuditItems(string title, int groupID, bool isActive)
        {
            CheckAndAddToAuditItems("GroupID", this.selectedTemplate.GroupID.ToString(), groupID.ToString());
            CheckAndAddToAuditItems("Title", this.selectedTemplate.Title, title);
            CheckAndAddToAuditItems("IsActive", this.selectedTemplate.IsActive.ToString(), isActive.ToString());
        }

        private void CheckAndAddToAuditItems(string fieldName, string oldValue, string newValue)
        {
            if (oldValue.Trim() != newValue.Trim())
            {
                AuditItem item = CreateAuditItem(fieldName, oldValue, newValue);
                this.auditItems.Add(item);
            }
        }

        private AuditItem CreateAuditItem(string fieldName, string oldValue, string newValue)
        {
            LoginInfo loginInfo = LoginInfo.GetInstance();
            AuditItem item = new AuditItem();
            item.TableName = "Templates";
            item.Type = "U";
            item.PK = "ID";
            item.PKValue = this.selectedTemplate.ID.ToString();
            item.FieldName = fieldName;
            item.OldValue = oldValue.Trim() == String.Empty ? "N/A" : oldValue;
            item.NewValue = newValue;
            item.UpdatedBy = loginInfo.UserName;
            item.Reason = "Admin Template Update.";

            return item;
        }
    }
}
