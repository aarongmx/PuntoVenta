using CorePuntoVenta.Domain.Direcciones.Models;
using CorePuntoVenta.Domain.Support.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorePuntoVenta.Domain.Sucursales.Models
{
    [Table("sucursales")]
    public class Sucursal : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; }

        [Column("direccion_id")]
        public int DireccionId { get; set; }

        public Direccion? Direccion { get; set; }
    }
}
