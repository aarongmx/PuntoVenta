namespace CorePuntoVenta.Domain.Direcciones.Data
{
    public class DireccionData
    {
        public int? Id { get; set; }

        public string CodigoPostal { get; set; }

        public string NumeroExterior { get; set; }

        public string? NumeroInterior { get; set; }

        public string? Calle { get; set; }

        public string? Colonia { get; set; }

        public string? Estado { get; set; }
    }
}
