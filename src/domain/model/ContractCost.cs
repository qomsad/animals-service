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

    [Column("contract_id"), Required]
    public required long ContractId { get; set; }

    [ForeignKey("municipality_id"), Required]
    public required DicMunicipality Municipality { get; set; }
  }
}
