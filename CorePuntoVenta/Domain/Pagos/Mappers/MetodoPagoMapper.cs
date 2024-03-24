using CorePuntoVenta.Domain.Pagos.Data;
using CorePuntoVenta.Domain.Pagos.Models;
using Riok.Mapperly.Abstractions;

namespace CorePuntoVenta.Domain.Pagos.Mappers
{
    [Mapper]
    public partial class MetodoPagoMapper
    {
        public partial MetodoPago ToEntity(MetodoPagoData metodoPagoData);

        public partial MetodoPagoData ToDto(MetodoPago metodoPago);
    }
}
