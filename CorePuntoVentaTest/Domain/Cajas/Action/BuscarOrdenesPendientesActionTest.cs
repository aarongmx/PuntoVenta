using AutoFixture;
using CorePuntoVenta;
using CorePuntoVenta.Domain.Cajas.Actions;
using CorePuntoVenta.Domain.Ordenes.Models;
using EntityFrameworkCore.Testing.Moq;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CorePuntoVentaTest.Domain.Cajas.Action
{
    public class BuscarOrdenesPendientesActionTest
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
        public void Se_Muestran_Las_Ordenes_Pendientes_De_Pago()
        {
            var estatus = _fixture.Build<EstatusOrden>().With(x => x.Id, 1).Create();

            var ordenes = _fixture.Build<Orden>()
                .With(x => x.EstatusOrdenId, estatus.Id)
                .With(x => x.EstatusOrden, estatus)
                .CreateMany(8)
                .ToList();

            _context.AddRange(ordenes);
            _context.SaveChanges();

            ordenes.ForEach((i) => Debug.WriteLine(i.EstatusOrdenId));
            var x = new BuscarOrdenesPendientesAction(_context).Execute();
         
            Assert.That(x, Has.Count.EqualTo(8));
        }

        [Test]
        public void Se_Filtran_Correctamente_Las_Ordenes_Pendientes_De_Pago()
        {
            var estatus = _fixture.Build<EstatusOrden>().With(x => x.Id, 2).Create();
            var ordenes = _fixture.Build<Orden>()
                .With(x => x.EstatusOrdenId, 2)
                .With(x => x.EstatusOrden, estatus)
                .CreateMany(8)
                .ToList();

            _context.AddRange(ordenes);
            _context.SaveChanges();

            var x = new BuscarOrdenesPendientesAction(_context).Execute();

            Assert.That(x, Has.Count.EqualTo(0));
        }
    }
}
