using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PayFlow.Api.Domain;

namespace PayFlow.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Payment> Payments => Set<Payment>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    
    }
}