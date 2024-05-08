using MyFirstBackend.API.Configuration;
using MyWebApi.Api.Extensions;
using MyWebApi.Business;
using MyWebApi.Business.Models;
using MyWebApi.DataLayer;
using Serilog;

try
{

    var builder = WebApplication.CreateBuilder(args);
    builder.Logging.ClearProviders();

    Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(builder.Configuration)
        .CreateBootstrapLogger();

    // Add services to the container.
    builder.Services.ConfigureApiServices(builder.Configuration);
    builder.Services.ConfigureBllServices();
    builder.Services.ConfigureDalServices();
    builder.Services.ConfigureDataBase(builder.Configuration);
    builder.Services.AddAutoMapper(typeof(OrdersMappingProfile));

    builder.Host.UseSerilog();
    var app = builder.Build();

    app.UseMiddleware<ExceptionMiddleware>();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseSerilogRequestLogging();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    Log.Information("Running app");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex.Message);
}
finally
{
    Log.CloseAndFlush();
}