using FluentValidation;
using InvestmentPortfolio.SSO.Application.Commands.Users;
using InvestmentPortfolio.SSO.Application.Dto.Response.Core;
using InvestmentPortfolio.SSO.Application.Exceptions;
using InvestmentPortfolio.SSO.Application.Factories.Users;
using InvestmentPortfolio.SSO.Application.Helpers.Errors;
using InvestmentPortfolio.SSO.Application.Validations.Users;
using InvestmentPortfolio.SSO.Domain.Repositories;
using MediatR;

namespace InvestmentPortfolio.SSO.Application.CommandHandlers.Users
{
    public class SetRegisterUserCommandHandler : BaseCommandHandler<SetRegisterUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;

        public SetRegisterUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        protected async override Task<Unit> HandleCommand(SetRegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = UserFactory.CreateUserFromCommand(request);
            await _userRepository.AddAsync(user);
            return Unit.Value;
        }

        protected override void ValidateParams(SetRegisterUserCommand request)
        {
            var validator = new SetRegisterUserValidator();
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(error =>
                    new ErrorDetailResponseDTO(ErrorMessage.GetErrorMessageByCode(error.ErrorCode), error.PropertyName)).ToList();

                throw new BadRequestException(new ErrorsResponseDTO(errors));
            }
        }
    }
}
