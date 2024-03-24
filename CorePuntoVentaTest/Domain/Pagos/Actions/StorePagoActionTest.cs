using AutoFixture;
using CorePuntoVenta;
using CorePuntoVenta.Domain.Pagos.Actions;
using CorePuntoVenta.Domain.Pagos.Data;
using EntityFrameworkCore.Testing.Moq;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePuntoVentaTest.Domain.Pagos.Actions
{
    public class StorePagoActionTest
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
        public void SePuedeGuardarUnPago()
        {
            PagoData pagoData = new()
            {
                ClienteId = 1,
                Fecha = DateTime.UtcNow,
                MetodoPagoId = 1,
                OrdenId = 1,
                MontoRecibido = 100,
                Cambio = 8,
            };
            var pago = (new StorePagoAction(_context)).Execute(pagoData);

            Assert.That(pago, Is.Not.Null);
        }
    }
}
