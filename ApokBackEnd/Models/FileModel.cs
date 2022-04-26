using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApokBackEnd.Models
{
    public class FileModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public FileType Type { get; set; }
        public string Path { get; set; }
        [ForeignKey("DzzModel")]
        public int DzzId { get; set; }
        public virtual DzzModel Dzz { get; set; }

    }
}
