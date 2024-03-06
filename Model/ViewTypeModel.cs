using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oracap_App_API.Model;

[Table("ViewTypes")]
public class ViewTypeModel
{
    [Key]
    public int ViewTypeId { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;

}
