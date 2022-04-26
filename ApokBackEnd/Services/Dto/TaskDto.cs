using ApokBackEnd.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace ApokBackEnd.Services.Dto
{
    public class TaskDto
    {
        //Id - null, когда отправлена нам для создания
        //Обратите внимание на конфигурацию мэппинга
        //Id может отсуствовать в DTO, если практикуются разделения на Input/Output модели
        public int? Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public Status Status { get; set; }
        public string Result { get; set; }
    }
}