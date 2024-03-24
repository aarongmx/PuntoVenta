using CorePuntoVenta.Domain.Ordenes.Data;
using CorePuntoVenta.Domain.Ordenes.Mappers;
using CorePuntoVenta.Domain.Ordenes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePuntoVenta.Domain.Ordenes.Actions
{
    public class FindOrdenAction(ApplicationDbContext context)
    {
        private readonly OrdenMapper _mapper = new();

        public OrdenData? Execute(int id)
        {   
            Orden? orden = context.Ordenes.Find(id);
            return orden is not null ? _mapper.ToDto(orden) : null;
        }
    }
}
