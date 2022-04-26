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
                        Title = "������������ ������������� ����",
                        Text = "���������� ����� ���������� �� �������� ������� �� Landsat-8 ������������ � ����� ���������� �������� ���������� ����������� � �������� �������, ��������� �������� ��������.",
                    },
                    new PlanModel
                    {
                        Title = "������������ ������������� ����",
                        Text = "���������� ����� ���������� �� �������� ������� �� Landsat-8 ������������ � ����� ���������� �������� ���������� ����������� � �������� �������, ��������� �������� ��������.",
                    },
                    new PlanModel
                    {
                        Title = "������������ ������������� ����",
                        Text = "���������� ����� ���������� �� �������� ������� �� Landsat-8 ������������ � ����� ���������� �������� ���������� ����������� � �������� �������, ��������� �������� ��������.",
                    },
                    new PlanModel
                    {
                        Title = "������������ ������������� ����",
                        Text = "���������� ����� ���������� �� �������� ������� �� Landsat-8 ������������ � ����� ���������� �������� ���������� ����������� � �������� �������, ��������� �������� ��������.",
                    }
                );
                context.SaveChanges();

                context.Satelites.AddRange(
                    new SateliteModel
                    {
                        Name = "������� � 1",
                        Description = "Lorem ipsum"
                    },
                    new SateliteModel
                    {
                        Name = "������� � 2",
                        Description = "Lorem ipsum"
                    },
                    new SateliteModel
                    {
                        Name = "������� � 3",
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
                        Name = "��� 1",
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
                        Name = "��� 2",
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
                        Name = "��� 3",
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
                        Name = "������1.png",
                        Type = FileType.Preview,
                        Path = "C:\\Users\\�������� ������\\Desktop\\ASP_NET\\��������\\MoviesAppWithServices\\ApokBackEnd\\wwwroot\\files\\1_��� 1\\������1.png",
                        DzzId = context.Dzzs.ToArray()[0].Id,
                    },
                    new FileModel
                    {
                        Name = "������1.json",
                        Type = FileType.Geography,
                        Path = "C:\\Users\\�������� ������\\Desktop\\ASP_NET\\��������\\MoviesAppWithServices\\ApokBackEnd\\wwwroot\\files\\1_��� 1\\������1.json",
                        DzzId = context.Dzzs.ToArray()[0].Id,
                    },
                    new FileModel
                    {
                        Name = "������2.png",
                        Type = FileType.Preview,
                        Path = "C:\\Users\\�������� ������\\Desktop\\ASP_NET\\��������\\MoviesAppWithServices\\ApokBackEnd\\wwwroot\\files\\2_��� 2\\������2.png",
                        DzzId = context.Dzzs.ToArray()[1].Id,
                    },
                    new FileModel
                    {
                        Name = "������2.json",
                        Type = FileType.Geography,
                        Path = "C:\\Users\\�������� ������\\Desktop\\ASP_NET\\��������\\MoviesAppWithServices\\ApokBackEnd\\wwwroot\\files\\2_��� 2\\������2.json",
                        DzzId = context.Dzzs.ToArray()[1].Id,
                    }
                );
                context.SaveChanges();
                context.Tasks.AddRange(
                    new TaskModel
                    {
                        Title = "������������ ������������� ���� 1",
                        DzzModel = context.Dzzs.ToArray()[0],
                        Status = Status.Pending,
                        Result = null,
                    },
                    new TaskModel
                    {
                        Title = "������������ ������������� ���� 2",
                        DzzModel = context.Dzzs.ToArray()[1],
                        Status = Status.Ready,
                        Result = null
                    },
                    new TaskModel
                    {
                        Title = "������������ ������������� ���� 3",
                        DzzModel = context.Dzzs.ToArray()[2],
                        Status = Status.Proccessing,
                        Result = null
                    }
                );

                context.Alerts.AddRange(
                    new AlertModel
                    {
                        Title = "����������� 1",
                        Description = "Lorem ipsum"
                    },
                    new AlertModel
                    {
                        Title = "����������� 2",
                        Description = "Lorem ipsum"
                    },
                    new AlertModel
                    {
                        Title = "����������� 3",
                        Description = "Lorem ipsum"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}