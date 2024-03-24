using CorePuntoVenta.Domain.Direcciones.Data;
using System.ComponentModel.DataAnnotations;

namespace CorePuntoVenta.Domain.Clientes.Data
{
    public class ClienteData
    {
        public int? Id { get; set; }

        public string Rfc { get; set; }

        public string RazonSocial { get; set; }

        public string? NombreComercial { get; set; }

        public int DireccionId { get; set; }

        public DireccionData? Direccion { get; set; }
    }
}
