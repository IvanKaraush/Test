using Microsoft.Extensions.DependencyInjection;
using Task1.BLL.Interfaces;
using Task1.BLL.Mapping;
using Task1.BLL.Services;

namespace Task1.BLL.Extensions;

public static class DependencyInjectionExtension
{
    public static IServiceCollection RegisterBll(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(DataMappingProfile));
        services.AddScoped<IDataService, DataService>();
        return services;
    }
}