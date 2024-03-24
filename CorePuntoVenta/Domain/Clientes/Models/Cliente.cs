using CorePuntoVenta.Domain.Direcciones.Models;
using CorePuntoVenta.Domain.Support.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorePuntoVenta.Domain.Clientes.Models
{
    [Table("clientes")]
    public class Cliente : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("rfc")]
        public string Rfc {  get; set; }

        [Required]
        [Column("razon_social")]
        public string RazonSocial { get; set; }

        [Column("nombre_comercial")]
        public string? NombreComercial { get; set; }

        [Column("direccion_id")]
        public int DireccionId { get; set; }

        public Direccion? Direccion { get; set; }
    }
}
