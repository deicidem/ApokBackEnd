using Microsoft.AspNetCore.Http;
using ApokBackEnd.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApokBackEnd.Services.Dto
{
    public class SearchDto
    {
        //Id - null, когда отправлена нам для создания
        //Обратите внимание на конфигурацию мэппинга
        //Id может отсуствовать в DTO, если практикуются разделения на Input/Output модели
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int StartCloudiness { get; set; }
        public int EndCloudiness { get; set; }

        public IEnumerable<int> Months { get; set; }
        public IEnumerable<int> Satelites { get; set; }
    }
}