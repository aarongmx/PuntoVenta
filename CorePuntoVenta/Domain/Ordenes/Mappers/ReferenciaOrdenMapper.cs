using CorePuntoVenta.Domain.Ordenes.Data;
using CorePuntoVenta.Domain.Ordenes.Models;
using Riok.Mapperly.Abstractions;

namespace CorePuntoVenta.Domain.Ordenes.Mappers
{
    [Mapper]
    public partial class ReferenciaOrdenMapper
    {
        public partial ReferenciaOrdenData ToDto(ReferenciaOrden entity);
        public partial ReferenciaOrden ToEntity(ReferenciaOrdenData dto);
    }
}
