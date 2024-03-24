using CorePuntoVenta.Domain.Empleados.Data;
using CorePuntoVenta.Domain.Empleados.Models;
using Riok.Mapperly.Abstractions;

namespace CorePuntoVenta.Domain.Empleados.Mappers
{
    [Mapper]
    public partial class EmpleadoMapper
    {
        public partial Empleado ToEntity(EmpleadoData empleadoData);

        public partial EmpleadoData ToDto(Empleado empleado);
    }
}
