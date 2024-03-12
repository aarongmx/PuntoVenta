using CorePuntoVenta.Domain.Sucursales.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorePuntoVenta.Domain.Administracion.Models
{
    [Table("usuarios")]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("nombre")]
        public string? Nombre { get; set; }

        [Column("correo")]
        public string Correo { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("token")]
        public string? Token { get; set; }

        [Column("rol_id")]
        public int RolId { get; set; }

        public Rol? Rol { get; set; }

        [Column("sucursal_id")]
        public int SucursalId { get; set; }

        public Sucursal? Sucursal { get; set; }
    }
}
