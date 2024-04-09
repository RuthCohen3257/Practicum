using AutoMapper;
using EmployeeSystem.API.Models;
using EmployeeSystem.Core.Entities;

namespace EmployeeSystem.API.Mapping
{
    public class PostModelsMappingProfile:Profile
    {
        public PostModelsMappingProfile() 
        {
            CreateMap<EmployeePostModel, Employee>()
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => Enum.Parse<Gender>(src.Gender, true)));
            CreateMap<PositionPostModel, Position>();
            CreateMap<PositionForEmployeePostModel,PositionForEmployee>();    
        }
    }
}
