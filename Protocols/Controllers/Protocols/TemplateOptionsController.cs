﻿using System;
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
        public Item SelectedTemplate { get; private set; }

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
            foreach(Item item in templates)
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
                this.templates = QTemplates.GetItemsByGroupID(this.SelectedTemplateGroup.ID);
                this.LoadListBox2();
            }
        }

        public void ListBox2_SelectedIndexChanged(int selectedIndex)
        {
            if (selectedIndex > -1 && selectedIndex < this.templates.Count)
            {
                this.SelectedTemplateGroup = this.templates[selectedIndex] as Item;
            }
        }

        public void SubmitButtonClicked()
        {
            if(this.SelectedTemplate == null || this.SelectedTemplateGroup == null)
            {
                MessageBox.Show("Invalid selected item.");
                this.view.SetDialogResult(DialogResult.Retry);
            }
            else
            {
                this.view.SetDialogResult(DialogResult.OK);
            }
        }
    }
}
