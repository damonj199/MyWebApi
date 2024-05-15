using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using MyWebApi.Business.IServices;
using MyWebApi.Business.Models.Request;
using MyWebApi.Business.Services;
using MyWebApi.Business.Validator;

namespace MyWebApi.Business;

public static class ConfigureServices
{
    public static void ConfigureBllServices(this IServiceCollection services)
    {
        services.AddScoped<IOrderServices, OrderServices>();
        services.AddScoped<IUserServices, UserServices>();
        services.AddScoped<IValidator<CreateUserRequest>, CreateUserRequestValidator>();
        services.AddScoped<IValidator<UpdateUserRequest>, UpdateUserRequestValidator>();
    }
}
