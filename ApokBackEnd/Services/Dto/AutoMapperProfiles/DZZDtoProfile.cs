using AutoMapper;
using ApokBackEnd.Models;

namespace ApokBackEnd.Services.Dto.AutoMapperProfiles
{
    public class DZZDtoProfile:Profile
    {
        public DZZDtoProfile()
        {
            CreateMap<DzzModel, DzzDto>().ReverseMap();
        }
    }
}