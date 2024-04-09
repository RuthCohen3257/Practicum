using EmployeeSystem.Core.DTOs;
using EmployeeSystem.Core.Entities;

namespace EmployeeSystem.API.Models
{
    public class EmployeePostModel
    {
        public string IdNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime StartDate { get; set; }
        public string Gender { get; set; }
        public List<PositionForEmployeePostModel> Positions { get; set; }
    }
}
