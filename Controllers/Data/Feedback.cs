using System.ComponentModel.DataAnnotations;

namespace RestaurationAPI.Data;

public partial class Feedback
{
    [Key]
    public int Id { get; set; }
    public string Text { get; set; }
    public int? UserId { get; set; }
    public int? RestaurantId { get; set; }
    public virtual User? User { get; set; }
    public virtual Restaurant? Restaurant { get; set; }

}