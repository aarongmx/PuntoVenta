using CorePuntoVenta.Domain.Administracion.Models;
using CorePuntoVenta.Domain.Cajas.Models;
using CorePuntoVenta.Domain.Clientes.Models;
using CorePuntoVenta.Domain.Direcciones.Models;
using CorePuntoVenta.Domain.Empleados.Models;
using CorePuntoVenta.Domain.Ordenes.Models;
using CorePuntoVenta.Domain.Pagos.Models;
using CorePuntoVenta.Domain.Productos.Models;
using CorePuntoVenta.Domain.Sucursales.Models;
using Microsoft.EntityFrameworkCore;

namespace CorePuntoVenta.Seeds
{
    public static class Seeder
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<Direccion>().HasData(
                new Direccion()
                {
                    Id = 1,
                    Calle = "calle",
                    CodigoPostal = "09660",
                    Colonia = "Bugambilia",
                    NumeroExterno = "1",
                    NumeroInterior = "2",
                }
            );

            builder.Entity<Sucursal>().HasData(new Sucursal() { Id = 1, Nombre = "AZTECAS", DireccionId = 1 });

            builder.Entity<MetodoPago>().HasData(new MetodoPago() { Id = 1, Nombre = "EFECTIVO" }, new MetodoPago() { Id = 2, Nombre= "TARJETA DE CRÉDITO/DEBITO"}, new MetodoPago() { Id = 3, Nombre = "CHEQUE" });

            builder.Entity<Caja>().HasData(new Caja() { Id = 1, EfectivoDisponible = 0, Hostname = "caja", Ip = "192.168.0.2", NumeroCaja = "1", SucursalId = 1 });

            builder.Entity<Empleado>().HasData(new Empleado() { Id = 1, Nombre = "Rogelio", ApellidoPaterno = "Hernandez", ApellidoMaterno = "López", SucursalId = 1 });

            builder.Entity<Categoria>().HasData(new Categoria() { Id = 1, Nombre = "Pollo" }, new Categoria() { Id = 2, Nombre = "Marinado" });

            builder.Entity<Producto>().HasData(new Producto() { Id = 1, Nombre = "POLLO ADOBADO", CategoriaId = 1 });

            builder.Entity<EstatusOrden>().HasData(new EstatusOrden() { Id = 1, Nombre = "CREADA" }, new EstatusOrden { Id = 2, Nombre = "PENDIENTE" }, new EstatusOrden() { Id = 3, Nombre = "PAGADA" });

            builder.Entity<Cliente>().HasData(new Cliente() { Id = 1, NombreComercial = "AARON", Rfc = "GOMA971007BD8", RazonSocial = "AARON", DireccionId = 1 });

            builder.Entity<Rol>().HasData(new Rol() { Id = 1, Nombre = "ADMINISTRADOR" }, new Rol() { Id = 2, Nombre = "CAJA" }, new Rol() { Id = 3, Nombre = "ORDENES" });

            builder.Entity<Usuario>().HasData(new Usuario() { Id = 1, Nombre = "Admin", Correo = "admin@ml-grupo.com.mx", Password = $"$2a$12$yRELEkrsM7oesblMcmu60uR67uxaNQAhd3cMU7ZthsnQmRQH6EIYe", RolId = 1, SucursalId = 1 }, new Usuario() { Id = 2, Nombre = "Caja", Correo = "caja1@ml-grupo.com.mx", Password = $"$2a$12$yRELEkrsM7oesblMcmu60uR67uxaNQAhd3cMU7ZthsnQmRQH6EIYe", RolId = 2, SucursalId = 1}, new Usuario() { Id = 3, Nombre = "Ordenes", Correo = "ordenes1@ml-grupo.com.mx", Password = $"$2a$12$yRELEkrsM7oesblMcmu60uR67uxaNQAhd3cMU7ZthsnQmRQH6EIYe", RolId = 3, SucursalId = 1 });

        }
    }
}
