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
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(AppDomain_UnhandledException);

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

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs args)
        {
            MessageBox.Show("Application_ThreadException:" + args.Exception.ToString());
            //ErrorHandler.CreateLogFile("Program.cs", "Application_ThreadException", args.Exception);
        }

        static void AppDomain_UnhandledException(object sender, UnhandledExceptionEventArgs args)
        {
            MessageBox.Show("AppDomain_UnhandledException:" + ((Exception)args.ExceptionObject).ToString());
            //ErrorHandler.CreateLogFile("Program.cs", "AppDomain_UnhandledException", (Exception)args.ExceptionObject);
        }
    }
}
