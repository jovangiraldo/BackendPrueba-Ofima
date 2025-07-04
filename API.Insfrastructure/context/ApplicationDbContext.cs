using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Insfrastructure.context
{
    public  class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options)
            :base(options)
        {
            
        }
       
        public DbSet<Empleados> empleados { get; set; }
    }
}
