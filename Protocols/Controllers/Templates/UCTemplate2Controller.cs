using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toxikon.ProtocolManager.Interfaces.Templates;
using Toxikon.ProtocolManager.Models;

namespace Toxikon.ProtocolManager.Controllers.Templates
{
    public class UCTemplate2Controller : Controller
    {
        private IUCTemplate2 view;
        private IList comboBoxItems;
        private IList listViewItems;
        public Item ComboBoxSelectedItem { get; private set; }
        public Item ListViewSelectedItem { get; private set; }

        public UCTemplate2Controller(IUCTemplate2 view)
        {
            this.view = view;
            this.view.SetController(this);
            this.comboBoxItems = new ArrayList();
            this.listViewItems = new ArrayList();
        }

        public void SetComboBoxItems(IList items)
        {
            this.comboBoxItems = items;
        }

        private void AddItemsToComboBox()
        {
            foreach(Item item in comboBoxItems)
            {
                this.view.AddItemToComboBox(item);
            }
        }

        public void ComboBoxSelectedIndexChanged(int selectedIndex)
        {
            if(selectedIndex > -1 && selectedIndex < this.comboBoxItems.Count)
            {
                this.ComboBoxSelectedItem = this.comboBoxItems[selectedIndex] as Item;
            }
        }

        public void ClearListView()
        {
            this.listViewItems.Clear();
            this.view.ClearListView();
        }

        public void SetListViewItems(IList items)
        {
            this.listViewItems = items;
        }

        public virtual void AddItemsToListView()
        {
            foreach(Item item in listViewItems)
            {
                string[] values = new string[] { item.ID.ToString(), item.Value, item.IsActive.ToString() };
                this.view.AddItemToListView(values);
            }
        }

        public void ListViewSelectedIndexChanged(int selectedIndex)
        {
            if (selectedIndex > -1 && selectedIndex < this.listViewItems.Count)
            {
                this.ListViewSelectedItem = listViewItems[selectedIndex] as Item;
            }
        }

    }
}
