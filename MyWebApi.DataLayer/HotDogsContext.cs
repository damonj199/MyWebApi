using Microsoft.EntityFrameworkCore;
using MyWebApi.Core.Dtos;

namespace MyWebApi.DataLayer;

public class HotDogsContext(DbContextOptions<HotDogsContext> options) : DbContext(options)
{
    public DbSet<UserDto> Users { get; set; }
    public DbSet<OrdersDto> Orders { get; set; }
    public DbSet<ProductDto> Products { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<UserDto>()
            .HasMany(o => o.Orders)
            .WithOne(u => u.User);

        modelBuilder
            .Entity<OrdersDto>()
            .HasMany(o => o.Products)
            .WithOne(p => p.Orders);
    }
}
