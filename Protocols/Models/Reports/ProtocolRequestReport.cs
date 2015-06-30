using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelWorksheet = Microsoft.Office.Interop.Excel.Worksheet;
using ExcelRange = Microsoft.Office.Interop.Excel.Range;
using Toxikon.ProtocolManager.Queries;
using System.Data;

namespace Toxikon.ProtocolManager.Models.Reports
{
    public class ProtocolRequestReport
    {
        private string filePath;
        private string fileName;
        private ProtocolRequest protocolRequest;

        public ProtocolRequestReport(ProtocolRequest request)
        {
            this.protocolRequest = request;
            this.filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                           "\\TPM-ToxikonProtocolManager\\";
            this.fileName = protocolRequest.Contact.SponsorName + '-' + protocolRequest.RequestedBy + '-' +
                            protocolRequest.RequestedDate.ToString("yyyyMMdd");
        }

        public void Create()
        {
            CreateReportDirectory();
            ExcelTemplate excelTemplate = new ExcelTemplate(filePath, fileName);
            excelTemplate.Open();
            excelTemplate.AddNewWorkbook();
            CreateProtocolRequestInfoSheet(excelTemplate);
            CreateProtocolTitleSheets(excelTemplate);

            excelTemplate.Save();
            excelTemplate.ShowExcelApp(true);
            excelTemplate.Close();
        }

        private void CreateReportDirectory()
        {
            if(!Directory.Exists(this.filePath))
            {
                Directory.CreateDirectory(filePath);
            }
        }

