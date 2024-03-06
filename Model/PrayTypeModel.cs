using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oracap_App_API.Model;

[Table("PrayTypes")]
public class PrayTypeModel
{
    [Key]
    public int PrayTypeId { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
