using CorePuntoVenta.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePuntoVentaTest.Domain.Helpers
{
    public class MailTest
    {
        [Test]
        public void SeMandaCorreoCorrectamente()
        {
            Mail mail = new();
            mail.Execute();
        }
    }
}
