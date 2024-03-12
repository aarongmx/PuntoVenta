using ESC_POS_USB_NET.Printer;
using System.Drawing;
using System.Reflection;
using System.Text;

namespace CorePuntoVenta.Domain.Support.Actions
{
    public class GenerarCabeceraTicketAction
    {
        public Printer Execute(string impresora)
        {
            EncodingProvider ppp = CodePagesEncodingProvider.Instance;
            Encoding.RegisterProvider(ppp);
            Printer printer = new Printer(impresora, "UTF-8");

            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream? logo = assembly.GetManifestResourceStream("CorePuntoVenta.logo.png");

            Bitmap image = new Bitmap(Image.FromStream(logo, true));
            printer.Image(image);

            printer.AlignCenter();
            printer.BoldMode("ML GRUPO COMERCIAL");
            printer.AlignLeft();

            return printer;
        }
    }
}
