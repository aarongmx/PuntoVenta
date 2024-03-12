using CorePuntoVenta.Domain.Productos.Data;
using CorePuntoVenta.Domain.Productos.Models;
using Riok.Mapperly.Abstractions;

namespace CorePuntoVenta.Domain.Productos.Mappers
{
    [Mapper(UseReferenceHandling = true)]
    public partial class ProductoMapper
    {
        public partial Producto ToEntity(ProductoData productoData);

        public partial ProductoData ToDto(Producto prodcuto);
    }
}
