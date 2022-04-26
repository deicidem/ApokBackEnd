using AutoMapper;
using ApokBackEnd.Models;

namespace ApokBackEnd.Services.Dto.AutoMapperProfiles
{
    public class FileDtoProfile:Profile
    {
        public FileDtoProfile()
        {
            CreateMap<FileModel, FileDto>().ReverseMap();
        }
    }
}