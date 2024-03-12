using System.ComponentModel.DataAnnotations.Schema;

namespace CorePuntoVenta.Domain.Support.Models
{
    public class Auditable
    {
        [Column("created_at")]
        public DateTime? CreatedAt { get; set; } = null;

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; } = null;

        [Column("deleted_at")]
        public DateTime? DeletedAt { get; set; } = null;
    }
}
