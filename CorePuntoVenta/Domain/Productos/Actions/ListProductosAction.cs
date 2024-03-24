using CorePuntoVenta.Domain.Productos.Data;
using CorePuntoVenta.Domain.Productos.Mappers;
using Microsoft.EntityFrameworkCore;

namespace CorePuntoVenta.Domain.Productos.Actions
{
    public class ListProductosAction(ApplicationDbContext context)
    {
        public List<ProductoData> Execute()
        {
            ProductoMapper mapper = new();
            return [.. context.Productos.Include(p => p.Categoria).Select(producto => mapper.ToDto(producto)).AsSplitQuery()];
        }

    }
}
