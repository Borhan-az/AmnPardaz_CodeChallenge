using APC.Application.Common.Audit;
using APC.Application.Tasks.Commands.Create;
using APC.Application.Tasks.Commands.Delete;
using APC.Application.Tasks.Commands.Update;
using APC.Application.Tasks.Queries.GetTask;
using APC.Application.Tasks.Queries.GetTasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace APC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TasksController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            var audit = new AuditDto(GetUserId().Value, GetUserName().Value);

            var res = await _mediator.Send(new GetAllTasksQuery(audit));
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTask(Guid id)
        {
            var res = await _mediator.Send(new GetTaskByIdQuery(id));
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask(CreateTaskRequestDto createTask)
        {
            var res = await _mediator.Send(new CreateTaskCommand(GetUserId().Value, createTask));
            return Ok(res);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTask(UpdateTaskRequestDto updateTask)
        {
            var audit = new AuditDto(GetUserId().Value, GetUserName().Value);

            var res = await _mediator.Send(new UpdateTaskCommand(audit, updateTask));
            return Ok(res);
        }
        [HttpDelete("{taskId}")]
        public async Task<IActionResult> Delete(Guid taskId)
        {
            var audit = new AuditDto(GetUserId().Value, GetUserName().Value);

            var res = await _mediator.Send(new DeleteTaskCommand(taskId, audit.UserId));

            return Ok(res);
        }


    }
}
