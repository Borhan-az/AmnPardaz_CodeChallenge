using APC.Application.Auth.Commands.LoginUser;
using APC.Application.Auth.Commands.RegisterUser;
using APC.Application.Common.JWT;

namespace APC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly ITokenService _token;
        public AuthController(ITokenService token)
        {
            _token = token;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUserCommand login)
        {
            var res = await _mediator.Send(login);
            return Ok(res.Token);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterUserCommand register)
        {
            await _mediator.Send(register);

            return Ok();
        }

    }
}