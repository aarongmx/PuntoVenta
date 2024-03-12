using CorePuntoVenta.Domain.Productos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CorePuntoVenta.Config
{
    public class CategoriaConfig : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasQueryFilter(c => c.DeletedAt == null);
        }
    }
}
