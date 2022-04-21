using Microsoft.Extensions.DependencyInjection;

namespace WebApi.Extensions
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<Application.Boundaries.CompanyOne.IGetBestDealUseCase, Application.UseCases.CompanyOne.GetBestDealUseCase>();
            services.AddScoped<Application.Boundaries.CompanyTwo.IGetBestDealUseCase, Application.UseCases.CompanyTwo.GetBestDealUseCase>();
            return services;
        }
    }
}
