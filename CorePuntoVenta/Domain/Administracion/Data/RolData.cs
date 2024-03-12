using CorePuntoVenta.Domain.Support.Data;

namespace CorePuntoVenta.Domain.Administracion.Data
{
    public class RolData : AuditableData
    {
        public int? Id { get; set; }
        public string Nombre { get; set; }
    }
}
