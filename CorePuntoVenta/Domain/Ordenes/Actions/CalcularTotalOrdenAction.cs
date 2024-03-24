using CorePuntoVenta.Domain.Ordenes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePuntoVenta.Domain.Ordenes.Actions
{
    public class CalcularTotalOrdenAction
    {
        public double Execute(ICollection<ItemOrdenData> items)
        {
            return items.Sum(x => x.PrecioUnitario * x.Kilos);
        }
    }
}
