using CorePuntoVenta.Domain.Sucursales.Data;
using CorePuntoVenta.Domain.Sucursales.Mappers;

namespace CorePuntoVenta.Domain.Sucursales.Actions
{
    public class ListSucursalesAction(ApplicationDbContext context)
    {
        private readonly SucursalMapper mapper = new();

        public List<SucursalData> Execute()
        {
            return [.. context.Sucursales.Select(sucursal => mapper.ToDto(sucursal))];
        }
    }
}
