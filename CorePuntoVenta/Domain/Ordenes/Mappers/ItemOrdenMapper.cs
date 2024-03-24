using CorePuntoVenta.Domain.Ordenes.Data;
using CorePuntoVenta.Domain.Ordenes.Models;
using Riok.Mapperly.Abstractions;

namespace CorePuntoVenta.Domain.Ordenes.Mappers
{
    [Mapper(UseReferenceHandling = true)]
    public partial class ItemOrdenMapper
    {
        public partial ItemOrdenData ToDto(ItemOrden itemOrden);

        public partial ItemOrden ToEntity(ItemOrdenData itemOrdenData);
    }
}
