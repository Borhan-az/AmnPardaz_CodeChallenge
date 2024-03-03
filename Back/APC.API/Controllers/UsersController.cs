using APC.Application.Users.Commands.Delete;
using APC.Application.Users.Queries.GetUsers;
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
            var res = await _mediator.Send(new GetAllUsersQuery());
            return Ok(res);
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

        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete(Guid userId)
        {
            var res = await _mediator.Send(new DeleteUserCommand(userId));

            return Ok(res);
        }
    }
}