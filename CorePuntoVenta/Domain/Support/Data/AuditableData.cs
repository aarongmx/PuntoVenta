namespace CorePuntoVenta.Domain.Support.Data
{
    public class AuditableData
    {
        public DateTime? CreatedAt { get; set; } = null;

        public DateTime? UpdatedAt { get; set; } = null;

        public DateTime? DeletedAt { get; set; } = null;
    }
}
