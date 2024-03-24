using CorePuntoVenta.Domain.Administracion.Data;
using CorePuntoVenta.Domain.Administracion.Mappers;
using CorePuntoVenta.Domain.Administracion.Models;
using System.ComponentModel.DataAnnotations;

namespace CorePuntoVenta.Domain.Administracion.Actions
{
    public class CrearUsuarioAction(ApplicationDbContext context)
    {
        private readonly UsuarioMapper _mapper = new();
        private const int WORK_FACTOR = 14;

        public Usuario? Execute(UsuarioData usuarioData)
        {
            ValidationContext validationContext = new(usuarioData, null, null);
            List<ValidationResult> errors = [];
            bool isValid = Validator.TryValidateObject(usuarioData, validationContext, errors, true);

            if (errors.Count > 0) return null;

            Usuario usuario = _mapper.ToEntity(usuarioData);
            usuario.Password = BCrypt.Net.BCrypt.HashPassword(usuarioData.Password, workFactor: WORK_FACTOR);

            context.Add(usuario);
            context.SaveChanges();

            return usuario;
        }
    }
}
