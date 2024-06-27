using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentPortfolio.SSO.Presentation.Controllers.v1
{
    [ApiVersion(1.0)]
    public class AuthController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> SetAsync()
        {
            return Created();
        }
    }
}
