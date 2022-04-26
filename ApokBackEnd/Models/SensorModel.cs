using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApokBackEnd.Models
{
    public class SensorModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [ForeignKey("SateliteModel")]
        public int SateliteId { get; set; }
        public virtual SateliteModel Satelite { get; set; }
        public virtual ICollection<DzzModel> Dzzs { get; set; }
        public virtual ICollection<SpectorModel> Spectors { get; set; }


    }
}
