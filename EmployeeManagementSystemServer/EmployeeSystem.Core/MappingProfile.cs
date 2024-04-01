using AutoMapper;
using EmployeeSystem.Core.DTOs;
using EmployeeSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Core
{
    public class MappingProfile : Profile
    {

        public MappingProfile() 
        {
            CreateMap<EmployeeDto,Employee>().ReverseMap();
            CreateMap<Position,PositionDto>().ReverseMap();
            CreateMap<PositionForEmployee,PositionForEmployeeDto>().ReverseMap();
        }
    }
}
