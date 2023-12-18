using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AnimalsService.Dictionary;

namespace AnimalsService.Model
{
  [Table("catch_act")]
  public class CatchAct
  {
    [Column("id"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [Column("num"), Required]
    public required string Num { get; set; }

    [Column("catch_date"), Required]
    public required DateTime CatchDate { get; set; }

    [Column("catch_reason")]
    public string? CatchReason { get; set; }

    [ForeignKey("municipality_id")]
    public required DicMunicipality Municipality { get; set; }

    [ForeignKey("contract_id")]
    public required Contract Contract { get; set; }

    public IEnumerable<CatchActAttach>? CatchActAttach { get; set; }

    public IEnumerable<CatchCard>? CatchCards { get; set; }
  }
}
