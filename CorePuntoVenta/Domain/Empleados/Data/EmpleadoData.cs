using CorePuntoVenta.Domain.Sucursales.Data;

namespace CorePuntoVenta.Domain.Empleados.Data
{
    public class EmpleadoData
    {
        public int? Id { get; set; }

        public string Nombre { get; set; }

        public string ApellidoPaterno { get; set; }

        public string? ApellidoMaterno { get; set; }

        public int SucursalId { get; set; }

        public SucursalData? Sucursal { get; set; }
    }
}
