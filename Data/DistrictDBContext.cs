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
        public DbSet<SalesmenStatus> SalesmenStatuses { get; set; }
        public DbSet<SalesmenInBusiness> SalesmenInBusinesses { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //relations

            builder.Entity<SalesmenStatus>().HasKey(k => new {k.DistrictID, k.SalesmanID});
            builder.Entity<SalesmenInBusiness>().HasKey(k => new {k.BusinessID, k.SalesmanID});
        }
    }
}