// See https://aka.ms/new-console-template for more information


using Syncfusion.Pdf.Grid;
using Syncfusion.Pdf;
using Syncfusion.Drawing;


//Register your Syncfusion license key
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Your license key");

//Create a PDF document
PdfDocument document = new PdfDocument();

//Add a page to the document
PdfPage page = document.Pages.Add();

//Create PdfGrid
PdfGrid pdfGrid = new PdfGrid();

//Create list of IEnumerable object
List<object> datasource = new List<object>();
//Add values to the list
datasource.Add(new { ID = "E01", Name = "Clay" , Salary = "$10000"});
datasource.Add(new { ID = "E02", Name = "Smith", Salary = "$12000" });
datasource.Add(new { ID = "E03", Name = "Garner", Salary = "$15000" });
datasource.Add(new { ID = "E04", Name = "Margaret", Salary = "$20000" });
datasource.Add(new { ID = "E05", Name = "Doran", Salary = "$18000"});

//Assign data source
pdfGrid.DataSource = datasource;

//Draw grid to the page
pdfGrid.Draw(page, new PointF(10, 10));

//Save the document
using (FileStream outputStream = new FileStream("create-table-from-data-source.pdf", FileMode.Create))
{
    document.Save(outputStream);
}

//Close the document
document.Close(true);