using Edunext.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Edunext.Infrastructure.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasOne(oi => oi.Order)
                .WithMany(o => o.Items)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
            
            entity.HasOne(oi => oi.MenuItem)
                .WithMany()
                .HasForeignKey(oi => oi.MenuItemId)
                .OnDelete(DeleteBehavior.Restrict);
            
            entity.Property(oi => oi.UnitPrice)
                .HasPrecision(18, 2);
        });

        modelBuilder.Entity<MenuItem>(entity =>
        {
            entity.HasOne(m => m.Category)
                .WithMany()
                .HasForeignKey(m => m.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
            
            entity.Property(m => m.Price)
                .HasPrecision(18, 2);
            
            // Ignore IsAvailable vì nó là computed property
            entity.Ignore(m => m.IsAvailable);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasOne(o => o.Table)
                .WithMany(t => t.Orders)
                .HasForeignKey(o => o.TableId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }

    public DbSet<Table> Tables { get; set; }
    public DbSet<MenuItem> MenuItems { get; set; }
    public DbSet<MenuCategory> MenuCategories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
}