using EmployeeSystem.Core.Entities;

namespace EmployeeSystem.API.Models
{
    public class PositionForEmployeePostModel
    {
        public PositionPostModel PositionName { get; set; }
        public bool IsManagerialPosition { get; set; }
        public DateTime DateOfEntryIntoOffice { get; set; }
    }
}
