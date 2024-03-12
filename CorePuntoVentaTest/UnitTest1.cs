using AutoFixture;
using CorePuntoVenta;
using CorePuntoVenta.Domain.Administracion.Actions;
using CorePuntoVenta.Domain.Helpers;
using EntityFrameworkCore.Testing.Moq;
using ESC_POS_USB_NET.Enums;
using ESC_POS_USB_NET.Printer;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Net;
using System.Reflection;
using System.Text;

namespace CorePuntoVentaTest
{
    public class Tests
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
        public void Se_Puede_Registrar_Un_Nuevo_Usuario()
        {
            var usuario = (new CrearUsuarioAction(_context))
                .Execute(new CorePuntoVenta.Domain.Administracion.Data.UsuarioData { Correo = "aaron.gomez@live.com", Password = "12345678", RolId = 1, SucursalId = 1 });

            Assert.That(usuario, Is.Not.Null);
        }

        [Test]
        public void Se_Puede_Hacer_Login_Con_El_Nuevo_Usuario()
        {
            var usuario = (new CrearUsuarioAction(_context))
                .Execute(new CorePuntoVenta.Domain.Administracion.Data.UsuarioData { Correo = "aaron.gomez@live.com", Password = "12345678", RolId = 1, SucursalId = 1 });

            Assert.That(usuario, Is.Not.Null);
            
            Session? session = (new LoginAction(_context))
                .Execute(new CorePuntoVenta.Domain.Administracion.Data.UsuarioData { Correo = "aaron.gomez@live.com", Password = "12345678" });

            Assert.That(session, Is.Not.Null);
        }

        [Test]
        public void GetIp()
        {
            string hostName = string.Empty;
            hostName = Dns.GetHostName();
            IPHostEntry myIP = Dns.GetHostEntry(hostName);

            IPAddress? ipp = myIP.AddressList.ToList().Find(ip => ip.AddressFamily is System.Net.Sockets.AddressFamily.InterNetwork && ip.ToString().StartsWith("192.168"));

            Console.WriteLine(hostName);
            Console.WriteLine(ipp?.ToString());
        }
    }
}