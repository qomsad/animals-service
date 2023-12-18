using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimalsService.Model
{
  [Table("catch_act_card_photo")]
  public class CatchCardPhoto
  {
    [Column("id"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [Column("card_id")]
    public long CardId;

    [Column("file_name")]
    public required string FileName;

    [Column("file_path")]
    public required string FilePath;
  }
}
