using CorePuntoVenta.Domain.Ordenes.Data;
using CorePuntoVenta.Domain.Ordenes.Mappers;

namespace CorePuntoVenta.Domain.Cajas.Actions
{
    public class BuscarOrdenesPendientesAction(ApplicationDbContext context)
    {
        private readonly OrdenMapper _mapper = new();

        public List<OrdenData> Execute(string search = "")
        {
            return [
                ..context.Ordenes
                .Where(o => o.EstatusOrdenId == 1)
                //.Where(o => o.Referencia.Contains(search))
                .Select(o => _mapper.ToDto(o))
            ];
        }
    }
}
