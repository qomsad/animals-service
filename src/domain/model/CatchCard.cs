using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AnimalsService.Dictionary;

namespace AnimalsService.Model
{
  [Table("catch_act_card")]
  public class CatchCard
  {
    [Column("id"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [Column("act_id")]
    public long ActId { get; set; }

    [Column("animal_chip")]
    public string? AnimalChip { get; set; }

    [Column("animal_chip")]
    public string? AnimalTag { get; set; }

    [Column("animals_breed")]
    public string? AnimalBreed { get; set; }

    [Column("animal_color")]
    public string? AnimalColor { get; set; }

    [ForeignKey("animal_ears")]
    public DicAnimalEars? AnimalEars { get; set; }

    [Column("animal_gender")]
    public required bool AnimalGender { get; set; }

    [ForeignKey("animal_hair")]
    public DicAnimalHair? AnimalHair { get; set; }

    [ForeignKey("animal_category")]
    public DicAnimalCategory? AnimalCategory { get; set; }

    [ForeignKey("animal_size")]
    public DicAnimalSize? AnimalSize { get; set; }

    [Column("animals_signs")]
    public string? AnimalsSigns { get; set; }

    [ForeignKey("animal_tail")]
    public DicAnimalTail? AnimalTail { get; set; }

    [ForeignKey("owner_sign")]
    public DicOwnerSign? OwnerSign { get; set; }

    public IEnumerable<CatchCardPhoto>? CatchCardPhotos { get; set; }
  }
}
