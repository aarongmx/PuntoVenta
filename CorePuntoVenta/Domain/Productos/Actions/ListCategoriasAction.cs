using CorePuntoVenta.Domain.Productos.Data;

namespace CorePuntoVenta.Domain.Productos.Actions
{
    public class ListCategoriasAction(ApplicationDbContext context)
    {
        public List<CategoriaData> Execute()
        {
            return
            [
                .. context
                .Categorias
                .Select(categoria => new CategoriaData()
                {
                    Id = categoria.Id,
                    Nombre = categoria.Nombre,
                })
,
            ];
        }
    }
}
