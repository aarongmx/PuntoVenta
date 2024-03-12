using CorePuntoVenta.Domain.Support.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorePuntoVenta.Domain.Direcciones.Models
{
    [Table("direcciones")]
    public class Direccion : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("calle")]
        public string? Calle {  get; set; }

        [Column("numero_externo")]
        public string NumeroExterno { get; set; }

        [Column("numero_interior")]
        public string? NumeroInterior { get; set; }

        [Column("codigo_postal")]
        public string CodigoPostal { get; set; }

        [Column("colonia")]
        public string? Colonia { get; set; }

        [Column("estado")]
        public string? Estado { get; set; }
    }
}
