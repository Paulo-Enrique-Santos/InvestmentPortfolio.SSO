using MediatR;

namespace InvestmentPortfolio.SSO.Application.Commands
{
    public abstract class BaseCommand<TResponse> : IRequest<TResponse>
    {
    }
}