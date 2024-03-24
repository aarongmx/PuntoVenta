using CorePuntoVenta.Domain.Ordenes.Data;
using CorePuntoVenta.Domain.Support.Actions;
using ESC_POS_USB_NET.Printer;

namespace CorePuntoVenta.Domain.Ordenes.Actions
{
    public class GenerarTicketOrdenAction
    {
        private readonly GenerarCabeceraTicketAction _ticket;

        public GenerarTicketOrdenAction() => _ticket = new GenerarCabeceraTicketAction();

        public void Execute(string impresora, OrdenData ordenData)
        {
            Printer ticket = _ticket.Execute(impresora);

            ticket.NewLines(3);
            string referencia = $"Referencia: {ordenData.Referencia}";
            string fecha = $"Fecha: {ordenData.Fecha}";
            string kilos = "KILOS:".PadRight(33);
            kilos += ordenData.Kilos.ToString("N2").PadLeft(15);
            string ordenante = $"ORDENANTE: {ordenData?.Empleado?.Nombre} {ordenData?.Empleado?.ApellidoPaterno} {ordenData?.Empleado?.ApellidoMaterno}";

            ticket.Append(referencia);
            ticket.NewLine();
            ticket.Append(fecha);
            ticket.NewLine();
            ticket.Append(ordenante);
            ticket.NewLine();
            ticket.Separator();
            ticket.Append(kilos);
            ticket.NewLine();
            ticket.QrCode(referencia, ESC_POS_USB_NET.Enums.QrCodeSize.Size2);

            ticket.FullPaperCut();
            ticket.PrintDocument();
            ticket.OpenDrawer();
        }
    }
}
