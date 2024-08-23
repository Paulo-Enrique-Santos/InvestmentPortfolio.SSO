using MediatR;

namespace InvestmentPortfolio.SSO.Application.CommandHandlers
{
    public abstract class BaseCommandHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        protected abstract void ValidateParams(TRequest request);

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            ValidateParams(request);
            return HandleCommand(request, cancellationToken);
        }

        protected abstract Task<TResponse> HandleCommand(TRequest request, CancellationToken cancellationToken);
    }
}
