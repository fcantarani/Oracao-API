using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oracap_App_API.Model;

[Table("Prayers")]
public class PrayerModel
{
    [Key]
    public int PrayerId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool Archived { get; set; } = false;


    [ForeignKey("CategoryId")]
    public int CategoryId { get; set; }
    public CategoryModel? Category { get; set; }

    [ForeignKey("ViewTypeId")]
    public int ViewTypeId { get; set; }
    public ViewTypeModel? ViewType { get; set; }

    [ForeignKey("PrayTypeId")]
    public int PrayTypeId { get; set; }
    public PrayTypeModel? PrayType { get; set; }
}
