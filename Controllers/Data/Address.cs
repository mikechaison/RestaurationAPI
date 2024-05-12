using System.ComponentModel.DataAnnotations;

namespace RestaurationAPI.Data;

public partial class Address
{
    [Key]
    public int Id { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public int Num { get; set; }
    public int? RestaurantId { get; set; }
    public virtual Restaurant? Restaurant { get; set; }
}