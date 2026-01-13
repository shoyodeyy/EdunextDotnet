using Edunext.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql;

namespace Edunext.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureDI(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseMySql(
                connectionString: configuration.GetConnectionString("ConnectDB") ?? "Server=localhost;Port=3306;Database=Edu;Uid=root;Pwd=your_mysql_password;",
                ServerVersion.AutoDetect(configuration.GetConnectionString("ConnectDB") ?? "Server=localhost;Port=3306;Database=Edu;Uid=root;Pwd=your_mysql_password;")));
        
        return services;
    }
}