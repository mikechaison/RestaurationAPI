using System.ComponentModel.DataAnnotations;

namespace RestaurationAPI.Data;

public partial class User
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Like> Likes { get; set; } = new List<Like>();
    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}