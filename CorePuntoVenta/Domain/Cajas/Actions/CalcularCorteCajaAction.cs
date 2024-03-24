using CorePuntoVenta.Domain.Cajas.Models;

namespace CorePuntoVenta.Domain.Cajas.Actions
{
    public class CalcularCorteCajaAction
    {
        public static double Execute(Caja caja) => caja.Items.Sum(item => item.Monto);
    }
}
