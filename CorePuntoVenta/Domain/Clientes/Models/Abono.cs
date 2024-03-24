using CorePuntoVenta.Domain.Support.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorePuntoVenta.Domain.Clientes.Models
{
    [Table("abonos")]
    public class Abono : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("monto")]
        public float Monto { get; set; }

        [Column("fecha")]
        public DateTime Fecha { get; set; }
    }
}
