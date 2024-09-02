// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Grid;
using Syncfusion.Pdf;
using Syncfusion.Drawing;
using Syncfusion.Pdf.Graphics;

//Register your Syncfusion license key
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Your license key");

//Create a PDF document
PdfDocument document = new PdfDocument();

//Add a page to the document
PdfPage page = document.Pages.Add();

//Create the first PdfGrid
PdfGrid pdfGrid1 = new PdfGrid();

//Create list of IEnumerable object
List<object> datasource = new List<object>();
//Add values to the list
datasource.Add(new { ID = "E01", Name = "Clay", Salary = "$10000" });
datasource.Add(new { ID = "E02", Name = "Smith", Salary = "$12000" });
datasource.Add(new { ID = "E03", Name = "Garner", Salary = "$15000" });
datasource.Add(new { ID = "E04", Name = "Margaret", Salary = "$20000" });
datasource.Add(new { ID = "E05", Name = "Doran", Salary = "$18000" });

//Assign data source
pdfGrid1.DataSource = datasource;

//Create the header cell style
PdfGridCellStyle headerStyle = new PdfGridCellStyle()
{       
    Font = new PdfStandardFont(PdfFontFamily.Helvetica, 8, PdfFontStyle.Bold)
};

//Apply the header cell style
pdfGrid1.Headers[0].ApplyStyle(headerStyle);

//Draw grid to the page and get the result
PdfGridLayoutResult result = pdfGrid1.Draw(page, new PointF(10, 10));

//Create the second grid
PdfGrid pdfGrid2 = new PdfGrid();

//Create list of IEnumerable object
List<object> datasource2 = new List<object>();
//Add values to the list
datasource2.Add(new { ID = "E06", Name = "John", Salary = "$10000" });
datasource2.Add(new { ID = "E07", Name = "Peter", Salary = "$12000" });
datasource2.Add(new { ID = "E08", Name = "Smith", Salary = "$15000" });
datasource2.Add(new { ID = "E09", Name = "Margaret", Salary = "$20000" });
datasource2.Add(new { ID = "E10", Name = "Doran", Salary = "$18000" });

//Assign data source
pdfGrid2.DataSource = datasource2;

//Apply the header cell style
pdfGrid2.Headers[0].ApplyStyle(headerStyle);

//Draw grid to the page based on the result of the first grid
pdfGrid2.Draw(page, new PointF(10, result.Bounds.Bottom + 10));


//Save the document
using (FileStream outputStream = new FileStream("adding-multiple-tables-to-a-pdf.pdf", FileMode.Create))
{
    document.Save(outputStream);
}

//Close the document
document.Close(true);
