using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CCSB_Bentelo.Models;


namespace CCSB_Bentelo.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<CCSB_Bentelo.Models.Vehicle> Vehicle { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<AppointmentModel> Appointments { get; set; }
        public DbSet<CCSB_Bentelo.Models.Factuur> Factuur { get; set; }
    }
}

