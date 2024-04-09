using EmployeeSystem.Core.Entities;
using EmployeeSystem.Core.Repositories;
using EmployeeSystem.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Service.Services
{
    public class PositionService:IPositionService
    {
        private readonly IPositionRepository _positionRepository;
        public PositionService(IPositionRepository positionRepository) 
        {
            _positionRepository = positionRepository;
        }

        public async Task<Position> AddPositionAsync(Position po)
        {
            return await _positionRepository.AddPositionAsync(po);
        }

        public async Task DeletePositionAsync(int id)
        {
            await _positionRepository.DeletePositionAsync(id);
        }

        public async Task<List<Position>> GetPositionAsync()
        {
            return await _positionRepository.GetPositionAsync();
        }

        public async Task<Position> GetPositionByIdAsync(int id)
        {
            return await _positionRepository.GetPositionByIdAsync(id);
        }

        public async Task<Position> UpdatePositionAsync(int id, Position position)
        {
            return await _positionRepository.UpdatePositionAsync(id, position);
        }
    }
}
