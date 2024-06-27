using InvestmentPortfolio.SSO.Application.Helpers.Errors;

namespace InvestmentPortfolio.SSO.Application.Dto.Response.Core
{
    public record ErrorsResponseDTO
    {
        public List<ErrorDetailResponseDTO> Errors { get; set; } = new List<ErrorDetailResponseDTO>();

        public ErrorsResponseDTO(ErrorMessage errorMessage)
        {
            Errors.Add(new ErrorDetailResponseDTO(errorMessage));
        }

        public ErrorsResponseDTO(ErrorMessage errorMessage, string field)
        {
            Errors.Add(new ErrorDetailResponseDTO(errorMessage, field));
        }

        public ErrorsResponseDTO(List<ErrorMessage> errorMessages)
        {
            Errors.AddRange(errorMessages.Select(errorMessage => new ErrorDetailResponseDTO(errorMessage)).ToList());
        }

        public ErrorsResponseDTO(List<ErrorMessage> errorMessages, string[] fields)
        {
            Errors.AddRange(errorMessages.Zip(fields, (errorMessage, field) => new ErrorDetailResponseDTO(errorMessage, field)).ToList());
        }

        public ErrorsResponseDTO(List<ErrorDetailResponseDTO> errorDetails)
        {
            Errors.AddRange(errorDetails);
        }
    };

    public record ErrorDetailResponseDTO
    {
        public string? Field { get; set; }
        public string Code { get; set; } = ErrorMessage.GENERIC_ERROR.Code;
        public string Message { get; set; } = ErrorMessage.GENERIC_ERROR.Message;

        public ErrorDetailResponseDTO(ErrorMessage errorMessage)
        {
            Code = errorMessage.Code;
            Message = errorMessage.Message;
        }

        public ErrorDetailResponseDTO(ErrorMessage errorMessage, string field)
        {
            Field = field;
            Code = errorMessage.Code;
            Message = errorMessage.FormatMessage(field);
        }
    }
}
