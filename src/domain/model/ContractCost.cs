using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AnimalsService.Dictionary;

namespace AnimalsService.Model
{
  [Table("contract_cost")]
  public class ContractCost
  {
    [Column("id"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [Column("catch_cost"), Required]
    public required double CatchCost { get; set; }

    [ForeignKey("contract_id"), Required]
    public required Contract Contract { get; set; }

    [ForeignKey("municipalities_id"), Required]
    public required Municipality Municipalities { get; set; }
  }
}
