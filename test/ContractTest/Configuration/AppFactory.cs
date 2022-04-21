using ContractTests.Mocks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Shared.Extensions;

namespace ContractTests.Configuration
{
    public class AppFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        private readonly AppServicesMock _appServicesMock;

        public AppFactory(AppServicesMock appServicesMock) =>
            _appServicesMock = appServicesMock;

        protected override IHostBuilder CreateHostBuilder()
        {
            var builder = Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(x =>
                {
                    x.UseStartup<TStartup>().UseTestServer();
                })
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: false);
                });
            return builder;
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(configureServices =>
            {
                configureServices.SwapScoped(provider => _appServicesMock.CompanyOneGetBestDealUseCase);
                configureServices.SwapScoped(provider => _appServicesMock.CompanyTwoGetBestDealUseCase);
                configureServices.SwapScoped(provider => _appServicesMock.CompanyThreeGetBestDealUseCase);
                configureServices.SwapScoped(provider => _appServicesMock.Mediator);
            });
        }
    }
}
