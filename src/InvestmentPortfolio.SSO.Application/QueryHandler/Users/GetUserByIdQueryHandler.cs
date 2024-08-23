using InvestmentPortfolio.SSO.Application.Query.Users;
using InvestmentPortfolio.SSO.Domain.Entities;
using InvestmentPortfolio.SSO.Domain.Repositories;
using MediatR;

namespace InvestmentPortfolio.SSO.Application.QueryHandler.Users
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User?>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetByIdAsync(request.UserId);
        }
    }

}
