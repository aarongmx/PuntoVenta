using CorePuntoVenta.Domain.Cajas.Enums;
using CorePuntoVenta.Domain.Empleados.Models;
using CorePuntoVenta.Domain.Support.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorePuntoVenta.Domain.Cajas.Models
{
    [Table("items_caja")]
    public class ItemCaja : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        public MovimientoCaja Movimiento { get; set; }

        [Column("monto")]
        public double Monto { get; set; }

        [Column("motivo")]
        public string? Motivo {  get; set; }

        [Column("empleado_id")]
        public int EmpleadoId { get; set; }

        public Empleado? Empleado { get; set; }

        [Column("caja_id")]
        public int CajaId { get; set; }

        public Caja? Caja { get; set; }
    }
}
