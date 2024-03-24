using CorePuntoVenta.Domain.Cajas.Models;
using CorePuntoVenta.Domain.Sucursales.Data;

namespace CorePuntoVenta.Domain.Cajas.Data
{
    public class CajaData
    {
        public int? Id { get; set; }

        public string NumeroCaja { get; set; }

        public double EfectivoDisponible { get; set; }

        public int SucursalId { get; set; }

        public SucursalData? Sucursal { get; set; }

        public ICollection<ItemCaja>? Items { get; set; }

        public string Ip { get; set; }

        public string Hostname { get; set; }
    }
}
