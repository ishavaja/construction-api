using Construction.Application;
using Construction.Infrastructure;

namespace Construction.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppDI(this IServiceCollection services)
        {
            services.AddApplicationDI()
                .AddInfrastructureDI();
            return services;
        }
    }
}
