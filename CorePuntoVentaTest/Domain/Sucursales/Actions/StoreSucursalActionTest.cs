using AutoFixture;
using CorePuntoVenta;
using CorePuntoVenta.Domain.Sucursales.Actions;
using CorePuntoVenta.Domain.Sucursales.Data;
using CorePuntoVenta.Domain.Sucursales.Models;
using EntityFrameworkCore.Testing.Moq;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePuntoVentaTest.Domain.Sucursales.Actions
{
    public class StoreSucursalActionTest
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
        public void SePuedeGuardarUnaSucursal()
        {
            SucursalData data = new()
            {
                Nombre = "Axa",
                Direccion= new()
                {
                    CodigoPostal = "09660",
                    NumeroExterior = "12"
                }
            };
            Sucursal sucursal = new StoreSucursalAction(_context).Execute(data)!;
            
            Assert.That(sucursal, Is.Not.Null);
        }
    }
}
