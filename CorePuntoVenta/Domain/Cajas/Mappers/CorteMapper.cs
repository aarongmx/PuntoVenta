using CorePuntoVenta.Domain.Cajas.Data;
using CorePuntoVenta.Domain.Cajas.Models;
using Riok.Mapperly.Abstractions;

namespace CorePuntoVenta.Domain.Cajas.Mappers
{
    [Mapper]
    public partial class CorteMapper
    {
        public partial Corte ToEntity(CorteData corteData);

        public partial CorteData ToDto(Corte corte);
    }
}
