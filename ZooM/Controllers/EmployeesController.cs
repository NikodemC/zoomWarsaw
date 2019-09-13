using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZooM.Application.Commands.Dispatchers;
using ZooM.Application.Commands.Employees;
using ZooM.Application.DTO;
using ZooM.Application.Queries.Dispatchers;
using ZooM.Application.Queries.Employees;

namespace ZooM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public EmployeesController(ICommandDispatcher dispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = dispatcher;
            _queryDispatcher = queryDispatcher;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> SearchAsync([FromQuery] SearchEmployees query)
        {
            var result = await _queryDispatcher
                .DispatchAsync<SearchEmployees, IEnumerable<EmployeeDto>>(query);

            if (result is null || !result.Any()) return NotFound();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> GetByIdAsync([FromRoute] GetEmployee query)
        {
            var result = await _queryDispatcher.DispatchAsync<GetEmployee, EmployeeDto>(query);

            if (result is null) return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployeeAsync([FromBody] CreateEmployee command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = command.Id }, command);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            await _commandDispatcher.DispatchAsync(new DeleteEmployee(id));
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateEmployee command)
        {
            command.Bind(cmd => cmd.Id, id);
            await _commandDispatcher.DispatchAsync(command);
            return Ok();
        }
    }
}
