using AnimalsService.Dictionary;
using AnimalsService.Model;
using Microsoft.EntityFrameworkCore;

namespace AnimalsService.Config
{
  public class ApplicationContext() : DbContext()
  {
    public DbSet<DicAnimalCategory> AnimalCategories { get; set; }
    public DbSet<DicAnimalEars> AnimalEars { get; set; }
    public DbSet<DicAnimalHair> AnimalHair { get; set; }
    public DbSet<DicAnimalSize> AnimalSizes { get; set; }
    public DbSet<DicAnimalTail> AnimalTails { get; set; }
    public DbSet<DicLegalType> LegalTypes { get; set; }
    public DbSet<DicOrganizationType> OrganizationTypes { get; set; }
    public DbSet<DicMunicipality> Municipalities { get; set; }
    public DbSet<DicOwnerSign> OwnerSigns { get; set; }
    public DbSet<DicStatus> Statuses { get; set; }

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
      modelBuilder.Entity<ContractCost>().HasOne(o => o.Municipality).WithMany();

      modelBuilder.Entity<Contract>().HasOne(o => o.Contractor).WithMany();
      modelBuilder.Entity<Contract>().HasOne(o => o.Customer).WithMany();
      modelBuilder.Entity<Contract>().HasMany(o => o.ContractCosts).WithOne().HasForeignKey(o => o.ContractId);
    }
  }
}
