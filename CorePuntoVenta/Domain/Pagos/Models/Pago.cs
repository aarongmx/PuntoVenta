using CorePuntoVenta.Domain.Cajas.Models;
using CorePuntoVenta.Domain.Clientes.Models;
using CorePuntoVenta.Domain.Empleados.Models;
using CorePuntoVenta.Domain.Ordenes.Models;
using CorePuntoVenta.Domain.Support.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorePuntoVenta.Domain.Pagos.Models
{
    [Table("pagos")]
    public class Pago : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("monto_recibido")]
        public double MontoRecibido { get; set; }

        [Column("cambio")]
        public double Cambio { get; set; }

        [Column("cliente_id")]
        public int ClienteId { get; set; }

        public Cliente? Cliente { get; set; }

        [Column("fecha")]
        public DateTime Fecha { get; set; }

        [Column("metodo_pago_id")]
        public int MetodoPagoId { get; set; }
        
        public MetodoPago? MetodoPago { get; set; }

        [Column("referencia")]
        public string? Referencia { get; set; }

        [Column("orden_id")]
        public int OrdenId{ get; set; }
        
        public Orden? Orden{ get; set; }

        [Column("caja_id")]
        public int CajaId { get; set; }

        public Caja? Caja { get; set; }

        [Column("empleado_id")]
        public int EmpleadoId { get; set; }

        public Empleado? Empleado { get; set; }
    }
}
