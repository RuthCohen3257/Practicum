using EmployeeSystem.Core.Entities;
using EmployeeSystem.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Data.Repositories
{
    public class PositionRepository :IPositionRepository
    {
        private readonly DataContext _dataContext;

        public PositionRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Position> AddPositionAsync(Position po)
        {
            _dataContext.PositionsList.Add(po);
            await _dataContext.SaveChangesAsync();
            return po;
        }

        public async Task DeletePositionAsync(int id)
        {
            var position = await GetPositionByIdAsync(id);
            _dataContext.Remove(position);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<List<Position>> GetPositionAsync()
        {
           return await _dataContext.PositionsList.ToListAsync();
        }

        public async Task<Position> GetPositionByIdAsync(int id)
        {
            return await _dataContext.PositionsList.Include(e => e.PositionForEmployees)
                .FirstOrDefaultAsync(em => em.Id == id);
        }

        public async Task<Position> UpdatePositionAsync(int id, Position position)
        {
            var existPosition = await GetPositionByIdAsync(id);
            _dataContext.Entry(existPosition).CurrentValues.SetValues(existPosition);
            await _dataContext.SaveChangesAsync();
            return position;
        }
    }
}
