using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.ProtocolManager.Controllers.Templates;
using Toxikon.ProtocolManager.Models;
using Toxikon.ProtocolManager.Views.Templates;

namespace Toxikon.ProtocolManager.Controllers
{
    public class TemplatesController
    {
        public static string ShowOneTextBoxForm(string textBoxLabel, string textBoxValue, Control parentControl)
        {
            string result = "";
            OneTextBoxFormView popup = new OneTextBoxFormView();
            OneTextBoxFormController popupController = new OneTextBoxFormController(popup);
            popupController.TextBoxLabel = textBoxLabel;
            popupController.TextBoxValue = textBoxValue;
            popupController.LoadView();

            DialogResult dialogResult = popup.ShowDialog(parentControl);
            if(dialogResult == DialogResult.OK)
            {
                result = popupController.TextBoxValue;
            }
            popup.Dispose();

            return result;
        }

        public static Item ShowOneTextBoxTrueFalseForm(Item textBoxItem, Item trueFalseItem, 
                                                           Control parentControl)
        {
            Item result = new Item();
            OneTextBoxTrueFalseForm popup = new OneTextBoxTrueFalseForm();
            OneTextBoxTrueFalseFormController popupController = new OneTextBoxTrueFalseFormController(popup);
            popupController.SetTextBoxItem(textBoxItem.Name, textBoxItem.Value);
            popupController.SetTrueFalseItem(trueFalseItem.Name, Convert.ToBoolean(trueFalseItem.Value));

            DialogResult dialogResult = popup.ShowDialog(parentControl);
            if (dialogResult == DialogResult.OK)
            {
                result.Value = popupController.TextBoxValue;
                result.IsActive = popupController.TrueFalseValue;
            }
            popup.Dispose();
            return result;
        }

        public static void ShowListViewFormReadOnly(IList columns, IList items, Control parentControl)
        {
            if(items.Count > 0)
            {
                ListViewPopup popup = new ListViewPopup();
                ListViewPopupController popupController = new ListViewPopupController(popup, columns, items);
                popupController.LoadView();
                DialogResult dialogResult = popup.ShowDialog(parentControl);
                popup.Dispose();
            }
            else
            {
                MessageBox.Show("No records found.");
            }
        }

        public static List<string> ShowCheckBoxOptionsForm(IList items, Control parentControl)
        {
            CheckBoxOptionsView popup = new CheckBoxOptionsView();
            CheckBoxOptionsController popupController = new CheckBoxOptionsController(popup, items);
            popupController.LoadView();
            DialogResult dialogResult = popup.ShowDialog(parentControl);
            popup.Dispose();
            return popupController.SelectedItems;
        }

        public static Item ShowListBoxOptionsForm(IList items, Control parentControl)
        {
            ListBoxOptionsView popup = new ListBoxOptionsView();
            ListBoxOptionsController popupController = new ListBoxOptionsController(popup, items);
            popupController.LoadView();
            DialogResult dialogResult = popup.ShowDialog(parentControl);
            popup.Dispose();

            return popupController.SelectedItem;
        }
    }
}
