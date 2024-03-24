using AutoFixture;
using CorePuntoVenta;
using CorePuntoVenta.Domain.Cajas.Actions;
using CorePuntoVenta.Domain.Cajas.Data;
using CorePuntoVenta.Domain.Cajas.Models;
using EntityFrameworkCore.Testing.Moq;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePuntoVentaTest.Domain.Cajas.Action
{
    public class StoreCajaActionTest
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
        public void SePuedeCrearUnaCaja()
        {

            CajaData cajaData = _fixture.Create<CajaData>();

            Debug.WriteLine(cajaData.EfectivoDisponible);

            Caja? caja = (new StoreCajaAction(_context)).Execute(cajaData);

            Debug.WriteLine(caja.EfectivoDisponible);
            /*
            Assert.That(caja, Is.Not.Null);
            Assert.That(caja.EfectivoDisponible, Is.EqualTo(0));*/

        }
    }
}
