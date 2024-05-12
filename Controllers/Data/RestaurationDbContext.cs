using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RestaurationAPI.Data;

public partial class RestaurationDbContext: DbContext
{
    public RestaurationDbContext()
    {
    }

    public RestaurationDbContext(DbContextOptions<RestaurationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }
    public virtual DbSet<Dish> Dishes { get; set; }
    public virtual DbSet<Feedback> Feedbacks { get; set; }
    public virtual DbSet<Like> Likes { get; set; }
    public virtual DbSet<Menu> Menus { get; set; }
    public virtual DbSet<Order> Orders { get; set; }
    public virtual DbSet<Restaurant> Restaurants { get; set; }
    public virtual DbSet<Status> Statuses { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<DishOrder> DishOrders { get; set; }
    public virtual DbSet<DishMenu> DishMenus { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasOne(d => d.Status).WithMany(p => p.Orders)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Status");
            
            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_User");
            
            entity.HasOne(d => d.Restaurant).WithMany(p => p.Orders)
                .HasForeignKey(d => d.RestaurantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Restaurant");
        });

        modelBuilder.Entity<Restaurant>(entity =>
        {
            entity.HasOne(d => d.Address).WithOne(d => d.Restaurant)
                .HasForeignKey<Address>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Restaurant_Address");
            
            entity.HasOne(d => d.Menu).WithOne(d => d.Restaurant)
                .HasForeignKey<Menu>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Restaurant_Menu");
        });

        modelBuilder.Entity<Like>(entity =>
        {
            entity.HasOne(d => d.Restaurant).WithMany(d => d.Likes)
                .HasForeignKey(d => d.RestaurantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Like_Restaurant");
            
            entity.HasOne(d => d.User).WithMany(d => d.Likes)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Like_User");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasOne(d => d.Restaurant).WithMany(d => d.Feedbacks)
                .HasForeignKey(d => d.RestaurantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Feedback_Restaurant");
            
            entity.HasOne(d => d.User).WithMany(d => d.Feedbacks)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Feedback_User");
        });

        modelBuilder.Entity<DishOrder>(entity =>
        {
            entity.HasKey(d => new { d.DishId, d.OrderId });
            
            entity.HasOne(d => d.Dish).WithMany(d => d.DishOrders)
                .HasForeignKey(d => d.DishId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DishOrder_Dish");
            
            entity.HasOne(d => d.Order).WithMany(d => d.DishOrders)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DishOrder_Order");
        });

        modelBuilder.Entity<DishMenu>(entity =>
        {
            entity.HasKey(d => new { d.DishId, d.MenuId });
            
            entity.HasOne(d => d.Dish).WithMany(d => d.DishMenus)
                .HasForeignKey(d => d.DishId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DishMenu_Dish");
            
            entity.HasOne(d => d.Menu).WithMany(d => d.DishMenus)
                .HasForeignKey(d => d.MenuId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DishMenu_Menu");
        });
    }

}