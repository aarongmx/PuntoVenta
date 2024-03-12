using CorePuntoVenta.Domain.Support.Data;

namespace CorePuntoVenta.Domain.Ordenes.Data
{
    public class EstatusOrdenData : AuditableData
    {
        public int? Id { get; set; }
        public string Nombre { get; set; }

        public ICollection<OrdenData> Ordenes { get; } = [];
    }
}
