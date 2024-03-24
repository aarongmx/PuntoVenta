using CorePuntoVenta.Domain.Pagos.Data;
using CorePuntoVenta.Domain.Pagos.Models;
using Riok.Mapperly.Abstractions;

namespace CorePuntoVenta.Domain.Pagos.Mappers
{
    [Mapper]
    public partial class PagoMapper
    {
        public partial Pago ToEntity(PagoData pagoData);

        public partial PagoData ToDto(Pago pago);
    }
}
