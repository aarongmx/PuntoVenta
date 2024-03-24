using CorePuntoVenta.Domain.Administracion.Data;
using CorePuntoVenta.Domain.Administracion.Models;
using Riok.Mapperly.Abstractions;

namespace CorePuntoVenta.Domain.Administracion.Mappers
{
    [Mapper]
    public partial class UsuarioMapper
    {
        public partial Usuario ToEntity(UsuarioData data);
        public partial UsuarioData ToDto(Usuario usuario);
    }
}
