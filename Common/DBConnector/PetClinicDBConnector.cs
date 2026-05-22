using Microsoft.EntityFrameworkCore;
using PetClinicTests.Models.DataBase;
using System.Reflection;

namespace PetClinicTests.Common.DBConnector
{
    public class PetClinicDBConnector : DbContext
    {
        public DbSet<OwnersTable> Owners { get; set; }
        public DbSet<SpecialtiesTable> Specialties { get; set; }

        public PetClinicDBConnector(DbContextOptions<PetClinicDBConnector> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public PetClinicDBConnector()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("PetClinic"));
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
