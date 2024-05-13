using Microsoft.Extensions.DependencyInjection;
using MyWebApi.Business.IServices;
using MyWebApi.Business.Services;

namespace MyWebApi.Business;

public static class ConfigureServices
{
    public static void ConfigureBllServices(this IServiceCollection services)
    {
        services.AddScoped<IOrderServices, OrderServices>();
        services.AddScoped<IUserServices, UserServices>();
    }
}
