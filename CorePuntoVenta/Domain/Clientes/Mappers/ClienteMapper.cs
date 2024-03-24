using CorePuntoVenta.Domain.Clientes.Data;
using CorePuntoVenta.Domain.Clientes.Models;
using Riok.Mapperly.Abstractions;

namespace CorePuntoVenta.Domain.Clientes.Mappers
{
    [Mapper]
    public partial class ClienteMapper
    {
        public partial Cliente ToEntity(ClienteData clienteData);

        public partial ClienteData ToDto(Cliente cliente);
    }
}
