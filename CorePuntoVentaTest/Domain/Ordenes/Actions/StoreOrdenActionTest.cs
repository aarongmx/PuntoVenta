using AutoFixture;
using CorePuntoVenta;
using CorePuntoVenta.Domain.Ordenes.Actions;
using CorePuntoVenta.Domain.Ordenes.Data;
using CorePuntoVenta.Domain.Ordenes.Mappers;
using CorePuntoVenta.Domain.Ordenes.Models;
using EntityFrameworkCore.Testing.Moq;
using Microsoft.EntityFrameworkCore;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePuntoVentaTest.Domain.Ordenes.Actions
{
    public class StoreOrdenActionTest
    {
        private Fixture _fixture;
        private ApplicationDbContext _context;

        [SetUp]
        public void SetUp()
        {
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            _fixture = new Fixture();
            _context = Create.MockedDbContextFor<ApplicationDbContext>(dbContextOptions);
            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }

        [Test]
        public void SePuedeGuardarUnaOrden()
        {
            OrdenData data = new()
            {
                Fecha = DateTime.UtcNow,
                Kilos = 10,
                Total = 1_000,
                ClienteId = 1,
                EmpleadoId = 1,
                CajaId = 1,
            };
            Orden? orden = (new StoreOrdenAction(_context)).Execute(data);

            Assert.That(orden, Is.Not.Null);
        }

        [Test]
        public void SeGuardaUnaOrdenConLosDatosDelEmpleado()
        {
            OrdenData data = new()
            {
                Fecha = DateTime.UtcNow,
                Kilos = 10,
                Total = 1_000,
                EmpleadoId = 1,
                CajaId = 1,
                ClienteId = 1,
            };
            Orden? orden = (new StoreOrdenAction(_context)).Execute(data);

            Assert.That(orden, Is.Not.Null);
        }

        [Test]
        public void SeGuardaUnaOrdenConItems()
        {
            List<ItemOrdenData> items =
            [
                new ItemOrdenData
                {
                    PrecioUnitario = 1,
                    Kilos = 1,
                    ProductoId = 1,
                    Total = 1,
                }
            ];

            OrdenData data = new()
            {
                Fecha = DateTime.UtcNow,
                Kilos = 10,
                Total = 1_000,
                EmpleadoId = 1,
                CajaId = 1,
                ClienteId = 1,
                ItemsOrden = items,
            };

            Orden? orden = (new StoreOrdenAction(_context)).Execute(data);

            Assert.That(orden, Is.Not.Null);
        }
    }
}
