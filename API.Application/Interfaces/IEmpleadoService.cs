using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Domain.Entities;

namespace API.Application.Interfaces
{
    public interface IEmpleadoService
    {
        Task<Empleados> GetById(int id);
        Task<IEnumerable<Empleados>> GetEmpleados();
        Task AddEmpleado(Empleados empleado);
        Task<bool> UpdateEmpleado(Empleados empleado);
        Task<bool> DeleteEmpleado(int id);
    }
}
