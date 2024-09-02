// See https://aka.ms/new-console-template for more information


using Syncfusion.Pdf.Grid;
using Syncfusion.Pdf;
using Syncfusion.Drawing;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;

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

//Add rows to the grid
PdfGridRow row = pdfGrid.Rows.Add();

//Add values to the grid row.

//Create PdfTextElement and assign to the cell value
PdfTextElement textElement = new PdfTextElement("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new PdfStandardFont(PdfFontFamily.Helvetica, 12));
row.Cells[0].Value = textElement;

//Create PdfUriAnnotation and assign to the cell value
PdfUriAnnotation pdfUriAnnotation = new PdfUriAnnotation(new RectangleF(0, 0, 0, 0), "https://www.syncfusion.com");
pdfUriAnnotation.Text = "Syncfusion";
row.Cells[1].Value = pdfUriAnnotation;
row.Cells[1].Style.TextBrush = new PdfSolidBrush(new PdfColor(0, 0, 255));
//Set cell padding
row.Cells[1].Style.CellPadding = new PdfPaddings(10, 10, 10, 10);

//Create child grid and add to the cell value
PdfGrid childGrid = new PdfGrid();
childGrid.Columns.Add(2);
PdfGridRow childRow = childGrid.Rows.Add();
childRow.Cells[0].Value = "Child Grid";
childRow.Cells[1].Value = "Child Grid";
row.Cells[2].Value = childGrid;
row.Cells[2].Style.CellPadding = new PdfPaddings(10, 10, 10, 10);

//Draw the grid to the page of the PDF document
pdfGrid.Draw(page, new PointF(10, 10));

//Save the document
using (FileStream outputStream = new FileStream("adding-different-elements-in-grid-cell.pdf", FileMode.Create))
{
    document.Save(outputStream);
}

//Close the document
document.Close(true);
