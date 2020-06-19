using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EKomplet.Models;
using Microsoft.EntityFrameworkCore;

namespace EKomplet.Data
{
    public class DistrictDBContext : DbContext
    {
        public DistrictDBContext(DbContextOptions<DistrictDBContext> options) : base(options)
        {

        }

        public DbSet<District> Districts { get; set; }
        public DbSet<Business> Businesses { get; set; }
        public DbSet<Salesman> Salesmen { get; set; }
        public DbSet<SecondarySalesmen> SecondarySalesmens { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //relations

            builder.Entity<Business>().HasKey(k => new { k.BusinessName, k.DistrictName });
            builder.Entity<SecondarySalesmen>().HasKey(s => new { s.DistrictName, s.SalesmanID });

        }
    }
}
