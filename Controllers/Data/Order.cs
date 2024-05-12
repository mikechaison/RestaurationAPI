using System.ComponentModel.DataAnnotations;

namespace RestaurationAPI.Data;

public partial class Order
{
    [Key]
    public int Id { get; set; }
    public int Sum { get; set; }
    public int? UserId { get; set; }
    public int? RestaurantId { get; set; }
    public int? StatusId { get; set; }
    public virtual User? User { get; set; }
    public virtual Restaurant? Restaurant { get; set;}
    public virtual Status? Status { get; set; }
    public virtual ICollection<DishOrder> DishOrders { get; set; } = new List<DishOrder>();
}