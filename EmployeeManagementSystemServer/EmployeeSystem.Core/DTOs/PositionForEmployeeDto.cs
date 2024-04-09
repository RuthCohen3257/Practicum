using EmployeeSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Core.DTOs
{
    public class PositionForEmployeeDto
    {
        public int PositionId { get; set; }
        public bool IsManagerialPosition { get; set; }
        public DateTime DateOfEntryIntoOffice { get; set; }
    }
}
