using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using System.Net.Mime;
using InvestmentPortfolio.SSO.Application.Dto.Response.Core;
using InvestmentPortfolio.SSO.Application.Exceptions;
using InvestmentPortfolio.SSO.Application.Helpers.Errors;

namespace InvestmentPortfolio.SSO.API.Filter
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        private ExceptionContext? _context;
        public override void OnException(ExceptionContext context)
        {
            _context = context;

            var exception = context.Exception.GetBaseException();

            switch (exception)
            {

                default:
                    SetResult(StatusCodes.Status500InternalServerError, new ErrorsResponseDTO(ErrorMessage.GENERIC_ERROR));
                    break;
            }
        }

        private void SetResult(int StatusCode, ErrorsResponseDTO response)
        {
            if (_context != null)
            {
                _context.HttpContext.Response.StatusCode = StatusCode;
                _context.HttpContext.Response.ContentType = MediaTypeNames.Application.Json;
                _context.Result = new JsonResult(response);
            }
        }
    }
}
