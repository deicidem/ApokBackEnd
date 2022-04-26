using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ApokBackEnd.Data;
using ApokBackEnd.Models;
using ApokBackEnd.Services.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace ApokBackEnd.Services
{
    public class DzzService:IDzzService
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        
        public DzzService(ApplicationContext context, IMapper mapper)
        {   
            _context = context;
            _mapper = mapper;
        }
        public IEnumerable<DzzDto> GetAllDzzs(DateTime startDate, DateTime endDate, int startCloudiness, int endCloudiness, IEnumerable<int> months, IEnumerable<int> satelites)
        {
            Console.WriteLine(startDate.ToString());
            Console.WriteLine(endDate.ToString());
            Console.WriteLine(startCloudiness.ToString());
            Console.WriteLine(endCloudiness.ToString());
            foreach (int m in months)
            {
                Console.WriteLine(m);
            }
            foreach (int s in satelites)
            {
                Console.WriteLine(s);
            }
            var dzzs = _context.Dzzs.Where(e =>
                e.Date >= startDate &&
                e.Date <= endDate &&
                e.Cloudiness >= startCloudiness &&
                e.Cloudiness <= endCloudiness && 
                months.Any(m => m == e.Date.Month) &&
                satelites.Any(s => s == e.SensorId)
            ).ToList();
            var dtos = new List<DzzDto>();
            foreach (var d in dzzs)
            {
                var newDto = new DzzDto
                {
                    Id = d.Id,
                    Name = d.Name,
                    ProcessingLevel = d.ProcessingLevel.Name,
                    Round = d.Round,
                    Route = d.Route,
                    Date = d.Date,
                    Cloudiness = d.Cloudiness,
                };
                if (d.Files.Any())
                {
                    var path = d.Files.FirstOrDefault(e => e.Type == FileType.Geography).Path;
                    string fileName = d.Files.FirstOrDefault(e => e.Type == FileType.Geography).Path;
                    string jsonString = File.ReadAllText(fileName);
                    newDto.PreviewPath = d.Files.FirstOrDefault(e => e.Type == FileType.Preview).Path;
                    newDto.GeographyPath = jsonString;
                }
                dtos.Add(newDto);
            } 
            return dtos;
        }
        public DzzDto GetDzz(int id)
        {
            return _mapper.Map<DzzDto>(_context.Dzzs.FirstOrDefault(m => m.Id == id));
        }

        public DzzDto UpdateDzz(DzzDto dzzDto)
        {
            if (dzzDto.Id == null)
            {
                //упрощение для примера
                //лучше всего генерировать ошибки и обрабатывать их на уровне конроллера
                return null;
            }
            
            try
            {
                var dzz = _mapper.Map<DzzModel>(dzzDto);
                
                _context.Update(dzz);
                _context.SaveChanges();
                
                return _mapper.Map<DzzDto>(dzz);
            }
            catch (DbUpdateException)
            {
                if (!DzzExists((int) dzzDto.Id))
                {
                    //упрощение для примера
                    //лучше всего генерировать ошибки и обрабатывать их на уровне конроллера
                    return null;
                }
                else
                {
                    //упрощение для примера
                    //лучше всего генерировать ошибки и обрабатывать их на уровне конроллера
                    return null;
                }
            }
        }

        public DzzDto AddDzz(DzzDto dzzDto)
        {
            var dzz = _context.Add(_mapper.Map<DzzModel>(dzzDto)).Entity;
            _context.SaveChanges();
            return _mapper.Map<DzzDto>(dzz);
        }

        public DzzDto DeleteDzz(int id)
        {
            var dzz = _context.Dzzs.Find(id);
            if (dzz == null)
            {
                //упрощение для примера
                //лучше всего генерировать ошибки и обрабатывать их на уровне конроллера
                return null;
            }

            _context.Dzzs.Remove(dzz);
            _context.SaveChanges();
            
            return _mapper.Map<DzzDto>(dzz);
        }
        
        private bool DzzExists(int id)
        {
            return _context.Dzzs.Any(e => e.Id == id);
        }

    }
}