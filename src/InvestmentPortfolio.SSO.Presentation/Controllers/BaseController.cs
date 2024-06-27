using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentPortfolio.SSO.Presentation.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BaseController : ControllerBase
    {
    }
}
