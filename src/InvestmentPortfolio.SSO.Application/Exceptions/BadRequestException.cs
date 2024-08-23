using InvestmentPortfolio.SSO.Application.Dto.Response.Core;

namespace InvestmentPortfolio.SSO.Application.Exceptions
{
    public class BadRequestException : BaseException
    {
        public BadRequestException(ErrorsResponseDTO errorsResponseDTO) : base(errorsResponseDTO)
        {
        }
    }
}
