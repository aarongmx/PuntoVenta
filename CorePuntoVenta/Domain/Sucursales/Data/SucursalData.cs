using CorePuntoVenta.Domain.Direcciones.Data;

namespace CorePuntoVenta.Domain.Sucursales.Data
{
    public class SucursalData
    {
        public int? Id { get; set; }

        public string Nombre { get; set; }

        public int DireccionId { get; set; }

        public DireccionData? Direccion { get; set; }
    }
}
