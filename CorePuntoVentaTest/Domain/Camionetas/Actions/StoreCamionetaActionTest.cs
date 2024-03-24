using AutoFixture;
using CorePuntoVenta;
using CorePuntoVenta.Domain.Camionetas.Actions;
using CorePuntoVenta.Domain.Camionetas.Data;
using CorePuntoVenta.Domain.Camionetas.Models;
using EntityFrameworkCore.Testing.NSubstitute;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePuntoVentaTest.Domain.Camionetas.Actions
{
    public class StoreCamionetaActionTest
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
        [TestCase("Roja", "90818181")]
        [TestCase("Verde", "98181-90")]
        public void SeRegistraCorrectamenteUnaCamioneta(string nombre, string placas)
        {
            var camioneta = _fixture
                .Build<CamionetaData>()
                .With(c => c.Nombre, nombre)
                .With(c => c.Placas, placas)
                .Create();

            var data = new StoreCamionetaAction(_context).Execute(camioneta);

            Assert.Multiple(() =>
            {
                Assert.That(data.Id, Is.Not.Zero);
                Assert.That(data.Placas, Is.SameAs(placas));
            });
        }
    }
}
