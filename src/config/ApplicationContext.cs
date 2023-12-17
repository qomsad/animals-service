using AnimalsService.Dictionary;
using AnimalsService.Model;
using Microsoft.EntityFrameworkCore;

namespace AnimalsService.Config
{
  public class ApplicationContext() : DbContext()
  {
    public DbSet<LegalType> LegalTypes { get; set; }
    public DbSet<OrganizationType> OrganizationTypes { get; set; }
    public DbSet<Municipality> Municipalities { get; set; }
    public DbSet<Organization> Organizations { get; set; }
    public DbSet<Contract> Contracts { get; set; }
    public DbSet<ContractCost> ContractCosts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      const string CONNECTION_STRING = "Host=localhost;Port=5432;Database=model;Username=animals;Password=animals_g";

      optionsBuilder.UseNpgsql(CONNECTION_STRING);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Organization>().HasOne(o => o.OrganizationType).WithMany();
      modelBuilder.Entity<Organization>().HasOne(o => o.LegalType).WithMany();

      modelBuilder.Entity<ContractCost>().HasOne(o => o.Municipalities).WithMany();

      modelBuilder.Entity<Contract>().HasOne(o => o.Contractor).WithMany();
      modelBuilder.Entity<Contract>().HasOne(o => o.Customer).WithMany();
      modelBuilder.Entity<Contract>().HasMany(o => o.ContractCosts).WithOne(o => o.Contract);
    }
  }
}
