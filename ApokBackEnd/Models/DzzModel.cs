using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApokBackEnd.Models
{
    public class DzzModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [ForeignKey("ProcessingLevelModel")]
        public int ProcessingLevelId { get; set; }
        public virtual ProcessingLevelModel ProcessingLevel { get; set; }
        public DateTime Date { get; set; }
        public string Geography { get; set; }
        [ForeignKey("SensorModel")]
        public int SensorId { get; set; }
        public virtual SensorModel Sensor { get; set; }
        public int Round { get; set; }    
        public int Route { get; set; }
        public int Cloudiness { get; set; }
        public string Description { get; set; }
        public virtual ICollection<FileModel> Files { get; set; }
        public virtual ICollection<TaskModel> TaskModels { get; set; }
    }
}
