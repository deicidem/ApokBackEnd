using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApokBackEnd.Models
{
    public class SpectorModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int StartW { get; set; }
        public int EndW { get; set; }
        [ForeignKey("SensorModel")]
        public int SensorId { get; set; }
        public virtual SensorModel Sensor { get; set; }
    }
}
