using AutoFixture;
using CorePuntoVenta;
using CorePuntoVenta.Domain.Cajas.Actions;
using CorePuntoVenta.Domain.Cajas.Data;
using CorePuntoVenta.Domain.Cajas.Enums;
using CorePuntoVenta.Domain.Cajas.Models;
using EntityFrameworkCore.Testing.Moq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePuntoVentaTest.Domain.Cajas.Action
{
    public class AgregarEfectivoActionTest
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
        public void SePuedeAgregarEfectivoACaja()
        {
            Caja? caja = (new StoreCajaAction(_context)).Execute(new CajaData
            {
                SucursalId = 1,
                EfectivoDisponible = 0,
                NumeroCaja = Guid.NewGuid().ToString(),
            }) ?? throw new Exception("No existe la caja");

            ItemCaja? itemCaja = new AgregarEfectivoAction(_context).Execute(caja, new ItemCajaData { Movimiento = MovimientoCaja.INGRESO, Monto = 100, EmpleadoId = 1, Motivo = "Se ingresa cambio a la caja" });

            Assert.That(itemCaja, Is.Not.Null);
        }

        [Test]
        public void SeReflejaElMontoAgregadoACaja()
        {
            Caja? caja = (new StoreCajaAction(_context)).Execute(new CajaData
            {
                SucursalId = 1,
                EfectivoDisponible = 0,
                NumeroCaja = Guid.NewGuid().ToString(),
            }) ?? throw new Exception("No existe la caja");

            ItemCaja? itemCaja = new AgregarEfectivoAction(_context).Execute(caja, new ItemCajaData { Movimiento = MovimientoCaja.INGRESO, Monto = 100, EmpleadoId = 1, Motivo = "Se ingresa cambio a la caja" });

            Assert.That(caja.EfectivoDisponible, Is.EqualTo(100));
        }


    }
}
