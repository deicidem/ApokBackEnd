using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ApokBackEnd.Models;
using System;
using System.Linq;

namespace ApokBackEnd.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationContext>>()))
            {
                if (context.Plans.Any())
                {
                    return;
                }
                // Look for any movies.
                context.Plans.AddRange(
                    new PlanModel
                    {
                        Title = "Формирование температурных карт",
                        Text = "Построение карты температур по тепловым каналам КА Landsat-8 производится с целью вычисления значений температур поверхности в градусах Цельсия, выявления тепловых аномалий.",
                    },
                    new PlanModel
                    {
                        Title = "Формирование температурных карт",
                        Text = "Построение карты температур по тепловым каналам КА Landsat-8 производится с целью вычисления значений температур поверхности в градусах Цельсия, выявления тепловых аномалий.",
                    },
                    new PlanModel
                    {
                        Title = "Формирование температурных карт",
                        Text = "Построение карты температур по тепловым каналам КА Landsat-8 производится с целью вычисления значений температур поверхности в градусах Цельсия, выявления тепловых аномалий.",
                    },
                    new PlanModel
                    {
                        Title = "Формирование температурных карт",
                        Text = "Построение карты температур по тепловым каналам КА Landsat-8 производится с целью вычисления значений температур поверхности в градусах Цельсия, выявления тепловых аномалий.",
                    }
                );
                context.SaveChanges();

                context.Satelites.AddRange(
                    new SateliteModel
                    {
                        Name = "Канопус В 1",
                        Description = "Lorem ipsum"
                    },
                    new SateliteModel
                    {
                        Name = "Канопус В 2",
                        Description = "Lorem ipsum"
                    },
                    new SateliteModel
                    {
                        Name = "Канопус В 3",
                        Description = "Lorem ipsum"
                    }
                );
                context.SaveChanges();
                context.Sensors.AddRange(
                    new SensorModel
                    {
                        Name = "Sensor 1",
                        Description = "Lorem ipsum",
                        SateliteId = context.Satelites.ToArray()[0].Id
                    },
                    new SensorModel
                    {
                        Name = "Sensor 2",
                        Description = "Lorem ipsum",
                        SateliteId = context.Satelites.ToArray()[1].Id
                    },
                    new SensorModel
                    {
                        Name = "Sensor 3",
                        Description = "Lorem ipsum",
                        SateliteId = context.Satelites.ToArray()[2].Id
                    }
                );
                context.SaveChanges();
                context.Spectors.AddRange(
                    new SpectorModel
                    {
                        Name = "Spector 1",
                        StartW = 100,
                        EndW = 200,
                        SensorId = context.Sensors.ToArray()[0].Id
                    },
                    new SpectorModel
                    {
                        Name = "Spector 2",
                        StartW = 200,
                        EndW = 300,
                        SensorId = context.Sensors.ToArray()[1].Id
                    },
                    new SpectorModel
                    {
                        Name = "Spector 3",
                        StartW = 300,
                        EndW = 400,
                        SensorId = context.Sensors.ToArray()[2].Id
                    }
                );
                context.SaveChanges();
                context.ProcessingLevels.AddRange(
                    new ProcessingLevelModel
                    {
                        Name = "PS1"

                    },
                    new ProcessingLevelModel
                    {
                        Name = "PS2"

                    },
                    new ProcessingLevelModel
                    {
                        Name = "PS3"

                    }
                );
                context.SaveChanges();
                context.Dzzs.AddRange(
                    new DzzModel
                    {
                        Name = "ДЗЗ 1",
                        Date = DateTime.UtcNow,
                        ProcessingLevelId = context.ProcessingLevels.ToArray()[0].Id,
                        SensorId = context.Sensors.ToArray()[0].Id,
                        Round = 23121,
                        Route = 1,
                        Cloudiness = 10,
                        Description = "Lorem ipsum"
                    },
                    new DzzModel
                    {
                        Name = "ДЗЗ 2",
                        Date = DateTime.UtcNow,
                        ProcessingLevelId = context.ProcessingLevels.ToArray()[1].Id,
                        SensorId = context.Sensors.ToArray()[1].Id,
                        Round = 23121,
                        Route = 2,
                        Cloudiness = 3,
                        Description = "Lorem ipsum"
                    },
                    new DzzModel
                    {
                        Name = "ДЗЗ 3",
                        Date = DateTime.UtcNow,
                        ProcessingLevelId = context.ProcessingLevels.ToArray()[2].Id,
                        SensorId = context.Sensors.ToArray()[2].Id,
                        Round = 23121,
                        Route = 3,
                        Cloudiness = 20,
                        Description = "Lorem ipsum"
                    }
                );
                context.SaveChanges();
                context.Files.AddRange(
                    new FileModel
                    {
                        Name = "снимок1.png",
                        Type = FileType.Preview,
                        Path = "C:\\Users\\Почитаев Андрей\\Desktop\\ASP_NET\\Практика\\MoviesAppWithServices\\ApokBackEnd\\wwwroot\\files\\1_ДЗЗ 1\\снимок1.png",
                        DzzId = context.Dzzs.ToArray()[0].Id,
                    },
                    new FileModel
                    {
                        Name = "снимок1.json",
                        Type = FileType.Geography,
                        Path = "C:\\Users\\Почитаев Андрей\\Desktop\\ASP_NET\\Практика\\MoviesAppWithServices\\ApokBackEnd\\wwwroot\\files\\1_ДЗЗ 1\\снимок1.json",
                        DzzId = context.Dzzs.ToArray()[0].Id,
                    },
                    new FileModel
                    {
                        Name = "снимок2.png",
                        Type = FileType.Preview,
                        Path = "C:\\Users\\Почитаев Андрей\\Desktop\\ASP_NET\\Практика\\MoviesAppWithServices\\ApokBackEnd\\wwwroot\\files\\2_ДЗЗ 2\\снимок2.png",
                        DzzId = context.Dzzs.ToArray()[1].Id,
                    },
                    new FileModel
                    {
                        Name = "снимок2.json",
                        Type = FileType.Geography,
                        Path = "C:\\Users\\Почитаев Андрей\\Desktop\\ASP_NET\\Практика\\MoviesAppWithServices\\ApokBackEnd\\wwwroot\\files\\2_ДЗЗ 2\\снимок2.json",
                        DzzId = context.Dzzs.ToArray()[1].Id,
                    }
                );
                context.SaveChanges();
                context.Tasks.AddRange(
                    new TaskModel
                    {
                        Title = "Формирование температурных карт 1",
                        DzzModel = context.Dzzs.ToArray()[0],
                        Status = Status.Pending,
                        Result = null,
                    },
                    new TaskModel
                    {
                        Title = "Формирование температурных карт 2",
                        DzzModel = context.Dzzs.ToArray()[1],
                        Status = Status.Ready,
                        Result = null
                    },
                    new TaskModel
                    {
                        Title = "Формирование температурных карт 3",
                        DzzModel = context.Dzzs.ToArray()[2],
                        Status = Status.Proccessing,
                        Result = null
                    }
                );

                context.Alerts.AddRange(
                    new AlertModel
                    {
                        Title = "Уведомление 1",
                        Description = "Lorem ipsum"
                    },
                    new AlertModel
                    {
                        Title = "Уведомление 2",
                        Description = "Lorem ipsum"
                    },
                    new AlertModel
                    {
                        Title = "Уведомление 3",
                        Description = "Lorem ipsum"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}