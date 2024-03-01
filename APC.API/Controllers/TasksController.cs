namespace APC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            return Ok();
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTask(Guid id)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask()
        {
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTask()
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
