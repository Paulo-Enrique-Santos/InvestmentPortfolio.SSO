using Asp.Versioning;
using InvestmentPortfolio.SSO.Application.Commands.Users;
using InvestmentPortfolio.SSO.Application.Query.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentPortfolio.SSO.Presentation.Controllers.v1
{
    [ApiVersion(1.0)]
    public class UsersController : BaseController
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> SetRegisterUserAsync([FromBody] SetRegisterUserCommand request)
        {
            await _mediator.Send(request);
            return Created();
        }

        [HttpGet]
        public async Task<IActionResult> GetUserDataByIdAsync([FromQuery] GetUserByIdQuery request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}
