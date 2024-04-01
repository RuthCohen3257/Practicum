using EmployeeSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Core.DTOs
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string IdNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime StartDate { get; set; }
        public Gender Gender { get; set; }
        public List<PositionForEmployeeDto> Positions { get; set; }
        public bool IsActive { get; set; }=true;
    }
}
