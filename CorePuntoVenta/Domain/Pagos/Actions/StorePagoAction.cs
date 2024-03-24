using CorePuntoVenta.Domain.Pagos.Data;
using CorePuntoVenta.Domain.Pagos.Mappers;
using CorePuntoVenta.Domain.Pagos.Models;

namespace CorePuntoVenta.Domain.Pagos.Actions
{
    public class StorePagoAction(ApplicationDbContext context)
    {
        private readonly PagoMapper _mapper = new();

        public Pago? Execute(PagoData pagoData)
        {
            Pago pago = _mapper.ToEntity(pagoData);
            context.Add(pago);
            context.SaveChanges();
            return pago;
        }
    }
}
