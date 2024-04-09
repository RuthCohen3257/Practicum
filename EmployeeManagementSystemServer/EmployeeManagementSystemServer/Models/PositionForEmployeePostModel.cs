using EmployeeSystem.Core.Entities;

namespace EmployeeSystem.API.Models
{
    public class PositionForEmployeePostModel
    {
        public int PositionId { get; set; }
        public bool IsManagerialPosition { get; set; }
        public DateTime DateOfEntryIntoOffice { get; set; }
    }
}
