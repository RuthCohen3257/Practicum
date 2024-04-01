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
    public class PositionForEmployeeService:IPositionForEmployeeService
    {
        private readonly IPositionForEmployeeRepository _positionForEmployeeRepository;

        public PositionForEmployeeService(IPositionForEmployeeRepository positionForEmployeeRepository) 
        {
            _positionForEmployeeRepository = positionForEmployeeRepository;
        }

        public async Task<PositionForEmployee> AddPositionForEmployeeAsync(PositionForEmployee po)
        {
            return await _positionForEmployeeRepository.AddPositionForEmployeeAsync(po);
        }

        public async Task DeletePositionForEmployeeAsync(int id)
        {
             await _positionForEmployeeRepository.DeletePositionForEmployeeAsync(id);
        }

        public async Task<List<PositionForEmployee>> GetPositionForEmployeeAsync()
        {
            return await _positionForEmployeeRepository.GetPositionForEmployeeAsync();

        }

        public async Task<PositionForEmployee> GetPositionForEmployeeByIdAsync(int id)
        {
            return await _positionForEmployeeRepository.GetPositionForEmployeeByIdAsync(id);

        }

        public async Task<PositionForEmployee> UpdatePositionForEmployeeAsync(int id, PositionForEmployee position)
        {
            return await _positionForEmployeeRepository.UpdatePositionForEmployeeAsync(id, position);   
        }
    }
}
