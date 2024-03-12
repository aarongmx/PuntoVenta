using CorePuntoVenta.Domain.Camionetas.Data;
using CorePuntoVenta.Domain.Camionetas.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePuntoVenta.Domain.Camionetas.Actions
{
    public class StoreCamionetaAction(ApplicationDbContext context)
    {
        private readonly CamionetaMapper _mapper = new();

        public CamionetaData Execute(CamionetaData camionetaData)
        {
            var entity = _mapper.ToEntity(camionetaData);
            context.Add(entity);
            context.SaveChanges();
            return _mapper.ToDto(entity);
        }
    }
}
