using Microsoft.EntityFrameworkCore;
using PetClinicTests.Models.DataBase.PetClinic;
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
                optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("PetClinic")); //optionsBuilder.UseSqlServer - for MSSQL (Microsoft.EntityFrameworkCore.SqlServer package)
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<OwnersTable>().ToTable(tb => tb.HasTrigger("PushStatisticsTriggerOwners")); - если есть триггер
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
