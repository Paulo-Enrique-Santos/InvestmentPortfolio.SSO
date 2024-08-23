using InvestmentPortfolio.SSO.Domain.Entities;
using InvestmentPortfolio.SSO.Domain.Repositories;
using InvestmentPortfolio.SSO.Infrastructure.Context;
using InvestmentPortfolio.SSO.Infrastructure.Repositories.Core;

namespace InvestmentPortfolio.SSO.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
