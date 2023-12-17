using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Sieve.Attributes;

namespace AnimalsService.Dictionary
{
  [Table("dic_municipality")]
  public class Municipality
  {
    [Column("id"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Sieve(CanFilter = true, CanSort = true)]
    public long Id { get; set; }

    [Column("record_name"), Sieve(CanFilter = true, CanSort = true)]
    public string? Value { get; set; }
  }
}
