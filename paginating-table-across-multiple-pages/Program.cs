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

//Get the grid header and set the style
PdfGridCellStyle headerStyle = new PdfGridCellStyle();
headerStyle.BackgroundBrush = new PdfSolidBrush(new PdfColor(0, 0, 0));
headerStyle.TextBrush = PdfBrushes.White;

//Set the header style
grid.Headers[0].ApplyStyle(headerStyle);

//Set horizontal overflow
grid.Style.AllowHorizontalOverflow = true;

//Set the column overflow style
grid.Style.HorizontalOverflowType = PdfHorizontalOverflowType.NextPage;

//Create PdfGridLayoutFormat
PdfGridLayoutFormat format = new PdfGridLayoutFormat();

//Set the layout type as Paginate
format.Layout = PdfLayoutType.Paginate;

//Draw the grid
grid.Draw(page, PointF.Empty, format);

//Save the document
using (FileStream outputStream = new FileStream("paginate-table-across-multiple-pages.pdf", FileMode.Create))
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
                ShipCity = c.Element("ShipCity") != null ? c.Element("ShipCity").Value : "",
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
    public string ShipCity { get; set; }
    public string ShipCountry { get; set; }
}