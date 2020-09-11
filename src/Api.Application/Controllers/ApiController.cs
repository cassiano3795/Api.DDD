using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        
    }
}
