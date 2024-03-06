using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oracap_App_API.Model;

[Table("Categories")]
public class CategoryModel
{
    [Key]
    public int CategoryId { get; set; }
    [Required(ErrorMessage = "O nome da categoria é necessário.")]
    public string Name { get; set; } = string.Empty;
    [Required(ErrorMessage = "A cor da categoria é necessário.")]
    public string HexaColor { get; set; } = "#FFFFFF";
    public DateTime CreatedAt { get; set; } = DateTime.Now;

}
