using MyWebApi.Business.Models;

namespace MyWebApi.Api.Extensions;

public static class ConfigureServices
{
    public static void ConfigureApiServices(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddAutoMapper(typeof(OrdersMappingProfile), typeof(UsersMappingProfile));
        services.AddSwagger();
    }
}
