using AutoFixture;
using CorePuntoVenta;
using CorePuntoVenta.Domain.Clientes.Actions;
using CorePuntoVenta.Domain.Clientes.Data;
using CorePuntoVenta.Domain.Clientes.Models;
using CorePuntoVenta.Domain.Direcciones.Data;
using EntityFrameworkCore.Testing.Moq;
using Microsoft.EntityFrameworkCore;

namespace CorePuntoVentaTest.Domain.Clientes.Actions
{
    public class StoreClienteActionTest
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
        public void SePuedeCrearUnCliente()
        {
            var clienteData = new ClienteData { Rfc = "GOMA971007ND8", RazonSocial = "AARON", NombreComercial = "AARON" };
            var direccionData = new DireccionData { CodigoPostal = "123", NumeroExterior = "123" };
            Cliente? cli = new StoreClienteAction(_context).Execute(clienteData, direccionData);

            Assert.That(cli, Is.Not.Null);
        }
    }
}

