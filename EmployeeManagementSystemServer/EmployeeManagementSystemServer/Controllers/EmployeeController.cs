using AutoMapper;
using EmployeeSystem.API.Models;
using EmployeeSystem.Core.DTOs;
using EmployeeSystem.Core.Entities;
using EmployeeSystem.Core.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeeController(IMapper mapper,IEmployeeService employeeService)
        { 
            _mapper = mapper;
            _employeeService = employeeService;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var employees = await _employeeService.GetEmployeeAsync();
            return Ok(_mapper.Map<IEnumerable<EmployeeDto>>(employees));
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee is null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<Employee>(employee));
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EmployeePostModel employee)
        {

            var newEmp = await _employeeService.AddEmployeeAsync(_mapper.Map<Employee>(employee));
            return Ok(_mapper.Map<EmployeeDto>(newEmp));
        }
        
        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] EmployeePostModel employee)
        {
            var emp = await _employeeService.GetEmployeeByIdAsync(id);
            if (emp is null)
            {
                return NotFound();
            }
            _mapper.Map(employee, emp);
            await _employeeService.UpdateEmployeeAsync(emp.Id, emp);
            emp = await _employeeService.GetEmployeeByIdAsync(id);
            return Ok(_mapper.Map<EmployeeDto>(emp));
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var category = await _employeeService.GetEmployeeByIdAsync(id);
            if (category is null)
            {
                return NotFound();
            }
            await _employeeService.DeleteEmployeeAsync(id);
            return NoContent();
        }
    }
}
