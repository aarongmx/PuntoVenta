using CorePuntoVenta.Domain.Empleados.Data;
using CorePuntoVenta.Domain.Ordenes.Actions;
using CorePuntoVenta.Domain.Ordenes.Data;
using CorePuntoVenta.Domain.Productos.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePuntoVentaTest.Domain.Ordenes.Actions
{
    public class GenerarTicketOrdenActionTest
    {


        [Test]
        public void se_genera_ticket()
        {
            OrdenData ordenData = new()
            {
                Referencia = "ORD-001",
                Fecha = DateTime.Now,
                Total = 200,
                Kilos = 20,
                Empleado = new EmpleadoData()
                {
                    Nombre = "Aarón",
                    ApellidoPaterno = "Gómez",
                    ApellidoMaterno = "Méndez",
                },
                ItemsOrden = [
                    new ItemOrdenData()
                    {
                        Kilos = 10,
                        PrecioUnitario = 10,
                        Producto = new ProductoData()
                        {
                            Nombre = "Pollo"
                        }
                    },
                    new ItemOrdenData()
                    {
                        Kilos = 10,
                        PrecioUnitario = 10,
                        Producto = new ProductoData()
                        {
                            Nombre = "Pata"
                        }
                    },
                ]
            };

            new GenerarTicketOrdenAction().Execute("POS-80C", ordenData);
        }
    }
}