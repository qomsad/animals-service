using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AnimalsService.Dictionary;

namespace AnimalsService.Model
{
  [Table("organization")]
  public class Organization
  {
    [Column("id"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [Column("address")]
    public string? Address { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("inn"), StringLength(12, ErrorMessage = "ИНН 12 цифр")]
    public string? Inn { get; set; }

    [Column("kpp"), StringLength(9, ErrorMessage = "КПП 9 цифр")]
    public string? Kpp { get; set; }

    [ForeignKey("organization_type_id")]
    public required OrganizationType OrganizationType { get; set; }

    [ForeignKey("legal_type_id")]
    public required LegalType LegalType { get; set; }
  }
}
