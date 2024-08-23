using InvestmentPortfolio.SSO.Domain.Entities;
using MediatR;

namespace InvestmentPortfolio.SSO.Application.Query.Users
{
    public class GetUserByIdQuery : IRequest<User>
    {
        public int UserId { get; set; }
    }

}
