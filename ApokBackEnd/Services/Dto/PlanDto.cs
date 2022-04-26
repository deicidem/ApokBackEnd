using System;
using System.ComponentModel.DataAnnotations;

namespace ApokBackEnd.Services.Dto
{
    public class PlanDto
    {
        //Id - null, когда отправлена нам для создания
        //Обратите внимание на конфигурацию мэппинга
        //Id может отсуствовать в DTO, если практикуются разделения на Input/Output модели
        public int? Id { get; set; }
        
        [Required]
        [StringLength(32,ErrorMessage = "Title length can't be more than 32.")]
        public string Title { get; set; }
        
        
        [Required]
        public string Text { get; set; }
    }
}