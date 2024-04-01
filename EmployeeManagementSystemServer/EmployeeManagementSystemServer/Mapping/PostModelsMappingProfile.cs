using AutoMapper;
using EmployeeSystem.API.Models;
using EmployeeSystem.Core.Entities;

namespace EmployeeSystem.API.Mapping
{
    public class PostModelsMappingProfile:Profile
    {
        public PostModelsMappingProfile() 
        {
            CreateMap<EmployeePostModel,Employee>();
            CreateMap<PositionPostModel, Position>();
            CreateMap<PositionForEmployeePostModel,PositionForEmployee>();    
        }
    }
}
