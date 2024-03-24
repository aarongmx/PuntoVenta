using CorePuntoVenta.Domain.Productos.Data;
using CorePuntoVenta.Domain.Productos.Models;
using Riok.Mapperly.Abstractions;

namespace CorePuntoVenta.Domain.Productos.Mappers
{
    [Mapper(UseReferenceHandling = true)]
    public partial class CategoriaMapper
    {
        public partial Categoria ToEntity(CategoriaData categoriaData);

        public partial CategoriaData ToDto(Categoria categoria);
    }
}
