using CorePuntoVenta.Domain.Direcciones.Data;
using CorePuntoVenta.Domain.Direcciones.Models;
using Riok.Mapperly.Abstractions;

namespace CorePuntoVenta.Domain.Direcciones.Mappers
{
    [Mapper]
    public partial class DireccionMapper
    {
        public partial Direccion ToEntity(DireccionData direccionData);

        public partial DireccionData ToDto(Direccion direccion);
    }
}
