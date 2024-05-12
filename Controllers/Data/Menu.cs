using System.ComponentModel.DataAnnotations;

namespace RestaurationAPI.Data;

public partial class Menu
{
    [Key]
    public int Id { get; set; }
    public int? RestaurantId { get; set; }
    public virtual Restaurant? Restaurant { get; set; }
    public virtual ICollection<DishMenu> DishMenus { get; set; } = new List<DishMenu>();
}