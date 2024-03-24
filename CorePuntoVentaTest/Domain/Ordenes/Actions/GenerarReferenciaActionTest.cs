using AutoFixture;
using CorePuntoVenta;
using CorePuntoVenta.Domain.Ordenes.Actions;
using EntityFrameworkCore.Testing.Moq;
using Microsoft.EntityFrameworkCore;

namespace CorePuntoVentaTest.Domain.Ordenes.Actions
{
    public class GenerarReferenciaActionTest
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
        public void SeGeneraElFolio()
        {
            var referencia = (new GenerarReferenciaAction(_context)).Execute();

            Assert.That(referencia, Is.Not.Null);
        }
    }
}
