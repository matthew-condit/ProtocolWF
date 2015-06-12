using Protocols.Controllers;
using Protocols.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Protocols.Views
{
    public partial class MainView : Form, IMainView
    {
        MainViewController controller;

        public MainView()
        {
            InitializeComponent();
        }

        public void SetController(MainViewController controller)
        {
            this.controller = controller;
        }

        public void AddControlToMainPanel(Control control)
        {
            this.MainPanel.Controls.Clear();
            control.Dock = DockStyle.Fill;
            this.MainPanel.Controls.Add(control);
        }
    }
}
