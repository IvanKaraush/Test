using Microsoft.OpenApi.Models;
using Serilog;
using Task1.BLL.Extensions;
using Task1.DAL.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Configuration
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json", false, false)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, false)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.local.json", true, false)
    .AddEnvironmentVariables()
    .AddCommandLine(args);

builder.Services.RegisterBll();
builder.Services.RegisterDal(builder.Configuration);
builder.Logging.ClearProviders();
builder.Host.UseSerilog((context, config) =>
{
    config.ReadFrom.Configuration(context.Configuration);
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Task1.Api",
        Version = "v1"
    });
});

var app = builder.Build();

app.UseSerilogRequestLogging();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();