using Microsoft.AspNetCore.Authorization;

namespace APC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class UsersController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            throw new NotImplementedException();
        }
        [HttpGet("{id}")]
        public Task<IActionResult> GetUser(Guid id)
            => throw new NotImplementedException();

        [HttpPost]
        public Task<IActionResult> Create()
            => throw new NotImplementedException();


        [HttpPut]
        public Task<IActionResult> Update()
            => throw new NotImplementedException();

        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            return Ok();
        }
    }
}