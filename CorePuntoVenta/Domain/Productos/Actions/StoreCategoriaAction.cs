using CorePuntoVenta.Domain.Productos.Data;
using CorePuntoVenta.Domain.Productos.Mappers;
using CorePuntoVenta.Domain.Productos.Models;

namespace CorePuntoVenta.Domain.Productos.Actions
{
    public class StoreCategoriaAction(ApplicationDbContext context)
    {
        public Categoria Execute(CategoriaData categoriaData)
        {
            var mapper = new CategoriaMapper();
            var categoria = mapper.ToEntity(categoriaData);
            context.Add(categoria);
            context.SaveChanges();
            return categoria;
        }
    }
}
