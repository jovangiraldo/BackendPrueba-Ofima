using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Application.DTOs
{
    public class EmpleadoPatchDTO
    {
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? Cargo { get; set; }
        public string? Departamento { get; set; }
        public string? Telefono { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public bool? Activo { get; set; }
    }
}
