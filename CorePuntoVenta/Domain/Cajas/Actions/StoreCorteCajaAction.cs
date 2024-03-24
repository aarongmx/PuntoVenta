using CorePuntoVenta.Domain.Cajas.Data;
using CorePuntoVenta.Domain.Cajas.Mappers;
using CorePuntoVenta.Domain.Cajas.Models;

namespace CorePuntoVenta.Domain.Cajas.Actions
{
    public class StoreCorteCajaAction(ApplicationDbContext context)
    {
        private readonly CorteMapper _mapper = new();

        public void Execute(Caja caja, CorteData corteData)
        {
            Corte corte = _mapper.ToEntity(corteData);


            if (caja is null)
            {
                throw new Exception("Caja no disponible, intentelo más tarde!");
            }

            corte.MontoCorte = caja.EfectivoDisponible;

            context.Add(corte);
            context.SaveChangesAsync();
        }
    }
}
