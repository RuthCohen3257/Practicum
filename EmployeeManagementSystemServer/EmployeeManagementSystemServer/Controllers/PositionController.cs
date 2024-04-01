using AutoMapper;
using EmployeeSystem.API.Models;
using EmployeeSystem.Core.DTOs;
using EmployeeSystem.Core.Entities;
using EmployeeSystem.Core.Services;
using EmployeeSystem.Service.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly IPositionService _positionService;
        private readonly IMapper _mapper;
        public PositionController(IPositionService positionService,IMapper mapper)
        {
            _positionService = positionService;
            _mapper = mapper;
        }
        // GET: api/<PositionController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var p = await _positionService.GetPositionAsync();
            return Ok(_mapper.Map<IEnumerable<PositionDto>>(p));
        }

        // GET api/<PositionController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var position = await _positionService.GetPositionByIdAsync(id);
            if (position is null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<PositionDto>(position));
        }

        // POST api/<PositionController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PositionPostModel position)
        {
            var newPo = await _positionService.AddPositionAsync(_mapper.Map<Position>(position));
            return Ok(_mapper.Map<PositionDto>(newPo));
        }

        // PUT api/<PositionController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] PositionPostModel position)
        {
            var emp = await _positionService.GetPositionByIdAsync(id);
            if (emp is null)
            {
                return NotFound();
            }
            _mapper.Map(position, emp);
            await _positionService.UpdatePositionAsync(emp.Id, emp);
            emp = await _positionService.GetPositionByIdAsync(id);
            return Ok(_mapper.Map<EmployeeDto>(emp));
        }

        // DELETE api/<PositionController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var category = await _positionService.GetPositionByIdAsync(id);
            if (category is null)
            {
                return NotFound();
            }
            await _positionService.DeletePositionAsync(id);
            return NoContent();
        }
    }
}
