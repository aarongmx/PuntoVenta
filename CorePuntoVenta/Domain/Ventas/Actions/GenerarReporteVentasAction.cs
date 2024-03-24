using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Microsoft.EntityFrameworkCore;

namespace CorePuntoVenta.Domain.Ventas.Actions
{

    public class GenerarReporteVentasAction(ApplicationDbContext context)
    {
        public void Execute()
        {

            string dest = Path.GetFullPath(@"/punto_venta/" + DateTime.UtcNow.ToString("dd-MM-yyyy-HH-mm") + ".pdf").ToString();
            PdfDocument pdfDocument = new(new PdfWriter(new FileStream(dest, FileMode.Create, FileAccess.ReadWrite)));
            Document document = new(pdfDocument);

            document.Add(new Paragraph("Reporte de Ventas"));
            Table table = new Table(UnitValue.CreatePercentArray(6)).UseAllAvailableWidth();

            table.AddHeaderCell(new Paragraph("Orden").SetFontSize(12));
            table.AddHeaderCell(new Paragraph("Total").SetFontSize(12));
            table.AddHeaderCell(new Paragraph("Subtotal").SetFontSize(12));
            table.AddHeaderCell(new Paragraph("Iva").SetFontSize(12));
            table.AddHeaderCell(new Paragraph("Empleado").SetFontSize(12));
            table.AddHeaderCell(new Paragraph("Fecha Venta").SetFontSize(12));

            /*ventas.ForEach(venta => { 
                table.AddCell(new Paragraph($"{venta?.Orden?.Referencia}").SetFontSize(10));
                table.AddCell(new Paragraph($"${venta?.Total.ToString("N2")}").SetFontSize(10));
                table.AddCell(new Paragraph($"${venta?.Subtotal.ToString("N2")}").SetFontSize(10));
                table.AddCell(new Paragraph($"${venta?.Iva.ToString("N2")}").SetFontSize(10));
                table.AddCell(new Paragraph(venta?.Orden?.Empleado?.Nombre).SetFontSize(10));
                table.AddCell(new Paragraph($"{venta?.CreatedAt}").SetFontSize(10));
            });*/

            document.Add(table);
            document.Close();
        }
    }
}
