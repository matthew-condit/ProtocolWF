using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordApp = Microsoft.Office.Interop.Word;

namespace Toxikon.ProtocolManager.Models.Templates
{
    public class WordProtocol
    {
        public string TemplateName { get; set; }
        public string SourceFile { get; set; }
        public string DestinationFile { get; set; }

        public enum Bookmarks { PN, SponsorName, Address, City, State, ZipCode, HeaderPN,
                                SponsorName2, Address2, City2, State2, ZipCode2 }

        private ProtocolRequest request;
        private string protocolNumber;

        public WordProtocol()
        {
            this.TemplateName = "";
            this.SourceFile = "";
            this.DestinationFile = "";
            request = new ProtocolRequest();
        }

        public WordProtocol(ProtocolRequest request, string protocolNumber) : base()
        {
            this.request = request;
            this.protocolNumber = protocolNumber;
        }

        public void Create(string sourceFile, string destinationFile)
        {
            if(File.Exists(sourceFile))
            {
                CreateProtocolFile(sourceFile, destinationFile);
                OpenFileInWord(destinationFile);
            }
            else
            {
                MessageBox.Show("File does not exist.");
            }
        }

        public void CreateProtocolFile(string sourceFile, string destinationFile)
        {
            try
            {
                File.Copy(sourceFile, destinationFile, true);
                Dictionary<string, string> keyValues = CreateDocumentPartKeyValues();
                Dictionary<string, string> headerKeyValues = CreateHeaderKeyValues();
                using(WordprocessingDocument document = WordprocessingDocument.Open(destinationFile, true))
                {
                    this.SearchAndReplaceDocumentPart(document, keyValues);
                    this.SearchAndReplaceHeader(document, headerKeyValues);
                }
            }
            catch(System.IO.FileFormatException ffEx)
            {
                MessageBox.Show("ERROR: " + ffEx.Message);
                ErrorHandler.CreateLogFile("WordProtocol", "Create", ffEx);
            }
            catch(System.IO.IOException ioEx)
            {
                MessageBox.Show("ERROR: " + ioEx.Message);
                ErrorHandler.CreateLogFile("WordProtocol", "Create", ioEx);
            }
            catch(System.Runtime.InteropServices.COMException comEx)
            {
                MessageBox.Show("ERROR: " +  comEx.Message);
                ErrorHandler.CreateLogFile("WordProtocol", "Create", comEx);
            }
        }

        public void OpenFileInWord(string filePath)
        {
            var wordApp = new WordApp.Application();
            wordApp.Documents.Open(filePath);
            wordApp.Visible = true;
        }

        protected Dictionary<string, string> CreateDocumentPartKeyValues()
        {
            Dictionary<string, string> keyValues = new Dictionary<string, string>();
            keyValues.Add(Bookmarks.PN.ToString("g"), this.protocolNumber);

            keyValues.Add(Bookmarks.SponsorName.ToString("g"), this.request.Contact.SponsorName);
            keyValues.Add(Bookmarks.Address.ToString("g"), this.request.Contact.Address);
            keyValues.Add(Bookmarks.City.ToString("g"), this.request.Contact.City);
            keyValues.Add(Bookmarks.State.ToString("g"), this.request.Contact.State);
            keyValues.Add(Bookmarks.ZipCode.ToString("g"), this.request.Contact.ZipCode);

            keyValues.Add(Bookmarks.SponsorName2.ToString("g"), this.request.Contact.SponsorName);
            keyValues.Add(Bookmarks.Address2.ToString("g"), this.request.Contact.Address);
            keyValues.Add(Bookmarks.City2.ToString("g"), this.request.Contact.City);
            keyValues.Add(Bookmarks.State2.ToString("g"), this.request.Contact.State);
            keyValues.Add(Bookmarks.ZipCode2.ToString("g"), this.request.Contact.ZipCode);
            
            return keyValues;
        }

        protected Dictionary<string, string> CreateHeaderKeyValues()
        {
            Dictionary<string, string> headerKeyValues = new Dictionary<string, string>();
            headerKeyValues.Add(Bookmarks.HeaderPN.ToString("g"), this.protocolNumber);
            return headerKeyValues;
        }

        protected void SearchAndReplaceHeader(WordprocessingDocument document,
                                            Dictionary<string, string> keyValues)
        {
            foreach (HeaderPart header in document.MainDocumentPart.HeaderParts)
            {
                foreach (KeyValuePair<string, string> item in keyValues)
                {
                    SearchAndReplaceBookmarkText(header.Header, item.Key, item.Value);
                }
                header.Header.Save();
            }
        }

        protected void SearchAndReplaceDocumentPart(WordprocessingDocument document,
                                                  Dictionary<string, string> keyValues)
        {
            var mainDocPart = document.MainDocumentPart;
            foreach (KeyValuePair<string, string> item in keyValues)
            {
                SearchAndReplaceBookmarkText(mainDocPart.Document.Body, item.Key, item.Value);
            }
            mainDocPart.Document.Save();
        }

        protected void SearchAndReplaceBookmarkText(OpenXmlElement element, string bookmarkName, string value)
        {
            var res = from mark in element.Descendants<BookmarkStart>()
                      where mark.Name == bookmarkName
                      select mark;
            var bookmark = res.SingleOrDefault();
            if (bookmark != null)
            {
                Run bookmarkText = bookmark.NextSibling<Run>();
                bookmarkText.GetFirstChild<Text>().Text = value;
            }
        }

        protected Paragraph CreateParagraph(string text)
        {
            Paragraph paragraph = new Paragraph();
            Run run = new Run(new Text(text));
            paragraph.Append(run);

            return paragraph;
        }

        protected ParagraphProperties CreateParagraphProperties()
        {
            ParagraphProperties paraProperties = new ParagraphProperties(
                                new ParagraphStyleId() { Val = "Heading1" });
            return paraProperties;
        }
    }
}
