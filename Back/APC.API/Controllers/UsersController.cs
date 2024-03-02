using Microsoft.AspNetCore.Authorization;

namespace APC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="admin")]
    public class UsersController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(Guid id)
        {

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create()
        {
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update()
        {
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            return Ok();
        }
    }
}