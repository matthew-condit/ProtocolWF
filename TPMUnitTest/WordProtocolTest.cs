using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toxikon.ProtocolManager.Models.Templates;
using Toxikon.ProtocolManager.Models;
using System.Diagnostics;

namespace TPMUnitTest
{
    [TestClass]
    public class WordProtocolTest
    {
        [TestMethod]
        public void WordProtocol_Create_Test()
        {
            bool result = true;

            try
            {
                ProtocolRequest request = new ProtocolRequest();
                SponsorContact contact = new SponsorContact();
                contact.SponsorName = "ABC";
                contact.Address = "123 Street";
                contact.City = "XYZ";
                contact.State = "Alpha";
                contact.ZipCode = "12345";
                string protocolNumber = "P15-1000-00A";
                request.SetContact(contact);

                string sourceFile = @"C:\Users\BMcCulley\Documents\TestResources\ProtocolsManager\
                                      ASTM-Hemolysis Complete.docx";
                string destinationFile = @"C:\Users\BMcCulley\Documents\TestResources\ProtocolsManager\Dest\
                                         ASTM-Hemolysis Complete.docx";

                WordProtocol protocol = new WordProtocol(request, protocolNumber);
                protocol.Create(sourceFile, destinationFile);
            }
            catch(Exception ex)
            {
                result = false;
                Debug.WriteLine(ex.ToString());
            }

            Assert.AreEqual<bool>(true, result);
        }
    }
}
