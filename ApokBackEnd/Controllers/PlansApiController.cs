using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ApokBackEnd.Services;
using ApokBackEnd.Services.Dto;

namespace ApokBackEnd.Controllers
{
    [Route("api/plans")]
    [ApiController]
    public class PlansApiController : ControllerBase
    {
        private readonly IPlanService _service;
        
        public PlansApiController(IPlanService service)
        {
            _service = service;
        }

        [HttpGet] // GET: /api/plans
        [ProducesResponseType(200, Type = typeof(IEnumerable<PlanDto>))]  
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<PlanDto>> GetPlans()
        {
            return Ok(_service.GetAllPlans());
        }
        [HttpGet("{id}")] // GET: /api/plans/5
        [ProducesResponseType(200, Type = typeof(PlanDto))]  
        [ProducesResponseType(404)]
        public IActionResult GetById(int id)
        {
            var plan = _service.GetPlan(id);
            if (plan == null) return NotFound();  
            return Ok(plan);
        }
        
        [HttpPost] // POST: api/plans
        public ActionResult<PlanDto> PostPlan(PlanDto inputDto)
        {
            var plan = _service.AddPlan(inputDto);
            return CreatedAtAction("GetById", new { id = plan.Id }, plan);
        }
        
        [HttpPut("{id}")] // PUT: api/plans/5
        public IActionResult UpdatePlan(int id, PlanDto editDto)
        {
            var plan = _service.UpdatePlan(editDto);

            if (plan==null)
            {
                return BadRequest();
            }

            return Ok(plan);
        }
        
        [HttpDelete("{id}")] // DELETE: api/movie/5
        public ActionResult<PlanDto> DeletePlan(int id)
        {
            var plan = _service.DeletePlan(id);
            if (plan == null) return NotFound();  
            return Ok(plan);
        }
    }
}