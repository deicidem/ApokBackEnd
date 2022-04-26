using ApokBackEnd.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace ApokBackEnd.Services.Dto
{
    public class DzzDto
    {
        //Id - null, когда отправлена нам для создания
        //Обратите внимание на конфигурацию мэппинга
        //Id может отсуствовать в DTO, если практикуются разделения на Input/Output модели
        public int? Id { get; set; }
        public string Name { get; set; }
        public string ProcessingLevel { get; set; }

        public int Round { get; set; }
        public int Route { get; set; }
        public string Satelite { get; set; }
        public DateTime Date { get; set; }
        public int Cloudiness { get; set; }
        public string PreviewPath { get; set; }
        public string GeographyPath { get; set; }
    }
}