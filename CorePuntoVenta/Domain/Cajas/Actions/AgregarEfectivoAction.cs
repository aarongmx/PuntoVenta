using CorePuntoVenta.Domain.Cajas.Data;
using CorePuntoVenta.Domain.Cajas.Enums;
using CorePuntoVenta.Domain.Cajas.Mappers;
using CorePuntoVenta.Domain.Cajas.Models;

namespace CorePuntoVenta.Domain.Cajas.Actions
{
    public class AgregarEfectivoAction(ApplicationDbContext context)
    {
        public ItemCajaMapper _mapper = new();

        public ItemCaja? Execute(Caja caja, ItemCajaData itemCajaData)
        {
            using var transaction = context.Database.BeginTransaction();
            try
            {
                ItemCaja? itemCaja = null; 
                caja.EfectivoDisponible += itemCajaData.Monto;

                itemCaja = _mapper.ToEntity(itemCajaData);

                context.Update(caja);
                context.Add(itemCaja);
                context.SaveChanges();
                transaction.Commit();

                return itemCaja;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
    }
}
