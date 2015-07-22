using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.ProtocolManager.Interfaces.Protocols;
using Toxikon.ProtocolManager.Models;
using Toxikon.ProtocolManager.Queries;

namespace Toxikon.ProtocolManager.Controllers.Protocols
{
    public class TemplateOptionsController : Controller
    {
        private ITemplateOptionsForm view;
        private IList templateGroups;
        private IList templates;
        public Item SelectedTemplateGroup {get; private set; }
        public Template SelectedTemplate { get; private set; }

        public delegate void SubmitSelectedItem(Template Item);
        public SubmitSelectedItem SubmitSelectedItemDelegate;

        public TemplateOptionsController(ITemplateOptionsForm view)
        {
            this.view = view;
            this.view.SetController(this);
            this.templateGroups = new ArrayList();
            this.templates = new ArrayList();
        }

        public void LoadView()
        {
            this.templateGroups = QTemplateGroups.GetActiveItems();
            AddTemplateGroupsToListBox1();
        }

        private void AddTemplateGroupsToListBox1()
        {
            foreach(Item item in templateGroups)
            {
                this.view.AddItemToListBox1(item);
            }
        }

        private void LoadListBox2()
        {
            this.view.ClearListBox2();
            AddTemplatesToListBox2();
        }

        private void AddTemplatesToListBox2()
        {
            foreach(Template item in templates)
            {
                this.view.AddItemToListBox2(item);
            }
        }

        public void ListBox1_SelectedIndexChanged(int selectedIndex)
        {
            if(selectedIndex > - 1 && selectedIndex < this.templateGroups.Count)
            {
                this.SelectedTemplateGroup = this.templateGroups[selectedIndex] as Item;
                this.templates.Clear();
                this.templates = QTemplates.GetActiveItemsByGroupID(this.SelectedTemplateGroup.ID);
                this.LoadListBox2();
            }
        }

        public void ListBox2_SelectedIndexChanged(int selectedIndex)
        {
            if (selectedIndex > -1 && selectedIndex < this.templates.Count)
            {
                this.SelectedTemplate = this.templates[selectedIndex] as Template;
            }
        }

        public void SubmitButtonClicked()
        {
            if(this.view.CustomTemplate.Trim() != String.Empty)
            {
                SubmitCustomTemplate();
            }
            else
            {
                SubmitSelectedTemplate();
            }
            this.SelectedTemplate = null;
        }

        private void SubmitCustomTemplate()
        {
            this.SelectedTemplate = CreateCustomTemplate();
            if (this.SubmitSelectedItemDelegate != null)
            {
                this.SubmitSelectedItemDelegate(this.SelectedTemplate);
            }
            this.view.CustomTemplate = "";
        }

        private Template CreateCustomTemplate()
        {
            Template item = new Template();
            int groupID = 4;
            string title = this.view.CustomTemplate;
            LoginInfo loginInfo = LoginInfo.GetInstance();
            item.ID = QTemplates.InsertItem(groupID, title, loginInfo.UserName);
            item.Title = title;

            return item;
        }

        private void SubmitSelectedTemplate()
        {
            if (this.SelectedTemplate == null || this.SelectedTemplateGroup == null)
            {
                MessageBox.Show("Invalid selected item.");
                this.view.SetDialogResult(DialogResult.Retry);
            }
            else
            {
                if (this.SubmitSelectedItemDelegate != null)
                {
                    this.SubmitSelectedItemDelegate(this.SelectedTemplate);
                }
            }
        }
    }
}
