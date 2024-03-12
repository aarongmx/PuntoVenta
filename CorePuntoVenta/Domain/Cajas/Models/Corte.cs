using CorePuntoVenta.Domain.Empleados.Models;
using CorePuntoVenta.Domain.Support.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorePuntoVenta.Domain.Cajas.Models
{
    [Table("cortes")]
    public class Corte : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("fecha")]
        public DateTime Fecha { get; set; }

        [Column("monto_inicial")]
        public double MontoInicial { get; set; }

        [Column("monto_en_caja")]
        public double MontoEnCaja { get; set; }

        [Column("monto_corte")]
        public double MontoCorte { get; set; }

        [Column("caja_id")]
        public int CajaId { get; set; }

        public Caja? Caja { get; set; }

        [Column("empleado_id")]
        public int EmpleadoId { get; set; }

        public Empleado? Empleado { get; set; }
    }
}
