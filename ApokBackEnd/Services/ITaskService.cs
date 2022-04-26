using System.Collections.Generic;
using ApokBackEnd.Models;
using ApokBackEnd.Services.Dto;

namespace ApokBackEnd.Services
{
    public interface ITaskService
    {
        TaskDto GetTask(int id);
        IEnumerable<TaskDto> GetAllTasks();
        TaskDto UpdateTask(TaskDto taskDto);
        TaskDto AddTask(TaskDto taskDto);
        TaskDto DeleteTask(int id);
    }
}