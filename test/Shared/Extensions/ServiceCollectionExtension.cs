using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Shared.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class ServiceCollectionExtensions
    {
        public static void SwapScoped<TService>(this IServiceCollection services, Func<IServiceProvider, TService> implementation)
        {
            RemoveService<TService>(services, ServiceLifetime.Scoped);

            services.AddScoped(typeof(TService), (sp) => implementation(sp));
        }

        public static void SwapTransient<TService>(this IServiceCollection services, Func<IServiceProvider, TService> implementation)
        {
            RemoveService<TService>(services, ServiceLifetime.Transient);

            services.AddTransient(typeof(TService), (sp) => implementation(sp));
        }

        private static void RemoveService<TService>(IServiceCollection services, ServiceLifetime serviceLifetime)
        {
            if (services.Any(x => x.ServiceType == typeof(TService) && x.Lifetime == serviceLifetime))
            {
                var serviceDescriptors = services
                    .Where(x => x.ServiceType == typeof(TService) && x.Lifetime == serviceLifetime)
                    .ToList();

                foreach (var serviceDescriptor in serviceDescriptors)
                {
                    services.Remove(serviceDescriptor);
                }
            }
        }
    }
}
