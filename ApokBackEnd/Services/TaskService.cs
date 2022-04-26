using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ApokBackEnd.Data;
using ApokBackEnd.Models;
using ApokBackEnd.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApokBackEnd.Services
{
    public class TaskService:ITaskService
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        
        public TaskService(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IEnumerable<TaskDto> GetAllTasks()
        {
            return _mapper.Map<IEnumerable<TaskModel>, IEnumerable<TaskDto>>(_context.Tasks.ToList());
        }
        public TaskDto GetTask(int id)
        {
            return _mapper.Map<TaskDto>(_context.Tasks.FirstOrDefault(m => m.Id == id));
        }

        public TaskDto UpdateTask(TaskDto taskDto)
        {
            if (taskDto.Id == null)
            {
                //упрощение для примера
                //лучше всего генерировать ошибки и обрабатывать их на уровне конроллера
                return null;
            }
            
            try
            {
                var task = _mapper.Map<TaskModel>(taskDto);
                
                _context.Update(task);
                _context.SaveChanges();
                
                return _mapper.Map<TaskDto>(task);
            }
            catch (DbUpdateException)
            {
                if (!TaskExists((int) taskDto.Id))
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

        public TaskDto AddTask(TaskDto taskDto)
        {
            var task = _context.Add(_mapper.Map<TaskModel>(taskDto)).Entity;
            _context.SaveChanges();
            return _mapper.Map<TaskDto>(task);
        }

        public TaskDto DeleteTask(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task == null)
            {
                //упрощение для примера
                //лучше всего генерировать ошибки и обрабатывать их на уровне конроллера
                return null;
            }

            _context.Tasks.Remove(task);
            _context.SaveChanges();
            
            return _mapper.Map<TaskDto>(task);
        }
        
        private bool TaskExists(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }

    }
}