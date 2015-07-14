using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.ProtocolManager.Controllers;
using Toxikon.ProtocolManager.Models;

namespace Toxikon.ProtocolManager.Interfaces.Templates
{
    public interface IUCTemplate2
    {
        void SetController(Controller controller);

        void AddItemToComboBox(Item item);
        void SetComboBoxDisplayMember(string displayMember);
        void SetComboBoxSelectedIndex(int selectedIndex);

        void AddListViewColumns(IList columns);
        void AddItemToListView(string[] values);
        void SetListViewAutoResizeColumns(int columnIndex, ColumnHeaderAutoResizeStyle style);
        void ClearListView();

        void ClearTextBox();

        string TextBoxValue { get; set; }
        Control ParentControl { get; }
    }
}
