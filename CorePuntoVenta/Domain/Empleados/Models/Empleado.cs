using CorePuntoVenta.Domain.Sucursales.Models;
using CorePuntoVenta.Domain.Support.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorePuntoVenta.Domain.Empleados.Models
{
    [Table("empleados")]
    public class Empleado : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; }

        [Column("apellido_paterno")]
        public string ApellidoPaterno { get; set; }

        [Column("apellido_materno")]
        public string? ApellidoMaterno { get; set; }

        [Column("sucursal_id")]
        public int SucursalId { get; set; }

        public Sucursal? Sucursal {  get; set; }
    }
}
