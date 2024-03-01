namespace APC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {

        [HttpPost("Login")]
        public async Task<IActionResult> Login()
        {
            return Ok();
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register()
        {
            return Ok();
        }


    }
}