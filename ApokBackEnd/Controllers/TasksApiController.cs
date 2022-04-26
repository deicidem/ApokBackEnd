using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ApokBackEnd.Services;
using ApokBackEnd.Services.Dto;

namespace ApokBackEnd.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class TasksApiController : ControllerBase
    {
        private readonly ITaskService _service;
        
        public TasksApiController(ITaskService service)
        {
            _service = service;
        }

        [HttpGet] // GET: /api/tasks
        [ProducesResponseType(200, Type = typeof(IEnumerable<TaskDto>))]  
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<TaskDto>> GetTasks()
        {
            return Ok(_service.GetAllTasks());
        }
        [HttpGet("{id}")] // GET: /api/tasks/5
        [ProducesResponseType(200, Type = typeof(TaskDto))]  
        [ProducesResponseType(404)]
        public IActionResult GetById(int id)
        {
            var task = _service.GetTask(id);
            if (task == null) return NotFound();  
            return Ok(task);
        }
        
        [HttpPost] // POST: api/tasks
        public ActionResult<TaskDto> PostTask(TaskDto inputDto)
        {
            var task = _service.AddTask(inputDto);
            return CreatedAtAction("GetById", new { id = task.Id }, task);
        }
        
        [HttpPut("{id}")] // PUT: api/tasks/5
        public IActionResult UpdateTask(int id, TaskDto editDto)
        {
            editDto.Id = id;
            var task = _service.UpdateTask(editDto);
            
            if (task==null)
            {
                return BadRequest();
            }

            return Ok(task);
        }
        
        [HttpDelete("{id}")] // DELETE: api/movie/5
        public ActionResult<TaskDto> DeleteTask(int id)
        {
            var task = _service.DeleteTask(id);
            if (task == null) return NotFound();  
            return Ok(task);
        }
    }
}