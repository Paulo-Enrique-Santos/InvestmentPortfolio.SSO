using MediatR;

namespace InvestmentPortfolio.SSO.Application.Commands.Users
{
    public class SetRegisterUserCommand : BaseCommand<Unit>
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}