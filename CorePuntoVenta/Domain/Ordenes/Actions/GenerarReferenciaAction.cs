using CorePuntoVenta.Domain.Ordenes.Mappers;
using CorePuntoVenta.Domain.Ordenes.Models;

namespace CorePuntoVenta.Domain.Ordenes.Actions
{
    public class GenerarReferenciaAction(ApplicationDbContext context)
    {
        public ReferenciaOrden Execute()
        {
            var mapper = new ReferenciaOrdenMapper();
            var referencia = context.RefereciasOrden.FirstOrDefault();

            if (referencia is null)
            {
                referencia = new ReferenciaOrden()
                {
                    Folio = 0,
                    Prefijo = "ORD",
                };

                context.Add(referencia);
                context.SaveChanges();
            }

            return referencia;
        }
    }
}
