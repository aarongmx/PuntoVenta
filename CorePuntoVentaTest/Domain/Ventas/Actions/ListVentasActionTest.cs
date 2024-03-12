using AutoFixture;
using CorePuntoVenta;
using CorePuntoVenta.Domain.Ventas.Actions;
using EntityFrameworkCore.Testing.Moq;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePuntoVentaTest.Domain.Ventas.Actions
{
    public class ListVentasActionTest
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
        public void SeConsultanLasVentas()
        {
            /*var ventasTest = _fixture.CreateMany<Venta>().ToList();
            
            _context.AddRange(ventasTest);
            _context.SaveChanges();

            var ventas = (new ListVentasAction(_context)).Execute();

            Assert.That(ventas, Has.Count.EqualTo(1));*/
        }
    }
}
