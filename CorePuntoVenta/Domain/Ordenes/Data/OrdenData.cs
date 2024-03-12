using CorePuntoVenta.Domain.Cajas.Data;
using CorePuntoVenta.Domain.Clientes.Models;
using CorePuntoVenta.Domain.Empleados.Data;
using CorePuntoVenta.Domain.Support.Data;

namespace CorePuntoVenta.Domain.Ordenes.Data
{
    public class OrdenData : AuditableData
    {
        public int? Id { get; set; }

        public DateTime Fecha { get; set; }

        public double Kilos { get; set; }

        public double Total { get; set; }

        public List<ItemOrdenData>? ItemsOrden { get; set; }

        public int ClienteId { get; set; }

        public Cliente? Cliente { get; set; }

        public int EmpleadoId { get; set; }

        public EmpleadoData? Empleado { get; set; }

        public string Referencia { get; set; }

        public int CajaId { get; set; }

        public CajaData? Caja { get; set; }

        public int EstatusOrdenId { get; set; }

        public EstatusOrdenData? EstatusOrden { get; set; }

        public override string ToString()
        {
            return Referencia + " " + Total;
        }
    }
}
