using InvestmentPortfolio.SSO.Application.Dto.Response.Core;
using InvestmentPortfolio.SSO.Application.Helpers.Errors;

namespace InvestmentPortfolio.SSO.Application.Exceptions
{
    public class BaseException : Exception
    {
        public ErrorsResponseDTO Response { get; set; }

        public BaseException(ErrorMessage errorMessage)
        {
            Response = new ErrorsResponseDTO(errorMessage);
        }

        public BaseException(List<ErrorMessage> errorMessages)
        {
            Response = new ErrorsResponseDTO(errorMessages);
        }

        public BaseException(ErrorsResponseDTO errorsResponseDTO)
        {
            Response = errorsResponseDTO;
        }
    }
}
