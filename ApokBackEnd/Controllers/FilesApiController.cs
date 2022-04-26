using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApokBackEnd.Data;
using ApokBackEnd.Models;
using ApokBackEnd.Services;
using ApokBackEnd.Services.Dto;

namespace ApokBackEnd.Controllers
{
    [Route("api/files")]
    [ApiController]
    public class FilesApiController : ControllerBase
    {
        private readonly IFileService _service;
        public FilesApiController(IFileService service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult<IEnumerable<DzzDto>> GetFilesByDzz([FromQuery] int dzzId)
        {
            var files = _service.GetFilesByDzz(dzzId);

            return Ok(files);
        }
        [HttpPost]
        public ActionResult<FileDto> AddFile([FromForm]FileDto inputDto)
        {
            var file = _service.AddFile(inputDto);

            return CreatedAtAction("GetById", new { id = file.Id }, file);
        }
    }
}