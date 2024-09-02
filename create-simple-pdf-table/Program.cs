// See https://aka.ms/new-console-template for more information


using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Grid;

//Register your license key
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Your license key");

//Create a PDF document
PdfDocument document = new PdfDocument();

//Add a page to the document
PdfPage page = document.Pages.Add();

//Create PdfGrid
PdfGrid pdfGrid = new PdfGrid();

//Add the columns to the grid
pdfGrid.Columns.Add(3);

//Add the grid header row to the grid
PdfGridRow[] headerRows = pdfGrid.Headers.Add(1);

//Get the header row
PdfGridRow headerRow = headerRows[0];

//Set the header row values
headerRow.Cells[0].Value = "Employee ID";
headerRow.Cells[1].Value = "Employee Name";
headerRow.Cells[2].Value = "Salary";

//Add rows to the grid
PdfGridRow row = pdfGrid.Rows.Add();

//Add values to the grid row.
row.Cells[0].Value = "E01";
row.Cells[1].Value = "Clay";
row.Cells[2].Value = "$10000";

//Add rows to the grid
row = pdfGrid.Rows.Add();

//Add values to the grid row.
row.Cells[0].Value = "E02";
row.Cells[1].Value = "John";
row.Cells[2].Value = "$15000";

//Draw the grid to the page of the PDF document
pdfGrid.Draw(page, new PointF(10, 10));

//Save the document
using(FileStream outputStream = new FileStream("create-simple-pdf-table.pdf", FileMode.Create))
{
    document.Save(outputStream);
}

//Close the document
document.Close(true);
