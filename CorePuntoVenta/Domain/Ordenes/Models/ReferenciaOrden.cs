using CorePuntoVenta.Domain.Support.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorePuntoVenta.Domain.Ordenes.Models
{
    [Table("referencias_orden")]
    public class ReferenciaOrden : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("folio")]
        public int Folio { get; set; }

        [Column("prefijo")]
        public string Prefijo { get; set; }
    }
}
