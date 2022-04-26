using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ApokBackEnd.Services;
using ApokBackEnd.Services.Dto;

namespace ApokBackEnd.Controllers
{
    [Route("api/dzzs")]
    [ApiController]
    public class DzzsApiController : ControllerBase
    {
        private readonly IDzzService _service;
        
        public DzzsApiController(IDzzService service)
        {
            _service = service;
        }

        [HttpGet] // GET: /api/dzzs
        [ProducesResponseType(200, Type = typeof(IEnumerable<DzzDto>))]  
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<DzzDto>> GetDzzs([FromQuery]SearchDto searchDto)
        {
            return Ok(_service.GetAllDzzs(searchDto.StartDate, searchDto.EndDate, searchDto.StartCloudiness, searchDto.EndCloudiness, searchDto.Months, searchDto.Satelites));
        }
        [HttpGet("{id}")] // GET: /api/dzzs/5
        [ProducesResponseType(200, Type = typeof(DzzDto))]  
        [ProducesResponseType(404)]
        public IActionResult GetById(int id)
        {
            var dzz = _service.GetDzz(id);
            if (dzz == null) return NotFound();  
            return Ok(dzz);
        }
        
        [HttpPost] // POST: api/dzzs
        public ActionResult<DzzDto> PostDzz(DzzDto inputDto)
        {
            var dzz = _service.AddDzz(inputDto);
            return CreatedAtAction("GetById", new { id = dzz.Id }, dzz);
        }
        
        [HttpPut("{id}")] // PUT: api/dzzs/5
        public IActionResult UpdateDzz(int id, DzzDto editDto)
        {
            var dzz = _service.UpdateDzz(editDto);

            if (dzz==null)
            {
                return BadRequest();
            }

            return Ok(dzz);
        }
        
        [HttpDelete("{id}")] // DELETE: api/movie/5
        public ActionResult<DzzDto> DeleteDzz(int id)
        {
            var dzz = _service.DeleteDzz(id);
            if (dzz == null) return NotFound();  
            return Ok(dzz);
        }
    }
}