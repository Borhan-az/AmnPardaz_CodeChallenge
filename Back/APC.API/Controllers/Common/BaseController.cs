using MediatR;
using System.Security.Claims;

namespace APC.API.Controllers.Common
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private IMediator mediator;
        protected IMediator _mediator => mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        protected ActionResult<Guid> GetUserId()
        {
            var nameIdentifier = this.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (nameIdentifier is null)
                throw new NullReferenceException();
            return Guid.Parse(nameIdentifier);
        }
        protected ActionResult<string> GetUserName()
        {
            var username = this.User?.FindFirst("username")?.Value;
            if (username is null)
                throw new NullReferenceException();
            return username;
        }

    }
}