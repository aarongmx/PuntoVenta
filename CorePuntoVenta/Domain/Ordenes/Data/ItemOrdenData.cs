using CorePuntoVenta.Domain.Productos.Data;

namespace CorePuntoVenta.Domain.Ordenes.Data
{
    public class ItemOrdenData
    {
        public int? Id { get; set; }

        public double PrecioUnitario { get; set; }

        public double Total { get; set; }

        public double Kilos { get; set; }

        public int ProductoId { get; set; }

        public ProductoData? Producto { get; set; }

        public int OrdenId { get; set; }

        public OrdenData? Orden { get; set; }
    }
}
