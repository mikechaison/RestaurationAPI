using System.ComponentModel.DataAnnotations;

namespace RestaurationAPI.Data;

public partial class Dish
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsVegan { get; set; }
    public bool IsSpicy { get; set; }
    public bool IsDrink { get; set; }
    public int Cost { get; set; }
    public int Weight { get; set; }
    public virtual ICollection<DishMenu> DishMenus { get; set; } = new List<DishMenu>();
    public virtual ICollection<DishOrder> DishOrders { get; set; } = new List<DishOrder>();
}