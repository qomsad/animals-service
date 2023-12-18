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

    [
      Column("inn"),
      RegularExpression(@"\d*", ErrorMessage = "ИНН может содержать только цифры"),
      StringLength(12, ErrorMessage = "ИНН не может содержать больше 12 цифр")
    ]
    public string? Inn { get; set; }

    [
      Column("kpp"),
      RegularExpression(@"\d*", ErrorMessage = "КПП может содержать только цифры"),
      StringLength(9, ErrorMessage = "КПП не может содержать больше 9 цифр")
    ]
    public string? Kpp { get; set; }

    [ForeignKey("organization_type_id")]
    public DicOrganizationType? OrganizationType { get; set; }

    [ForeignKey("legal_type_id")]
    public DicLegalType? LegalType { get; set; }
  }
}
