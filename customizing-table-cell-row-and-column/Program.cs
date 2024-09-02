// See https://aka.ms/new-console-template for more information
using Syncfusion.Pdf.Grid;
using Syncfusion.Pdf;
using Syncfusion.Drawing;
using Syncfusion.Pdf.Graphics;

//Register your Syncfusion license key
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Your license key");

//Create a new PDF document
PdfDocument document = new PdfDocument();

//Add a page to the document
PdfPage page = document.Pages.Add();

//Create a PDF grid
PdfGrid grid = new PdfGrid();

//Create list of IEnumerable object
List<object> datasource = new List<object>();
//Add values to the list
datasource.Add(new { ID = "E01", Name = "Clay", Salary = "$10000" });
datasource.Add(new { ID = "E02", Name = "Smith", Salary = "$12000" });
datasource.Add(new { ID = "E03", Name = "Garner", Salary = "$15000" });
datasource.Add(new { ID = "E04", Name = "Margaret", Salary = "$20000" });
datasource.Add(new { ID = "E05", Name = "Doran", Salary = "$18000" });

//Assign data source
grid.DataSource = datasource;

// ------------- Cell customization ----------------

//Create a PDF grid cell style
PdfGridCellStyle cellStyle = new PdfGridCellStyle()
{
    //Set the cell background color
    BackgroundBrush = PdfBrushes.LightBlue,
    //Set the cell text brush
    TextBrush = PdfBrushes.White,
    //Set the cell text pen
    TextPen = new PdfPen(Color.Black, 0.5f),
    //Set the cell font
    Font = new PdfStandardFont(PdfFontFamily.Helvetica, 12),
    //Set the cell text format
    StringFormat = new PdfStringFormat() { Alignment = PdfTextAlignment.Center, LineAlignment = PdfVerticalAlignment.Middle },
    //Set the cell borders
    Borders = new PdfBorders() { Top = PdfPens.Red, Bottom = PdfPens.Green, Left = PdfPens.Blue, Right = PdfPens.Yellow }
};

//Apply the cell style to the grid cell
grid.Rows[0].Cells[0].Style = cellStyle;

//Set the cell background image
grid.Rows[0].Cells[1].Style.BackgroundImage = new PdfBitmap(new FileStream(@"sample.png", FileMode.Open));

//Set the row and columns span
grid.Rows[0].Cells[1].RowSpan = 2;
grid.Rows[0].Cells[1].ColumnSpan = 2;

//Set cells spacing
grid.Style.CellSpacing = 5;

// ------------- Row customization ----------------

//Create an instance of PdfGridRowStyle.
PdfGridRowStyle rowStyle = new PdfGridRowStyle();
//Set the row background color
rowStyle.BackgroundBrush = PdfBrushes.LightYellow;
//Set the row font
rowStyle.Font = new PdfStandardFont(PdfFontFamily.Courier, 10);
//Set the row text format
rowStyle.TextBrush = PdfBrushes.Blue;
//Set the row text pen
rowStyle.TextPen = new PdfPen(Color.Green, 0.5f);

//Set the row style
grid.Rows[2].Style = rowStyle;

//Set the row height
grid.Rows[2].Height = 30;

// ------------- Column customization ----------------
//Get the grid column
PdfGridColumn column = grid.Columns[0];
//Set column width
column.Width = 150;

//Set the column format
column.Format = new PdfStringFormat() { Alignment = PdfTextAlignment.Left, LineAlignment = PdfVerticalAlignment.Top };

//Set the column format
grid.Columns[1].Format = new PdfStringFormat() { Alignment = PdfTextAlignment.Center, LineAlignment = PdfVerticalAlignment.Middle };

//Set the column format
grid.Columns[2].Format = new PdfStringFormat() { Alignment = PdfTextAlignment.Right, LineAlignment = PdfVerticalAlignment.Bottom };

// ------------- Table customization ----------------
//Create new PdfGridStyle
PdfGridStyle gridStyle = new PdfGridStyle();
//Set cell padding
gridStyle.CellPadding = new PdfPaddings(5, 5, 5, 5);
//Set cell spacing
gridStyle.CellSpacing = 5;
//Set background color
gridStyle.BackgroundBrush = PdfBrushes.LightGreen;
//Set font
gridStyle.Font = new PdfStandardFont(PdfFontFamily.TimesRoman, 8);
//Set the grid style
grid.Style = gridStyle;

//Draw the grid to the page
grid.Draw(page, new PointF(10, 10));

//Save the document
using (FileStream outputStream = new FileStream("customizing-table-cell-row-and-column.pdf", FileMode.Create))
{
    document.Save(outputStream);
}

//Close the document
document.Close(true);
