using Microsoft.EntityFrameworkCore;
using ApokBackEnd.Models;

namespace ApokBackEnd.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext (DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }
        public DbSet<PlanModel> Plans { get; set; }
        public DbSet<FileModel> Files { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }
        public DbSet<DzzModel> Dzzs { get; set; }
        public DbSet<ProcessingLevelModel> ProcessingLevels { get; set; }
        public DbSet<SateliteModel> Satelites { get; set; }
        public DbSet<SpectorModel> Spectors { get; set; }
        public DbSet<SensorModel> Sensors { get; set; }
        public DbSet<AlertModel> Alerts { get; set; }
    }
}