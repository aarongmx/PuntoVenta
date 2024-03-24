using ESC_POS_USB_NET.Printer;
using System.Text;

namespace CorePuntoVenta.Domain.Ventas.Actions
{
    public class TicketingAction
    {
        private readonly Printer _printer;

        public TicketingAction() {
            EncodingProvider ppp = CodePagesEncodingProvider.Instance;
            Encoding.RegisterProvider(ppp);
            _printer = new Printer("POS-80", "UTF-16");
        }

        public void Execute()
        {
            //Bitmap logo = new(Image.FromFile(""));
            //_printer.Image(logo);
            _printer.Append("Ticket de compra");
            _printer.Separator();
            _printer.Append("Ticket de compra");
            _printer.Separator();
            _printer.NewLines(3);
            _printer.FullPaperCut();
            _printer.PrintDocument();
            _printer.OpenDrawer();
        }
    }
}
