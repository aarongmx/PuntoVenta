using CorePuntoVenta.Domain.Administracion.Data;

namespace CorePuntoVenta.Domain.Helpers
{
    public class Session
    {
        private Session() { }

        private static Session? _instance;

        private static readonly object _lock = new object();

        public UsuarioData Value { get; private set; }
        public bool LoggedIn { get; private set; } = false;

        public static Session GetInstance(UsuarioData usuarioData)
        {
            if (_instance is not null)
            {
                return _instance;
            }

            lock (_lock)
            {
                _instance ??= new Session
                {
                    Value = usuarioData,
                    LoggedIn = true
                };
            }

            return _instance;
        }
    }
}
