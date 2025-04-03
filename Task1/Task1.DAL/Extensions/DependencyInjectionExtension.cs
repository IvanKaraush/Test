using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Task1.DAL.Interfaces;
using Task1.DAL.Repositories;

namespace Task1.DAL.Extensions;

public static class DependencyInjectionExtension
{
    public static IServiceCollection RegisterDal(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddNpgsql<DataContext>(configuration.GetConnectionString("DefaultConnection") ??
                                        throw new ArgumentException("Строка подключения к бд не может быть пустой"));

        services.AddScoped<IDataRepository, DataRepository>();

        return services;
    }
}