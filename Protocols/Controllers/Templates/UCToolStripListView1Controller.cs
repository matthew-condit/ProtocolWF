using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toxikon.ProtocolManager.Controllers.Templates
{
    public abstract class UCToolStripListView1Controller
    {
        public abstract void LoadView();
        public abstract void NewButtonClicked();
        public abstract void UpdateButtonClicked();
        public abstract void ListViewSelectedIndexChanged(int selectedIndex);
    }
}
