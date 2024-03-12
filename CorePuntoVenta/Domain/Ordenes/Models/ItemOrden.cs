using CorePuntoVenta.Domain.Productos.Models;
using CorePuntoVenta.Domain.Support.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorePuntoVenta.Domain.Ordenes.Models
{
    [Table("items_orden")]
    public class ItemOrden : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("precio_unitario")]
        public double PrecioUnitario { get; set; }

        [Column("total")]
        public double Total { get; set; }

        [Column("kilos")]
        public double Kilos { get; set; }

        [Column("producto_id")]
        public int ProductoId { get; set; }

        public Producto? Producto { get; set; } = null!;

        [Column("orden_id")]
        public int? OrdenId { get; set; }
        
        public Orden? Orden { get; set; } = null!;
    }
}
