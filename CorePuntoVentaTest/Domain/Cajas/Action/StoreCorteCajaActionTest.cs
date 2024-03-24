﻿using AutoFixture;
using CorePuntoVenta;
using CorePuntoVenta.Domain.Cajas.Actions;
using CorePuntoVenta.Domain.Cajas.Data;
using CorePuntoVenta.Domain.Cajas.Models;
using EntityFrameworkCore.Testing.Moq;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePuntoVentaTest.Domain.Cajas.Action
{
    public class StoreCorteCajaActionTest
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
        public void SeGuardaCorrectamenteElCorteDeCaja()
        {
            var itemsCaja = _fixture
                .CreateMany<ItemCaja>(8)
                .ToList();

            var caja = _fixture
                .Build<Caja>()
                .With(c => c.Items, itemsCaja)
                .Create();

            _context.Add(caja);
            _context.SaveChanges();

            caja.Items.ToList().ForEach(i =>
            {
                Console.WriteLine(i.CajaId);
            });

            Console.WriteLine(caja.Items.Count);
            

            /*caja.Items.ToList().ForEach((item) =>
            {
                Console.WriteLine(item.Monto);
            });*/

            // Caja caja = _context.Cajas.Include(c => c.Items).AsSplitQuery().First();

            /*CorteData corteData = new()
            {
                MontoCorte = 100,
                MontoEnCaja = 100,
                MontoInicial = 200,
            };*/
            // new StoreCorteCajaAction(_context).Execute(corteData);
        }
    }
}
