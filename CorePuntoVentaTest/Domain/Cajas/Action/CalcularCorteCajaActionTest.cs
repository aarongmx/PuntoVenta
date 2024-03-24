using AutoFixture;
using CorePuntoVenta;
using CorePuntoVenta.Domain.Cajas.Actions;
using CorePuntoVenta.Domain.Cajas.Models;
using EntityFrameworkCore.Testing.Moq;
using Microsoft.EntityFrameworkCore;

namespace CorePuntoVentaTest.Domain.Cajas.Action
{
    public class CalcularCorteCajaActionTest
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
        public void SeCalculaElCorteDeCaja()
        {
            var items = _fixture.Build<ItemCaja>()
                    .With(x => x.Monto, 10)
                    .CreateMany(80)
                    .ToList();

            var cajaTest = _fixture.Build<Caja>()
                .With(x => x.Items, items)
                .Create();

            _context.Set<Caja>().Add(cajaTest);
            _context.SaveChanges();

            Caja caja = _context.Cajas.Include(c => c.Items).AsSplitQuery().First();

            double total = CalcularCorteCajaAction.Execute(caja);

            Assert.That(total, Is.EqualTo(800.0));
        }
    }
}
