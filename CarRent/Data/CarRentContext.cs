using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarRent.Models;

namespace CarRent.Data
{
    public class CarRentContext : DbContext
    {
        public CarRentContext (DbContextOptions<CarRentContext> options)
            : base(options)
        {
        }

        public DbSet<CarRent.Models.Company> Company { get; set; }

        public DbSet<CarRent.Models.Typ> Typ { get; set; }
    }
}
