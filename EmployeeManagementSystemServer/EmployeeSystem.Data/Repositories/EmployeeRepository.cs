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
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _dataContext;
        public EmployeeRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
           
            _dataContext.EmployeeList.Add(employee);
            await _dataContext.SaveChangesAsync();
            return employee;
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var employee = await GetEmployeeByIdAsync(id);
            employee.IsActive = false;
            await _dataContext.SaveChangesAsync();
        }

        public async Task<List<Employee>> GetEmployeeAsync()
        {
            return await _dataContext.EmployeeList
                                 .Include(e => e.Positions)
                                    
                                 .Where(e => e.IsActive)
                                 .ToListAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _dataContext.EmployeeList.Include(e => e.Positions)
                .FirstOrDefaultAsync(em => em.Id == id);
            
        }

        public async Task<Employee> UpdateEmployeeAsync(int id, Employee employee)
        {
            var existEmployee = await GetEmployeeByIdAsync(id);
            _dataContext.Entry(existEmployee).CurrentValues.SetValues(existEmployee);
            await _dataContext.SaveChangesAsync();
            return employee;
        }
    }
}
