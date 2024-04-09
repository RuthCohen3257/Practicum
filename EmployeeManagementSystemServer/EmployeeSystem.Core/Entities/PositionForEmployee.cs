using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Core.Entities
{
    
    public class PositionForEmployee
    {
        
        public int PositionId { get; set; }
        public int EmployeeId { get; set; }
        public bool IsManagerialPosition { get; set; }
        public DateTime DateOfEntryIntoOffice { get; set; }
    }
}
