using MyWebApi.Api.Extensions;
using MyWebApi.Business;
using MyWebApi.DataLayer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureApiServices();
builder.Services.ConfigureBllServices();
builder.Services.ConfigureDalServices();
builder.Services.ConfigureDataBase(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
