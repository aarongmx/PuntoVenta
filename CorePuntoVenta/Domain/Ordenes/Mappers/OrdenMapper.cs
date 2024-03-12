using CorePuntoVenta.Domain.Ordenes.Data;
using CorePuntoVenta.Domain.Ordenes.Models;
using Riok.Mapperly.Abstractions;

namespace CorePuntoVenta.Domain.Ordenes.Mappers
{
    [Mapper(UseReferenceHandling = true)]
    public partial class OrdenMapper
    {
        public partial OrdenData ToDto(Orden orden);

        public partial Orden ToEntity(OrdenData dto);
    }
}
