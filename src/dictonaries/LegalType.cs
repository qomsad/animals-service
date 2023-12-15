using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimalsService.Dictionary
{
  [Table("dic_legal_type")]
  public class LegalType
  {
    [Column("id"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [Column("record_name")]
    public string? Value { get; set; }
  }
}
