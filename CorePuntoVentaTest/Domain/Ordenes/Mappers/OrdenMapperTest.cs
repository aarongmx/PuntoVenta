using CorePuntoVenta.Domain.Ordenes.Data;
using CorePuntoVenta.Domain.Ordenes.Mappers;
using CorePuntoVenta.Domain.Ordenes.Models;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePuntoVentaTest.Domain.Ordenes.Mappers
{
    public class OrdenMapperTest
    {
        [Test]
        public void SePuedeMapearLaOrden()
        {
            var orderMapper = new OrdenMapper();
            var itemOrderMapper = new ItemOrdenMapper();

            OrdenData data = new()
            {
                Fecha = DateTime.UtcNow,
                EmpleadoId = 1,
                Kilos = 1,
                Total = 1,
            };
            
            List<ItemOrdenData> list = new()
            {
                new(){
                    Kilos = 1,
                    Total = 1,
                    PrecioUnitario = 1,
                    ProductoId = 1,
                },
                new(){
                    Kilos = 1,
                    Total = 1,
                    PrecioUnitario = 1,
                    ProductoId = 1,
                },
            };
            data.ItemsOrden = list;

            var orden = orderMapper.ToEntity(data);

            Assert.That(data.EmpleadoId, Is.EqualTo(orden.EmpleadoId));
        }
    }
}
