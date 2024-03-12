using CorePuntoVenta.Domain.Ordenes.Data;
using CorePuntoVenta.Domain.Ordenes.Mappers;

namespace CorePuntoVenta.Domain.Ordenes.Actions
{
    public class ActualizarReferenciaAction(ApplicationDbContext context)
    {
        public void Execute(ReferenciaOrdenData referenciaOrdenData)
        {
            var mapper = new ReferenciaOrdenMapper();
            var referencia = mapper.ToEntity(referenciaOrdenData);
            context.Add(referencia);
            context.SaveChanges();
        }
    }
}
