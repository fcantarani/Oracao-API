using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oracap_App_API.Model;

[Table("Categories")]
public class CategoryModel
{
    [Key]
    public int CategoryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string HexaColor { get; set; } = "#FFFFFF";
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public ICollection<PrayerModel>? Prayers  { get; set; }

}
