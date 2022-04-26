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
    [Route("api/images")]
    public class ImagesController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetImage([FromQuery]string path)
        {
            /*var path = Path.Combine(_appEnvironment.WebRootPath, path);
            Console.WriteLine(path);*/
            var imageFileStream = System.IO.File.OpenRead(path);
            return File(imageFileStream, "image/png");
        }
    }
}