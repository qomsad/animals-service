using AnimalsService.Dictionary;
using AnimalsService.Model;
using Microsoft.EntityFrameworkCore;

namespace AnimalsService.Config
{
  public class ApplicationContext() : DbContext()
  {
    public DbSet<Organization> Organizations { get; set; }
    public DbSet<LegalType> LegalTypes { get; set; }
    public DbSet<OrganizationType> OrganizationTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      const string CONNECTION_STRING = "Host=localhost;Port=5432;Database=model;Username=animals;Password=animals_g";

      optionsBuilder.UseNpgsql(CONNECTION_STRING);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Organization>().HasOne(o => o.OrganizationType).WithMany();
      modelBuilder.Entity<Organization>().HasOne(o => o.LegalType).WithMany();
    }
  }
}
