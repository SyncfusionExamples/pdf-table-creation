// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using Syncfusion.Pdf;
using System.Xml.Linq;
using Syncfusion.Drawing;

//Register your Syncfusion license key
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Your license key");


//Create a new PDF document
PdfDocument document = new PdfDocument();

//Add a page to the document
PdfPage page = document.Pages.Add();

//Create a PDF grid
PdfGrid grid = new PdfGrid();

//Get IEnumerable data source
IEnumerable<Orders> orders = GetOrdersData("Orders.xml");

//Set the data source
grid.DataSource = orders;

//Set built-in style settings
PdfGridBuiltinStyleSettings builtinStyleSettings = new PdfGridBuiltinStyleSettings();

//Set header row
builtinStyleSettings.ApplyStyleForHeaderRow = true;
//Set last row
builtinStyleSettings.ApplyStyleForLastRow = false;
//Set first column
builtinStyleSettings.ApplyStyleForFirstColumn = false;
//Set last column
builtinStyleSettings.ApplyStyleForLastColumn = false;
//Set odd row
builtinStyleSettings.ApplyStyleForBandedRows = false;
//Set even row
builtinStyleSettings.ApplyStyleForBandedColumns = true;

//Apply the built-in style settings to the PDF grid
grid.ApplyBuiltinStyle(PdfGridBuiltinStyle.GridTable4Accent5 ,builtinStyleSettings);

//Set cell padding
grid.Style.CellPadding.All = 2;

//Set layout properties
PdfGridLayoutFormat format = new PdfGridLayoutFormat();
//Set layout break type as FitElement
format.Break = PdfLayoutBreakType.FitElement;
//Set the layout type as Paginate
format.Layout = PdfLayoutType.Paginate;

//Draw the grid
grid.Draw(page, PointF.Empty, format);

//Save the document
using (FileStream outputStream = new FileStream("apply-built-in-style.pdf", FileMode.Create))
{
    document.Save(outputStream);
}

//Close the document
document.Close(true);



IEnumerable<Orders> GetOrdersData(string filePath)
{
    //Read the file
    FileStream xmlStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

    using (StreamReader reader = new StreamReader(xmlStream, true))
    {
        string data = reader.ReadToEnd();
        data = data.Replace(" xmlns=\"http://www.tempuri.org/DataSet1.xsd\"", "");
        return XElement.Parse(data)
            .Elements("Orders")
            .Select(c => new Orders
            {
                OrderID = c.Element("OrderID") != null ? c.Element("OrderID").Value : "",
                CustomerName = c.Element("CustomerID") != null ? c.Element("CustomerID").Value : "",
                ShipName = c.Element("ShipName") != null ? c.Element("ShipName").Value : "",
                ShipAddress = c.Element("ShipAddress") != null ? c.Element("ShipAddress").Value : "",               
                ShipPostalCode = c.Element("ShipPostalCode") != null ? c.Element("ShipPostalCode").Value : "",
                ShipCountry = c.Element("ShipCountry") != null ? c.Element("ShipCountry").Value : "",
            });
    }
}


public class Orders
{
    public string OrderID { get; set; }
    public string CustomerName { get; set; }
    public string ShipName { get; set; }
    public string ShipAddress { get; set; }
    public string ShipPostalCode { get; set; }
    public string ShipCountry { get; set; }
}