using CorePuntoVenta.Domain.Camionetas.Data;
using CorePuntoVenta.Domain.Camionetas.Models;
using Riok.Mapperly.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePuntoVenta.Domain.Camionetas.Mappers
{
    [Mapper]
    public partial class CamionetaMapper
    {
        public partial Camioneta ToEntity(CamionetaData camionetaData);

        public partial CamionetaData ToDto(Camioneta camioneta);
    }
}
