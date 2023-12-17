using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Sieve.Attributes;

namespace AnimalsService.Dictionary
{
  [Table("dic_organization_type")]
  public class DicOrganizationType
  {
    [Column("id"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Sieve(CanFilter = true, CanSort = true)]
    public long Id { get; set; }

    [Column("record_name"), Sieve(CanFilter = true, CanSort = true)]
    public required string Value { get; set; }
  }
}
