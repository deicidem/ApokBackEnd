using AutoMapper;
using ApokBackEnd.Models;

namespace ApokBackEnd.Services.Dto.AutoMapperProfiles
{
    public class TaskDtoProfile:Profile
    {
        public TaskDtoProfile()
        {
            CreateMap<TaskModel, TaskDto>()
                .ForMember(dest => dest.Date, o => o.MapFrom(src => src.DzzModel.Date)).ReverseMap();
        }
    }
}