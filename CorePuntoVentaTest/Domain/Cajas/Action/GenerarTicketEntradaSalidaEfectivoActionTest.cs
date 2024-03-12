using CorePuntoVenta.Domain.Cajas.Actions;
using CorePuntoVenta.Domain.Cajas.Data;
using CorePuntoVenta.Domain.Cajas.Enums;
using CorePuntoVenta.Domain.Direcciones.Data;
using CorePuntoVenta.Domain.Empleados.Data;
using CorePuntoVenta.Domain.Sucursales.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePuntoVentaTest.Domain.Cajas.Action
{
    public class GenerarTicketEntradaSalidaEfectivoActionTest
    {
        [Test]
        public void Se_genera_ticket_correctamente()
        {
            ItemCajaData itemCajaData = new()
            {
                Id = 1,
                CajaId = 1,
                Caja = new CajaData { NumeroCaja = "100" },
                Empleado = new EmpleadoData
                {
                    Nombre = "Juan Carlos",
                    ApellidoMaterno = "Gonzalez",
                    ApellidoPaterno = "Velazquez",
                    SucursalId = 1,
                    Sucursal = new SucursalData
                    {
                        Id = 1,
                        Nombre = "Aztecas",
                        DireccionId = 1,
                        Direccion = new DireccionData
                        {
                            Id = 1,
                            Calle = "asas",
                        }
                    }
                },
                EmpleadoId = 1,
                Monto = 10.0,
                Movimiento = MovimientoCaja.INGRESO,
                CreatedAt = DateTime.UtcNow
            };
            (new GenerarTicketEntradaSalidaEfectivoAction()).Execute("POS-80C", itemCajaData);
        }
    }
}
