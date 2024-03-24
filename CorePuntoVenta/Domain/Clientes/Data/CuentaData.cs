namespace CorePuntoVenta.Domain.Clientes.Data
{
    public class CuentaData
    {
        public int? Id { get; set; }

        public float Saldo { get; set; }

        public float Adeudo { get; set; }

        public int ClienteId { get; set; }

        public ClienteData? Cliente { get; set; }
    }
}
