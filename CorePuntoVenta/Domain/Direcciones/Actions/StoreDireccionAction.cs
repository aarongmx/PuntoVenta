using CorePuntoVenta.Domain.Direcciones.Data;
using CorePuntoVenta.Domain.Direcciones.Models;

namespace CorePuntoVenta.Domain.Direcciones.Actions
{
    public class StoreDireccionAction(ApplicationDbContext context)
    {
        public Direccion Execute(DireccionData direccionData)
        {
            Direccion direccion = new()
            {
                CodigoPostal = direccionData.CodigoPostal,
                NumeroExterno = direccionData.NumeroExterior,
                NumeroInterior = direccionData.NumeroInterior,
                Calle = direccionData.Calle,
                Colonia = direccionData.Colonia,
                Estado = direccionData.Estado,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };
            context.Add(direccion);
            context.SaveChanges();

            return direccion;
        }
    }
}
