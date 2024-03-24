using CorePuntoVenta.Domain.Clientes.Data;
using CorePuntoVenta.Domain.Clientes.Models;
using CorePuntoVenta.Domain.Direcciones.Actions;
using CorePuntoVenta.Domain.Direcciones.Data;
using CorePuntoVenta.Domain.Direcciones.Models;

namespace CorePuntoVenta.Domain.Clientes.Actions
{
    public class StoreClienteAction(ApplicationDbContext context)
    {
        public Cliente? Execute(ClienteData clienteData, DireccionData direccionData)
        {
            using var transaction = context.Database.BeginTransaction();
            try
            {
                Direccion direccion = (new StoreDireccionAction(context)).Execute(direccionData);

                Cliente cliente = new()
                {
                    NombreComercial = clienteData.NombreComercial,
                    Rfc = clienteData.Rfc,
                    RazonSocial = clienteData.RazonSocial,
                    DireccionId = direccion.Id,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                };

                context.Add(cliente);
                context.SaveChanges();

                transaction.Commit();

                return cliente;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Console.WriteLine(ex.StackTrace);
                throw;
            }
        }
    }
}
