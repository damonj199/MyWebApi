using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MyWebApi.Api.Extensions;

public static class ConfigureServices
{
    public static void ConfigureApiServices(this IServiceCollection services, ConfigurationManager configurationManager)
    {
        services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = "MyWebApi",
                ValidAudience = "UI",
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("myWebApi_superSecretKey@345"))
            };
        });

        services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwagger();
    }
}
