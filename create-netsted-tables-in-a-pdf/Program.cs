// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Grid;


//Register your Syncfusion license key
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Your license key");

//Create a PDF document
PdfDocument document = new PdfDocument();

//Add a page to the document
PdfPage page = document.Pages.Add();

//Create a PDF grid
PdfGrid parentGrid = new PdfGrid();

//Add columns to the grid
parentGrid.Columns.Add(2);

//Add rows to the table
PdfGridRow row = parentGrid.Rows.Add();
row.Cells[0].Value = "Employee ID";
row.Cells[1].Value = "E01";

row = parentGrid.Rows.Add();
row.Cells[0].Value = "Employee Name";
row.Cells[1].Value = "Simons Bistro";

row = parentGrid.Rows.Add();
row.Cells[0].Value = "Contact Details";

//Create a nested grid
PdfGrid nestedGrid = new PdfGrid();

//Add columns to the nested grid
nestedGrid.Columns.Add(2);

//Add rows to the nested grid
PdfGridRow nestedRow = nestedGrid.Rows.Add();
nestedRow.Cells[0].Value = "Phone";
nestedRow.Cells[1].Value = "1234567890";

nestedRow = nestedGrid.Rows.Add();
nestedRow.Cells[0].Value = "Email";
nestedRow.Cells[1].Value = "simonsbistro@outlook.com";

nestedRow = nestedGrid.Rows.Add();
nestedRow.Cells[0].Value = "Address";
nestedRow.Cells[1].Value = "Vinbaeltet 34, Denmark";

//Add the nested grid to the parent grid cell
row.Cells[1].Value = nestedGrid;

//Apply cell padding to the grid
parentGrid.Style.CellPadding = new PdfPaddings(5, 5, 5, 5);

//Draw the grid to the page
parentGrid.Draw(page, new PointF(10, 10));

//Save the document
using (FileStream outputStream = new FileStream("create-nested-tables-in-a-pdf.pdf", FileMode.Create))
{
    document.Save(outputStream);
}

//Close the document
document.Close(true);






