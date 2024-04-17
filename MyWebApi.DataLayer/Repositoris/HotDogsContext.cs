using Microsoft.EntityFrameworkCore;
using MyWebApi.Core.Dtos;

namespace MyWebApi.DataLayer.Repositoris;

public class HotDogsContext : DbContext
{
    public HotDogsContext(DbContextOptions<HotDogsContext> options) : base(options)
    {        
    }

    public DbSet<UserDto> Users { get; set; }
    public DbSet<OrdersDto> Orders { get; set; }
    public DbSet<ProductDto> Products { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