        private void CreateProtocolRequestInfoSheet(ExcelTemplate excelTemplate)
        {
            ExcelWorksheet worksheet = CreateNewWorksheet(excelTemplate, 0);
            int rowIndex = 1;
            InsertReportHeaderRow(worksheet, "A" + rowIndex, "A" + rowIndex, "Requested Date: ", true, false);
            InsertReportHeaderRow(worksheet, "B" + rowIndex, "G" + rowIndex, 
                                  this.protocolRequest.RequestedDate.ToString("MM/dd/yyyy"), false, false);
            rowIndex += 1;
            InsertReportHeaderRow(worksheet, "A" + rowIndex, "A" + rowIndex, "Requested By: ", true, false);
            InsertReportHeaderRow(worksheet, "B" + rowIndex, "G" + rowIndex,
                                  this.protocolRequest.RequestedBy, false, false);
            rowIndex += 1;
            InsertReportHeaderRow(worksheet, "A" + rowIndex, "A" + rowIndex, "Guidelines: ", true, false);
            InsertReportHeaderRow(worksheet, "B" + rowIndex, "G" + rowIndex,
                                  this.protocolRequest.Guidelines, false, false);
            rowIndex += 1;
            InsertReportHeaderRow(worksheet, "A" + rowIndex, "A" + rowIndex, "Compliance: ", true, false);
            InsertReportHeaderRow(worksheet, "B" + rowIndex, "G" + rowIndex,
                                  this.protocolRequest.Compliance, false, false);
            rowIndex += 1;
            InsertReportHeaderRow(worksheet, "A" + rowIndex, "A" + rowIndex, "Protocol Type: ", true, false);
            InsertReportHeaderRow(worksheet, "B" + rowIndex, "G" + rowIndex,
                                  this.protocolRequest.ProtocolType, false, false);
            rowIndex += 1;
            InsertReportHeaderRow(worksheet, "A" + rowIndex, "A" + rowIndex, "Due Date: ", true, false);
            InsertReportHeaderRow(worksheet, "B" + rowIndex, "G" + rowIndex,
                                  this.protocolRequest.DueDate.ToString("MM/dd/yyyy"), false, false);
            rowIndex += 1;
            InsertReportHeaderRow(worksheet, "A" + rowIndex, "A" + rowIndex, "VIA: ", true, false);
            InsertReportHeaderRow(worksheet, "B" + rowIndex, "G" + rowIndex,
                                  this.protocolRequest.SendVia, false, false);
            rowIndex += 1;
            InsertReportHeaderRow(worksheet, "A" + rowIndex, "A" + rowIndex, "Bill To: ", true, false);
            InsertReportHeaderRow(worksheet, "B" + rowIndex, "G" + rowIndex,
                                  this.protocolRequest.BillTo, false, false);
            rowIndex += 1;
            InsertReportHeaderRow(worksheet, "A" + rowIndex, "A" + rowIndex, "Comments: ", true, false);
            InsertReportHeaderRow(worksheet, "B" + rowIndex, "G" + rowIndex,
                                  this.protocolRequest.Comments, false, false);
            rowIndex += 1;
            InsertReportHeaderRow(worksheet, "A" + rowIndex, "A" + rowIndex, "Assigned To: ", true, false);
            InsertReportHeaderRow(worksheet, "B" + rowIndex, "G" + rowIndex,
                                  this.protocolRequest.AssignedTo, false, false);
            rowIndex += 2;
            InsertReportHeaderRow(worksheet, "A" + rowIndex, "A" + rowIndex, "Contact Name: ", true, false);
            InsertReportHeaderRow(worksheet, "B" + rowIndex, "G" + rowIndex,
                                  this.protocolRequest.Contact.ContactName, false, false);
            rowIndex += 1;
            InsertReportHeaderRow(worksheet, "A" + rowIndex, "A" + rowIndex, "Email: ", true, false);
            InsertReportHeaderRow(worksheet, "B" + rowIndex, "G" + rowIndex,
                                  this.protocolRequest.Contact.Email, false, false);
            rowIndex += 1;
            InsertReportHeaderRow(worksheet, "A" + rowIndex, "A" + rowIndex, "Sponsor: ", true, false);
            InsertReportHeaderRow(worksheet, "B" + rowIndex, "G" + rowIndex,
                                  this.protocolRequest.Contact.SponsorName, false, false);
            rowIndex += 1;
            InsertReportHeaderRow(worksheet, "A" + rowIndex, "A" + rowIndex, "Address: ", true, false);
            InsertReportHeaderRow(worksheet, "B" + rowIndex, "G" + rowIndex,
                                  this.protocolRequest.Contact.Address, false, false);
            rowIndex += 1;
            InsertReportHeaderRow(worksheet, "A" + rowIndex, "A" + rowIndex, "City: ", true, false);
            InsertReportHeaderRow(worksheet, "B" + rowIndex, "G" + rowIndex,
                                  this.protocolRequest.Contact.City, false, false);
            rowIndex += 1;
            InsertReportHeaderRow(worksheet, "A" + rowIndex, "A" + rowIndex, "State: ", true, false);
            InsertReportHeaderRow(worksheet, "B" + rowIndex, "G" + rowIndex,
                                  this.protocolRequest.Contact.State, false, false);
            rowIndex += 1;
            InsertReportHeaderRow(worksheet, "A" + rowIndex, "A" + rowIndex, "Zip Code: ", true, false);
            InsertReportHeaderRow(worksheet, "B" + rowIndex, "G" + rowIndex,
                                  this.protocolRequest.Contact.ZipCode, false, false);
            rowIndex += 1;
            InsertReportHeaderRow(worksheet, "A" + rowIndex, "A" + rowIndex, "Phone Number: ", true, false);
            InsertReportHeaderRow(worksheet, "B" + rowIndex, "G" + rowIndex,
                                  this.protocolRequest.Contact.PhoneNumber, false, false);
            rowIndex += 1;
            InsertReportHeaderRow(worksheet, "A" + rowIndex, "A" + rowIndex, "Fax: ", true, false);
            InsertReportHeaderRow(worksheet, "B" + rowIndex, "G" + rowIndex,
                                  this.protocolRequest.Contact.FaxNumber, false, false);
            rowIndex += 1;
            InsertReportHeaderRow(worksheet, "A" + rowIndex, "A" + rowIndex, "PO: ", true, false);
            InsertReportHeaderRow(worksheet, "B" + rowIndex, "G" + rowIndex,
                                  this.protocolRequest.Contact.PONumber, false, false);

            ExcelRange columnA = worksheet.get_Range("A1", "A21");
            columnA.EntireColumn.AutoFit();
        }

        private void CreateProtocolTitleSheets(ExcelTemplate excelTemplate)
        {
            for(int i = 0; i < this.protocolRequest.Titles.Count; i++)
            {
                ProtocolTitle title = this.protocolRequest.Titles[i];
                ExcelWorksheet worksheet = CreateNewWorksheet(excelTemplate, i + 1);
                InsertProtocolTitleSheetHeader(worksheet, title);
                InsertProtocolEventsDataTable(excelTemplate, worksheet, title);
                InsertProtocolCommentsDataTable(excelTemplate, worksheet, title);
            }
        }

