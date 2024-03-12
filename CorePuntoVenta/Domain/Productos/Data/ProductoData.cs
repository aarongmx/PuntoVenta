namespace CorePuntoVenta.Domain.Productos.Data
{
    public class ProductoData
    {
        public int? Id { get; set; }

        public string Nombre { get; set; }

        public double PrecioUnitario { get; set; }

        public int CategoriaId { get; set; }

        public CategoriaData? Categoria{ get; set; }

        public override string ToString()
        {
            return $"{Nombre} - {Categoria?.Nombre}";
        }
    }
}
