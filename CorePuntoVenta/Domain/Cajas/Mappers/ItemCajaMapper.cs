using CorePuntoVenta.Domain.Cajas.Data;
using CorePuntoVenta.Domain.Cajas.Models;
using Riok.Mapperly.Abstractions;

namespace CorePuntoVenta.Domain.Cajas.Mappers
{
    [Mapper]
    public partial class ItemCajaMapper
    {
        public partial ItemCaja ToEntity(ItemCajaData itemCajaData);

        public partial ItemCajaData ToDto(ItemCaja itemCaja);
    }
}
