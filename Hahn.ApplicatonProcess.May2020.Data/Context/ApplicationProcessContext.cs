using Hahn.ApplicatonProcess.May2020.Data.EntityConfig;
using Hahn.ApplicatonProcess.May2020.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hahn.ApplicatonProcess.May2020.Data.Context
{
    public class ApplicationProcessContext : DbContext
    {
        public ApplicationProcessContext()
        {

        }

        public DbSet<Applicant> MyProperty { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ApplicantConfig());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("ApplicationProcessDB");
        }
    }
}
