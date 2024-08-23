using InvestmentPortfolio.SSO.Application.Commands.Users;
using InvestmentPortfolio.SSO.Application.Security;
using InvestmentPortfolio.SSO.Domain.Entities;

namespace InvestmentPortfolio.SSO.Application.Factories.Users
{
    public static class UserFactory
    {
        public static User CreateUserFromCommand(SetRegisterUserCommand command)
        {
            return new User
            {
                Email = command.Email,
                Password = PasswordHasher.HashPassword(command.Password),
                Name = command.Name,
                CreatedAt = DateTime.UtcNow
            };
        }
    }
}
