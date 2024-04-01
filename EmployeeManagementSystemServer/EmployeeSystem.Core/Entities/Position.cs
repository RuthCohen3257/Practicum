using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Core.Entities
{
    //public enum PositionOp
    //{
     //   Manager,
     //  Teacher,
     //   Supervisor,
       // Secretary,
      //  Deputy
    //}
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PositionForEmployee> PositionForEmployees { get; set; }
    }
}
