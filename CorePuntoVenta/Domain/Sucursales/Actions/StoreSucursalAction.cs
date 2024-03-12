using CorePuntoVenta.Domain.Sucursales.Data;
using CorePuntoVenta.Domain.Sucursales.Models;

namespace CorePuntoVenta.Domain.Sucursales.Actions
{
    public class StoreSucursalAction(ApplicationDbContext context)
    {
        public Sucursal? Execute(SucursalData sucursalData)
        {
            Sucursal sucursal = new()
            {
                Nombre = sucursalData.Nombre,
                Direccion = new()
                {
                    CodigoPostal = sucursalData.Direccion!.CodigoPostal,
                    NumeroExterno = sucursalData.Direccion!.NumeroExterior,
                }
            };
            context.Add(sucursal);
            context.SaveChanges();
            return sucursal;
        }
    }
}
