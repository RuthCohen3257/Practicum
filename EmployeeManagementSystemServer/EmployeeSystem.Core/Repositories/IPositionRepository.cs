using EmployeeSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Core.Repositories
{
    public interface IPositionRepository
    {
        Task<List<Position>> GetPositionAsync();

        Task<Position> GetPositionByIdAsync(int id);

        Task<Position> AddPositionAsync(Position po);

        Task<Position> UpdatePositionAsync(int id, Position position);

        Task DeletePositionAsync(int id);
    }
}
