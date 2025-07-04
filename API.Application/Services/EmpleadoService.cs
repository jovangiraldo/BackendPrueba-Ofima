using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Application.Interfaces;
using API.Domain.Entities;
using API.Domain.Interfaces;

namespace API.Application.Services
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly IRepository<Empleados> _repository;

        public EmpleadoService(IRepository<Empleados> repository)
        {
            _repository = repository;
        }

        public async Task<Empleados> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<IEnumerable<Empleados>> GetEmpleados()
        {
            return await _repository.GetAll();
        }

        public async Task AddEmpleado(Empleados empleado)
        {
            await _repository.Add(empleado);
            await _repository.Save();
        }

        public async Task<bool> UpdateEmpleado(Empleados empleado)
        {
            var updated = await _repository.Update(empleado);
            if (updated)
            {
                await _repository.Save();
            }
            return updated;
        }

        public async Task<bool> DeleteEmpleado(int id)
        {
            try
            {
                var empleado = await _repository.GetById(id);

                if (empleado == null)
                {
                    return false;
                }

                await _repository.DeleteById(id);
                await _repository.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar pais: {ex.Message}");
                throw;
            }
        }

       
    }
}
