using Edunext.Application.Abstractions.Persistence;
using Edunext.Infrastructure.Persistence;
using Edunext.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Edunext.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureDI(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ConnectDB")));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ITableRepository, TableRepository>();
        services.AddScoped<IMenuRepository, MenuRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IMenuCategoryRepository, MenuCategoryRepository>();
        return services;
    }
}