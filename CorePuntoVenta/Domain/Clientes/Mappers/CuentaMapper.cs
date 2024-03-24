using CorePuntoVenta.Domain.Clientes.Data;
using CorePuntoVenta.Domain.Clientes.Models;
using Riok.Mapperly.Abstractions;

namespace CorePuntoVenta.Domain.Clientes.Mappers
{
    [Mapper]
    public partial class CuentaMapper
    {
        public partial Cuenta ToEntity(CuentaData cuentaData);

        public partial CuentaData ToDto(Cuenta cuenta);
    }
}