        private void InsertProtocolTitleSheetHeader(ExcelWorksheet worksheet, ProtocolTitle title)
        {
            InsertReportHeaderRow(worksheet, "A1", "A1", "Title: ", true, false);
            InsertReportHeaderRow(worksheet, "B1", "G1", title.Description, false, false);
            InsertReportHeaderRow(worksheet, "A2", "A2", "Protocol Number: ", true, false);
            string protocolNumber = title.ProtocolNumber.Trim() == String.Empty ? "N/A" : title.ProtocolNumber;
            InsertReportHeaderRow(worksheet, "B2", "G2", protocolNumber, false, false);
        }

        private void InsertProtocolEventsDataTable(ExcelTemplate excelTemplate, ExcelWorksheet worksheet, 
                                                   ProtocolTitle title)
        {
            DataTable dataTable = QProtocolActivities.SelectItemsToDataTable(this.protocolRequest.ID,
                                      title.ID);
            ExcelDataTable eventsDataTable = CreateNewExcelDataTable("EventsTable" + title.ID, dataTable, 1, 4);
            InsertExcelDataTable(excelTemplate, worksheet, eventsDataTable);
            FormatExcelDataTable(worksheet, eventsDataTable);
        }

        private void InsertProtocolCommentsDataTable(ExcelTemplate excelTemplate, ExcelWorksheet worksheet, 
                                                     ProtocolTitle title)
        {
            DataTable dataTable = QProtocolComments.SelectItemsToDataTable(title);
            ExcelDataTable excelDataTable = CreateNewExcelDataTable("CommentsTable" + title.ID, dataTable, 5, 4);
            InsertExcelDataTable(excelTemplate, worksheet, excelDataTable);
            FormatExcelDataTable(worksheet, excelDataTable);
        }

        private ExcelWorksheet CreateNewWorksheet(ExcelTemplate excelTemplate, int sheetIndex)
        {
            string sheetName = sheetIndex == 0 ? "ProtocolRequest" : "Protocol " + sheetIndex;
            excelTemplate.AddNewWorksheet(sheetName);
            ExcelWorksheet worksheet = excelTemplate.GetWorksheet(sheetName);

            return worksheet;
        }

        private void InsertReportHeaderRow(ExcelWorksheet worksheet, string startCell, string endCell,
                                            string value, bool isBold, bool isCenter)
        {
            ExcelRange range = worksheet.get_Range(startCell + ":" + endCell);
            range.Merge();
            range.Value = value;
            range.Font.Bold = isBold;
            if (isCenter)
            {
                ExcelTemplate.SetTopAlignCenter(worksheet, startCell, endCell);
            }
            else
            {
                ExcelTemplate.SetTopAlignLeft(worksheet, startCell, endCell);
            }
        }

        private ExcelDataTable CreateNewExcelDataTable(string tableName, System.Data.DataTable dataTable, 
                                                       int startColumnIndex, int startRowIndex)
        {
            ExcelDataTable excelDataTable = new ExcelDataTable();
            excelDataTable.SetDataTable(dataTable);
            excelDataTable.StartColumnIndex = startColumnIndex;
            excelDataTable.StartRowIndex = startRowIndex;
            excelDataTable.SetTopLeft();
            excelDataTable.SetBottomRight();
            excelDataTable.TableName = tableName;
            excelDataTable.TableStyleName = "TableStyleLight11";

            return excelDataTable;
        }

        private void InsertExcelDataTable(ExcelTemplate excelTemplate, ExcelWorksheet worksheet,
                                          ExcelDataTable excelDataTable)
        {
            excelTemplate.InsertDataTable(worksheet, excelDataTable);
            excelTemplate.SetDataTableColumnWidth(worksheet, excelDataTable, 13);
        }

        private void FormatExcelDataTable(ExcelWorksheet worksheet, ExcelDataTable excelDataTable)
        {
            //ExcelTemplate.SetWrapText(worksheet, excelDataTable.TopLeft, excelDataTable.BottomRight);
            ExcelTemplate.SetTopAlignLeft(worksheet, excelDataTable.TopLeft, excelDataTable.BottomRight);
            ExcelTemplate.SetDataTableColumnAutoFit(worksheet, excelDataTable);
        }
    }
}
