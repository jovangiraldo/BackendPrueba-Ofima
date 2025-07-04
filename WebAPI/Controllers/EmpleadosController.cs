using System.Security.Principal;
using API.Application.DTOs;
using API.Application.Interfaces;
using API.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly IEmpleadoService _service;
        public EmpleadosController(IEmpleadoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetAccounts()
        {
            var result = await _service.GetEmpleados();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetEmpleadoById(int id)
        {
            var empleado = await _service.GetById(id);
            if (empleado == null)
            {
                return NotFound(new { message = "Empleado no encontrado" });
            }
            return Ok(empleado);
        }

        [HttpPost]
        public async Task<ActionResult> CreateEmpleado([FromBody] EmpleadoDTO empleadoDTO)
        {
            if (empleadoDTO == null)
            {
                return BadRequest(new { message = "El objeto no puede ser nulo" });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newEmpleado = new Empleados
            {
                Nombre = empleadoDTO.Nombre,
                Correo = empleadoDTO.Correo,
                Cargo = empleadoDTO.Cargo,
                Departamento = empleadoDTO.Departamento,
                Telefono = empleadoDTO.Telefono,
                FechaIngreso = empleadoDTO.FechaIngreso,
                Activo = empleadoDTO.Activo
            };

            await _service.AddEmpleado(newEmpleado);
            return CreatedAtAction(nameof(CreateEmpleado), new { id = newEmpleado.Id }, new
            {
                newEmpleado.Id,
                newEmpleado.Nombre,
                newEmpleado.Correo,
                newEmpleado.Cargo,
                newEmpleado.Departamento,
                newEmpleado.Telefono,
                newEmpleado.FechaIngreso,
                newEmpleado.Activo
            });
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmpleado(int id)
        {
            var empleado = await _service.GetById(id);
            if (empleado == null)
                return NotFound(new { message = "Empleado no encontrado" });

            await _service.DeleteEmpleado(id);
            return NoContent();
        }
    

    [HttpPatch("{id}")]
        public async Task<ActionResult> PatchEmpleado(int id, [FromBody] EmpleadoDTO empleadoDTO)
        {
            if (empleadoDTO == null)
            {
                return BadRequest(new { message = "El objeto no puede ser nulo" });
            }

            var existingEmpleado = await _service.GetById(id);
            if (existingEmpleado == null)
            {
                return NotFound(new { message = "Empleado no encontrado" });
            }

            // Actualiza solo los campos que no vengan nulos (o por defecto)
            if (!string.IsNullOrWhiteSpace(empleadoDTO.Nombre))
                existingEmpleado.Nombre = empleadoDTO.Nombre;

            if (!string.IsNullOrWhiteSpace(empleadoDTO.Correo))
                existingEmpleado.Correo = empleadoDTO.Correo;

            if (!string.IsNullOrWhiteSpace(empleadoDTO.Cargo))
                existingEmpleado.Cargo = empleadoDTO.Cargo;

            if (!string.IsNullOrWhiteSpace(empleadoDTO.Departamento))
                existingEmpleado.Departamento = empleadoDTO.Departamento;

            if (!string.IsNullOrWhiteSpace(empleadoDTO.Telefono))
                existingEmpleado.Telefono = empleadoDTO.Telefono;

            if (empleadoDTO.FechaIngreso != default(DateTime))
                existingEmpleado.FechaIngreso = empleadoDTO.FechaIngreso;

            // Aquí sí podrías permitir actualizar explícitamente el estado "Activo"
            existingEmpleado.Activo = empleadoDTO.Activo;

            var updated = await _service.UpdateEmpleado(existingEmpleado);
            if (!updated)
            {
                return StatusCode(500, new { message = "Error al actualizar el empleado" });
            }

            return Ok(new
            {
                existingEmpleado.Id,
                existingEmpleado.Nombre,
                existingEmpleado.Correo,
                existingEmpleado.Cargo,
                existingEmpleado.Departamento,
                existingEmpleado.Telefono,
                existingEmpleado.FechaIngreso,
                existingEmpleado.Activo
            });
        }

    }

}

