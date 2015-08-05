using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;


namespace Toxikon.ProtocolManager.Models.Admin
{
    public class EmailHandler
    {
        public static void SendEmailTo_AssignedToUser_2(ProtocolRequest request, IList selectedTemplates)
        {
            try
            {
                string mailTo = "Bichngoc.McCulley@toxikon.com";
                string subject = "Protocol Request #" + request.ID.ToString() + ": " + request.Contact.SponsorName;
                string body = @"A new protocol request has been submitted." + "%0d%0A%0d%0A" +
                                    "Request Details:" + "%0d%0A" +
                                    "Guidelines: " + request.Guidelines + "%0d%0A" +
                                    "Compliance: " + request.Compliance + "%0d%0A" +
                                    "Protocol Type: " + request.ProtocolType + "%0d%0A" +
                                    "VIA: " + request.SendVia + "%0d%0A" +
                                    "Comments: " + request.Comments + "%0d%0A" +
                                    "Contact Name: " + request.Contact.ContactName + "%0d%0A" +
                                    "Email: " + request.Contact.Email + "%0d%0A%0d%0A" +
                                    "Titles:" + "%0d%0A";
                for (int i = 0; i < selectedTemplates.Count; i++)
                {
                    Template title = selectedTemplates[i] as Template;
                    body += (i + 1).ToString() + ": " + title.Title + "%0d%0A";
                }

                System.Diagnostics.Process.Start(string.Format(@"mailto:" + mailTo + "?subject=" + subject + "&body=" + body));
            }
            catch(System.ComponentModel.Win32Exception e1)
            {
                ErrorHandler.CreateLogFile("EmailHandler", "SendEmailTo_AssignedToUser_2", e1);
            }
            catch(System.ObjectDisposedException e2)
            {
                ErrorHandler.CreateLogFile("EmailHandler", "SendEmailTo_AssignedToUser_2", e2);
            }
            catch(System.IO.FileNotFoundException e3)
            {
                ErrorHandler.CreateLogFile("EmailHandler", "SendEmailTo_AssignedToUser_2", e3);
            }
        }

        public static void SendEmailTo_AssignedToUser(ProtocolRequest request, IList selectedTemplates)
        {
            try
            {
                LoginInfo loginInfo = LoginInfo.GetInstance();

                Outlook.Application outlookApp = GetApplicationObject();
                Outlook._MailItem mailItem = (Outlook.MailItem)outlookApp.CreateItem(Outlook.OlItemType.olMailItem);
                mailItem.Subject = "Protocol Request #" + request.ID.ToString() + ": " + request.Contact.SponsorName;
                string body = @"A new protocol request has been submitted." + "\n\n" + 
                                "Request Details:" + "\n" +
                                "Guidelines: " + request.Guidelines + "\n" +
                                "Compliance: " + request.Compliance + "\n" +
                                "Protocol Type: " + request.ProtocolType + "\n" + 
                                "VIA: " + request.SendVia + "\n" +
                                "Comments: " + request.Comments + "\n" +
                                "Contact Name: " + request.Contact.ContactName + "\n" +
                                "Email: " + request.Contact.Email + "\n\n" +
                                "Titles:" + "\n";
                for(int i = 0; i < selectedTemplates.Count; i++)
                {
                    Template title = selectedTemplates[i] as Template;
                    body += (i + 1).ToString() + ": " + title.Title + "\n";
                }

                mailItem.Body = body;

                Outlook.Recipient recipient = (Outlook.Recipient)mailItem.Recipients.Add("Bichngoc.McCulley@toxikon.com");
                recipient.Resolve();

                mailItem.Send();

                recipient = null;
                mailItem = null;
                outlookApp = null;
            }
            catch (Exception e)
            {
                ErrorHandler.CreateLogFile("EmailHandler", "SendEmailTo_AssignedToUser", e);
            }
        }

        private static Outlook.Application GetApplicationObject()
        {
            Outlook.Application application = null;
            if (Process.GetProcessesByName("OUTLOOK").Count() > 0)
            {
                application = Marshal.GetActiveObject("Outlook.Application") as Outlook.Application;
            }
            else
            {
                application = new Outlook.Application();
                Outlook.NameSpace nameSpace = application.GetNamespace("MAPI");
                nameSpace.Logon("", "", Missing.Value, Missing.Value);
                nameSpace = null;
            }

            return application;
        }
    }
}
