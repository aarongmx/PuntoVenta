using CorePuntoVenta.Domain.Administracion.Models;
using CorePuntoVenta.Domain.Cajas.Models;
using CorePuntoVenta.Domain.Camionetas.Models;
using CorePuntoVenta.Domain.Clientes.Models;
using CorePuntoVenta.Domain.Direcciones.Models;
using CorePuntoVenta.Domain.Empleados.Models;
using CorePuntoVenta.Domain.Ordenes.Models;
using CorePuntoVenta.Domain.Pagos.Models;
using CorePuntoVenta.Domain.Productos.Models;
using CorePuntoVenta.Domain.Sucursales.Models;
using CorePuntoVenta.Domain.Support.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Npgsql;
using System.Reflection;

namespace CorePuntoVenta
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Rol> Roles { get; set; }
        public virtual DbSet<Caja> Cajas { get; set; }
        public virtual DbSet<Corte> Cortes { get; set; }
        public virtual DbSet<ItemCaja> ItemsCaja { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Cuenta> Cuentas { get; set; }
        public virtual DbSet<Abono> Abonos { get; set; }
        public virtual DbSet<Empleado> Empleados { get; set; }
        public virtual DbSet<ReferenciaOrden> RefereciasOrden { get; set; }
        public virtual DbSet<Orden> Ordenes { get; set; }
        public virtual DbSet<ItemOrden> ItemsOrden { get; set; }
        public virtual DbSet<Pago> Pagos { get; set; }
        public virtual DbSet<MetodoPago> MetodosPago { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Sucursal> Sucursales { get; set; }
        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Direccion> Direcciones { get; set; }
        public virtual DbSet<Camioneta> Camionetas { get; set; }

        public ApplicationDbContext() : base()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = "Server=127.0.0.1;Port=5432;User ID=db_user;Password=s3cret;Database=punto";
            NpgsqlDataSourceBuilder dataSourceBuilder = new(connection);

            dataSourceBuilder.UseNodaTime();

            var dataSource = dataSourceBuilder.Build();

            optionsBuilder
                .UseNpgsql(dataSource)
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            Seeds.Seeder.Seed(modelBuilder);
        }

        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is Auditable && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((Auditable)entityEntry.Entity).UpdatedAt = DateTime.UtcNow;

                if (entityEntry.State == EntityState.Added)
                {
                    ((Auditable)entityEntry.Entity).CreatedAt = DateTime.UtcNow;
                }
            }

            return base.SaveChanges();
        }
    }
}
