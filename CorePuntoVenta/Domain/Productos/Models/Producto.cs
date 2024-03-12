using CorePuntoVenta.Domain.Support.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorePuntoVenta.Domain.Productos.Models
{
    [Table("productos")]
    public class Producto : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; }

        [Column("precio_unitario")]
        public double PrecioUnitario { get; set; }

        [Column("categoria_id")]
        public int CategoriaId { get; set; }
        
        public Categoria? Categoria { get; set;}
    }
}
