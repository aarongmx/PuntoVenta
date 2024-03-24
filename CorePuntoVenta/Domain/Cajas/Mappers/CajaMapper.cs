using CorePuntoVenta.Domain.Cajas.Data;
using CorePuntoVenta.Domain.Cajas.Models;
using Riok.Mapperly.Abstractions;

namespace CorePuntoVenta.Domain.Cajas.Mappers
{
    [Mapper]
    public partial class CajaMapper
    {
        public partial Caja ToEntity(CajaData cajaData);

        public partial CajaData ToDto(Caja caja);
    }
}
