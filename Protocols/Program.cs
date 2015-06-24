using Toxikon.ProtocolManager.Controllers;
using Toxikon.ProtocolManager.Models;
using Toxikon.ProtocolManager.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Toxikon.ProtocolManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            LoginInfo loginInfo = LoginInfo.GetInstance();
            if (loginInfo.UserName == "")
            {
                MessageBox.Show("Access is denied.");
            }
            else
            {
                MainView mainView = new MainView();
                MainViewController mainController = new MainViewController(mainView);
                mainController.LoadView();

                Application.Run(mainView);
            }
        }
    }
}
