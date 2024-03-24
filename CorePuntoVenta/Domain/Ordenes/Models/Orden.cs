using CorePuntoVenta.Domain.Cajas.Models;
using CorePuntoVenta.Domain.Clientes.Models;
using CorePuntoVenta.Domain.Empleados.Models;
using CorePuntoVenta.Domain.Support.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorePuntoVenta.Domain.Ordenes.Models
{
    [Table("ordenes")]
    public class Orden : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("fecha")]
        public DateTime Fecha { get; set; }

        [Column("kilos")]
        public double Kilos {  get; set; }

        [Column("total")]
        public double Total { get; set; }

        [Column("subtotal")]
        public double Subtotal{ get; set; }

        [Column("impuestos")]
        public double Impuestos{ get; set; }

        public ICollection<ItemOrden> ItemsOrden { get; set; } = new List<ItemOrden>();

        [Column("cliente_id")]
        public int ClienteId { get; set; }

        public Cliente? Cliente { get; set; }

        [Column("empleado_id")]
        public int EmpleadoId { get; set; }

        public Empleado? Empleado { get; set; }

        [Column("referencia")]
        public string Referencia { get; set; }

        [Column("caja_id")]
        public int CajaId { get; set; }

        public Caja? Caja { get; set; }

        [Column("estatus_orden_id")]
        public int EstatusOrdenId { get; set; }

        public EstatusOrden? EstatusOrden { get; set; }
    }
}
