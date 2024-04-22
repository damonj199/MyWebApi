using Microsoft.EntityFrameworkCore;
using MyWebApi.DataLayer;

namespace MyWebApi.Api.Extensions;

public static class DataBaseExtansions
{
    public static void ConfigureDataBase(this IServiceCollection services, ConfigurationManager configurationManager)
    {
        services.AddDbContext<HotDogsContext>(
            options => options
                .UseNpgsql(configurationManager
                .GetConnectionString("HotDogs"))
                .UseSnakeCaseNamingConvention());
    }
}