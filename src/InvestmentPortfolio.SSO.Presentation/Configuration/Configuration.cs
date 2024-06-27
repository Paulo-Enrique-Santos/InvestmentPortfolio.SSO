using InvestmentPortfolio.SSO.Presentation.Configuration.DependencyInjection;
using InvestmentPortfolio.SSO.Presentation.Configuration.Swagger;

namespace InvestmentPortfolio.SSO.Presentation.Configuration
{
    public static class Configuration
    {
        public static void AddConfiguration(this IServiceCollection service, IConfiguration configuration)
        {
            DbContextDI.Register(service, configuration);
            SwaggerConfiguration.ConfigureSwagger(service);
            RepositoryDI.Register(service);
        }
    }
}
