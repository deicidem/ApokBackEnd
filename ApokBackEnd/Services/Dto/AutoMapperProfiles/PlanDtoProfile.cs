using AutoMapper;
using ApokBackEnd.Models;

namespace ApokBackEnd.Services.Dto.AutoMapperProfiles
{
    public class PlanDtoProfile:Profile
    {
        public PlanDtoProfile()
        {
            CreateMap<PlanModel, PlanDto>().ReverseMap();
        }
    }
}