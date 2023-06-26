using Microsoft.AspNetCore.Mvc;
using TaskManagement.Domain.Interfaces;

namespace TaskManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService )
        {
            _taskService = taskService;
        }

        [HttpGet(nameof(GetAllTasks))]
        public IActionResult GetAllTasks()
        {
            return Ok();
        }
    }
}
