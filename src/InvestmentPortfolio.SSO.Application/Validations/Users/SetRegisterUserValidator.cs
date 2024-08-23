using FluentValidation;
using InvestmentPortfolio.SSO.Application.Commands.Users;
using InvestmentPortfolio.SSO.Application.Helpers.Errors;

namespace InvestmentPortfolio.SSO.Application.Validations.Users
{
    public class SetRegisterUserValidator : AbstractValidator<SetRegisterUserCommand>
    {
        public SetRegisterUserValidator() 
        {
            IsValidPassword();
            IsValidEmail();
        }

        private void IsValidPassword()
        {
            RuleFor(entity => entity.Password)
                .NotNull().WithErrorCode(ErrorMessage.FIELD_REQUIRED.Code)
                .MinimumLength(8).WithErrorCode(ErrorMessage.PASSWORD_SHORTED.Code)
                .Matches(@"[!@#$%^&*()_+}{:|?>.<,=\/[\]~-]").WithErrorCode(ErrorMessage.PASSWORD_SPECIAL_CHARACTER_MISSING.Code)
                .Matches(@"\d").WithErrorCode(ErrorMessage.PASSWORD_NUMBER_MISSING.Code)
                .Matches(@"[A-Z]").WithErrorCode(ErrorMessage.PASSWORD_UPPERCASE_MISSING.Code);
        }

        private void IsValidEmail()
        {
            RuleFor(entity => entity.Email)
                .NotNull().WithErrorCode(ErrorMessage.FIELD_REQUIRED.Code)
                .Matches(@"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[\w-]{2,}$").WithErrorCode(ErrorMessage.INVALID_EMAIL.Code);
        }
    }
}
