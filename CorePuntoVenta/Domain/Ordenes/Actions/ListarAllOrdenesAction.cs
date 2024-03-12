using CorePuntoVenta.Domain.Ordenes.Data;
using CorePuntoVenta.Domain.Ordenes.Mappers;
using CorePuntoVenta.Domain.Ordenes.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePuntoVenta.Domain.Ordenes.Actions
{
    public class ListarAllOrdenesAction(ApplicationDbContext context)
    {
        public List<Orden> Execute()
        {
            return [..
                context.Ordenes
                .Include(o => o.EstatusOrden)
                .Include(o => o.Cliente)
                .Include(o => o.ItemsOrden)
                .ThenInclude(o => o.Producto)
                .AsSplitQuery()
            ];
        }
    }
}
