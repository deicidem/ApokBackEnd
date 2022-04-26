using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApokBackEnd.Models
{
    public class SateliteModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Description { get; set; }
        public virtual ICollection<SensorModel> Sensors { get; set; }

    }
}
