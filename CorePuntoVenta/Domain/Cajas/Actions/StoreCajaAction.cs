using CorePuntoVenta.Domain.Cajas.Data;
using CorePuntoVenta.Domain.Cajas.Mappers;
using CorePuntoVenta.Domain.Cajas.Models;
using System.Diagnostics;
using System.Net;

namespace CorePuntoVenta.Domain.Cajas.Actions
{
    public class StoreCajaAction(ApplicationDbContext context)
    {
        private readonly CajaMapper _mapper = new();

        public Caja? Execute(CajaData cajaData)
        {
            string hostName = string.Empty;
            hostName = Dns.GetHostName();
            IPHostEntry ipHostEntry = Dns.GetHostEntry(hostName);

            IPAddress? ip = ipHostEntry.AddressList.ToList().Find(ip => ip.AddressFamily is System.Net.Sockets.AddressFamily.InterNetwork && ip.ToString().StartsWith("192.168"));

            cajaData.Ip = ip.ToString();
            cajaData.Hostname = hostName;

            Caja caja = _mapper.ToEntity(cajaData);
            context.Add(caja);
            context.SaveChanges();
            return caja;
        }
    }
}
