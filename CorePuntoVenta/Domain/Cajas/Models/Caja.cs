using CorePuntoVenta.Domain.Sucursales.Models;
using CorePuntoVenta.Domain.Support.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorePuntoVenta.Domain.Cajas.Models
{
    [Table("cajas")]
    public class Caja : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("numero_caja")]
        public string NumeroCaja { get; set; }

        [Column("efectivo_disponible")]
        public double EfectivoDisponible { get; set; }

        [Column("sucursal_id")]
        public int SucursalId { get; set; }

        public Sucursal? Sucursal { get; set; }

        public ICollection<ItemCaja> Items { get; set; } = new List<ItemCaja>();

        [Column("ip")]
        public string Ip { get; set; }

        [Column("hosname")]
        public string Hostname { get; set; }
    }
}
