using DemoBlazorInterceptor.Server.Infrastructure;
using DemoBlazorInterceptor.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoBlazorInterceptor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly TokenManager _tokenManager;

        public UserController(TokenManager manager)
        {
            _tokenManager = manager;
        }
        [HttpPost]
        public IActionResult Login([FromBody] User u)
        {
            return Ok(_tokenManager.GenerateToken(u));
        }
    }
}
