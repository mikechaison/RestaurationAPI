namespace RestaurationAPI.Data;

public partial class DishOrder
{
    public int DishId { get; set; }
    public Dish Dish { get; set; }
    public int OrderId { get; set; }
    public Order Order { get; set; }
}