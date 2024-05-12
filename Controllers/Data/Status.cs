using System.ComponentModel.DataAnnotations;

namespace RestaurationAPI.Data;

public partial class Status
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}