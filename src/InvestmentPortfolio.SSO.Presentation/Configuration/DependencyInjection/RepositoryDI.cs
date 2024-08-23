using InvestmentPortfolio.SSO.Domain.Repositories;
using InvestmentPortfolio.SSO.Infrastructure.Repositories;

namespace InvestmentPortfolio.SSO.Presentation.Configuration.DependencyInjection
{
    public static class RepositoryDI
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}
