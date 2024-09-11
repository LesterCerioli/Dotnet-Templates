using CleanArchitecture1.Application.Interfaces;
using CleanArchitecture1.Infrastructure.Resources.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture1.Infrastructure.Resources
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddResourcesInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<ITranslator, Translator>();

            return services;
        }
    }
}
