﻿using EmployeeSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Core.Repositories
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetEmployeeAsync();

        Task<Employee> GetEmployeeByIdAsync(int id);

        Task<Employee> AddEmployeeAsync(Employee employee);

        Task<Employee> UpdateEmployeeAsync(int id, Employee employee);

        Task DeleteEmployeeAsync(int id);
    }
}
