using Microsoft.EntityFrameworkCore;
using MyWebApi.Core.Dtos;

namespace MyWebApi.DataLayer;

public class HotDogsContext(DbContextOptions<HotDogsContext> options) : DbContext(options)
{
    public DbSet<UserDto> Users { get; set; }
    public DbSet<OrderDto> Orders { get; set; }
    public DbSet<ProductDto> Products { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<UserDto>()
            .HasMany(u => u.Orders)
            .WithOne(o => o.User);

        modelBuilder
            .Entity<OrderDto>()
            .HasMany(o => o.Products)
            .WithOne(p => p.Orders);
    }
}
