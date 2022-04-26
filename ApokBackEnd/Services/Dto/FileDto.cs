using Microsoft.AspNetCore.Http;
using ApokBackEnd.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace ApokBackEnd.Services.Dto
{
    public class FileDto
    {
        //Id - null, когда отправлена нам для создания
        //Обратите внимание на конфигурацию мэппинга
        //Id может отсуствовать в DTO, если практикуются разделения на Input/Output модели
        public int? Id { get; set; }
        public string Name { get; set; }
        public IFormFile UploadedFile { get; set; }
        public FileType Type { get; set; }

        public string Path { get; set; }
        public int DzzId { get; set; }
    }
}