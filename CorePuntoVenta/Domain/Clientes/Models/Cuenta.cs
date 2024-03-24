using CorePuntoVenta.Domain.Support.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorePuntoVenta.Domain.Clientes.Models
{
    [Table("cuentas")]
    public class Cuenta : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("saldo")]
        public float Saldo { get; set; }

        [Column("adeudo")]
        public float Adeudo { get; set; }

        [Column("cliente_id")]
        public int ClienteId { get; set; }

        public Cliente? Cliente { get; set; }
    }
}
