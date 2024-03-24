using CorePuntoVenta.Domain.Clientes.Data;
using System.ComponentModel.DataAnnotations;

namespace CorePuntoVentaTest.Domain.Clientes
{
    public class ClienteTest
    {
        [Test]
        public void SeValidaLaInformacionDelCliente()
        {
            ClienteData data = new() { 
                Rfc ="goma971007bd8",
                RazonSocial="jfalsdk"
            };
            ValidationContext validationContext = new(data, null, null);
            List<ValidationResult> errors = [];
            bool isValid = Validator.TryValidateObject(data, validationContext, errors, true);

            errors.ForEach(e => {
                Console.WriteLine(e.ErrorMessage);
            });

            Assert.That(isValid, Is.True);
        }
    }
}
