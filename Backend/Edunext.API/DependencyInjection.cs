using Edunext.Application;
using Edunext.Infrastructure;

namespace Edunext.API;

public static class DependencyInjection
{
    public static IServiceCollection AddAppDI(this IServiceCollection services)
    {
        services.AddApplicationDI().AddInfrastructureDI();
        return services;
    }
}