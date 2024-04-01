using EmployeeSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Core.Services
{
    public interface IPositionForEmployeeService
    {
        Task<List<PositionForEmployee>> GetPositionForEmployeeAsync();

        Task<PositionForEmployee> GetPositionForEmployeeByIdAsync(int id);

        Task<PositionForEmployee> AddPositionForEmployeeAsync(PositionForEmployee po);

        Task<PositionForEmployee> UpdatePositionForEmployeeAsync(int id, PositionForEmployee position);

        Task DeletePositionForEmployeeAsync(int id);
    }
}
