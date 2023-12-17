using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimalsService.Model
{
  [Table("contract")]
  public class Contract
  {
    [Column("id"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [Column("num"), Required]
    public required string Num { get; set; }

    [Column("conclusion_date"), Required]
    public required DateTime ConclusionDate { get; set; }

    [Column("completion_date"), Required]
    public required DateTime CompletionDate { get; set; }

    [ForeignKey("customer_id"), Required]
    public required Organization Customer { get; set; }

    [ForeignKey("contractor_id"), Required]
    public required Organization Contractor { get; set; }

    public List<ContractCost> ContractCosts { get; set; }
  }
}
