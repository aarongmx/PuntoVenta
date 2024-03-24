using CorePuntoVenta.Domain.Empleados.Data;

namespace CorePuntoVenta.Domain.Cajas.Data
{
    public class CorteData
    {
        public int? Id {  get; set; }
        public DateTime Fecha { get; set; }

        public double MontoInicial { get; set; }

        public double MontoEnCaja { get; set; }

        public double MontoCorte { get; set; }

        public int CajaId { get; set; }

        public CajaData? Caja { get; set; }

        public int EmpleadoId { get; set; }

        public EmpleadoData? Empleado { get; set; }
    }
}
