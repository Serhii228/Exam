using API.DbOperations;
using API.DbOperations.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : Controller
    {
        private readonly IDbOperations _dbOperations;
        public TasksController(IDbOperations dbOperations)
        {
            _dbOperations = dbOperations;
        }
        [HttpGet]
        public async Task<IActionResult> ProjectTasks()
        {
            try
            {
                return Ok(await _dbOperations.GetAll());
            }
            catch (System.Exception ex)
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<IActionResult> NewTask(ProjectTaskEntity taskEntity)
        {
            try
            {
                return Ok(_dbOperations.AddTask(taskEntity));
            }
            catch (System.Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdatedTask(ProjectTaskEntity taskEntity)
        {
            try
            {
                return Ok(_dbOperations.UpdateTask(taskEntity));
            }
            catch (System.Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeletedTask(ProjectTaskEntity taskEntity)
        {
            try
            {
                return Ok(_dbOperations.DeleteTask(taskEntity));
            }
            catch (System.Exception ex)
            {
                return NotFound();
            }
        }
    }
}
