using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApokBackEnd.Models
{
    public class TaskModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("DzzModel")]
        public int DzzModelId { get; set; }
        public virtual DzzModel DzzModel { get; set; }
        public string Title { get; set; }   
        public Status Status { get; set; }
        public string Result { get; set; }
    }
}
