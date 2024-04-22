using Microsoft.Extensions.DependencyInjection;
using MyWebApi.DataLayer.IRepository;
using MyWebApi.DataLayer.Repositoris;

namespace MyWebApi.DataLayer;

public static class ConfigureServices
{
    public static void ConfigureDalServices(this IServiceCollection services)
    {
        services.AddScoped<IOrdersRepository, OrdersRepository>();
        services.AddScoped<IUsersRepository, UsersRepository>();
    }
}
