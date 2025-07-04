using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Domain.Entities
{
    public class Empleados
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Correo { get; set; }

        public string Cargo { get; set; }

        public string Departamento { get; set; }

        public string Telefono { get; set; }

        public DateTime FechaIngreso { get; set; }

        public bool Activo { get; set; }


    }
}
