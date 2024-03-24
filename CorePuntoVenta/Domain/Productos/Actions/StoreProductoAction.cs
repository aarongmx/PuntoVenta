using CorePuntoVenta.Domain.Productos.Data;
using CorePuntoVenta.Domain.Productos.Models;

namespace CorePuntoVenta.Domain.Productos.Actions
{
    public class StoreProductoAction(ApplicationDbContext context)
    {
        public Producto Execute(ProductoData data)
        {
            Producto producto = new()
            {
                CategoriaId = data.CategoriaId,
                Nombre = data.Nombre,
                PrecioUnitario = data.PrecioUnitario,
            };
            context.Add(producto);
            context.SaveChanges();

            return producto;
        }
    }
}
