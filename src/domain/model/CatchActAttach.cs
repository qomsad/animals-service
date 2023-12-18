using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimalsService.Model
{
  [Table("catch_act_attach")]
  public class CatchActAttach
  {
    [Column("id"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [Column("act_id")]
    public long ActId;

    [Column("file_name")]
    public required string FileName;

    [Column("file_path")]
    public required string FilePath;
  }
}
