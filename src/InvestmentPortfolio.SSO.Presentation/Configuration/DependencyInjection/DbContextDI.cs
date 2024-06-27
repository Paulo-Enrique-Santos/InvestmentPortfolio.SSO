using InvestmentPortfolio.SSO.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace InvestmentPortfolio.SSO.Presentation.Configuration.DependencyInjection
{
    public static class DbContextDI
    {
        public static void Register(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseMySql(configuration.GetConnectionString("ConnectionMySql"),
                    new MySqlServerVersion(new Version(8, 0, 23))));
        }
    }
}
