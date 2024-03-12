using CorePuntoVenta.Domain.Cajas.Enums;
using CorePuntoVenta.Domain.Empleados.Data;
using CorePuntoVenta.Domain.Support.Data;

namespace CorePuntoVenta.Domain.Cajas.Data
{
    public class ItemCajaData : AuditableData
    {
        public int? Id { get; set; }

        public MovimientoCaja Movimiento { get; set; }

        public double Monto { get; set; }

        public string? Motivo { get; set; }

        public int EmpleadoId { get; set; }

        public EmpleadoData? Empleado { get; set; }

        public int CajaId { get; set; }

        public CajaData? Caja { get; set; }
    }
}
