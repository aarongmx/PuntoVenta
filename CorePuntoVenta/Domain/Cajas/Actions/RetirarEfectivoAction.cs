using CorePuntoVenta.Domain.Cajas.Data;
using CorePuntoVenta.Domain.Cajas.Mappers;
using CorePuntoVenta.Domain.Cajas.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePuntoVenta.Domain.Cajas.Actions
{
    public class RetirarEfectivoAction(ApplicationDbContext context)
    {
        private readonly ItemCajaMapper _mapper = new();

        public ItemCaja? Execute(Caja caja, ItemCajaData itemCajaData)
        {
            if (caja.EfectivoDisponible == 0 || caja.EfectivoDisponible == 0.0)
            {
                throw new Exception("No hay efectivo para poder retirar!");
            }

            if (itemCajaData.Monto > caja.EfectivoDisponible)
            {
                throw new Exception("No hay efectivo suficiente para poder retirar!");
            }

            if(String.IsNullOrWhiteSpace(itemCajaData.Motivo))
            {
                throw new Exception("Ingrese el motivo del retiro!");
            }

            using var transaction = context.Database.BeginTransaction();
            ItemCaja? entity = null;

            try
            {
                entity = _mapper.ToEntity(itemCajaData);

                caja.EfectivoDisponible -= itemCajaData.Monto;

                context.Update(caja);
                context.Add(entity);
                context.SaveChanges();

                transaction.Commit();
                return entity;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Console.WriteLine(ex.ToString());
            }

            return entity;
        }
    }
}
