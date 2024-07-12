using Microsoft.AspNetCore.Mvc;
using MediatR;
using Employee.Permissions.Domain.Dtos.Responses.Employees;
using Employee.Permissions.Domain.Dtos.Requests.Employees;

namespace Employee.Permissions.Api.Controllers
{

    [Route("[controller]/[action]")]
    public class EmployeeController : ApiController
    {
        private readonly ISender _mediator;

        public EmployeeController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }


        [HttpGet]
        [ActionName("Employee-GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var employeesResult = await _mediator.Send(new EmployeeResponseGetAllDto());

            return employeesResult.Match(
                employees => Ok(employees),
                errors => Problem(errors)
            );
        }

        [HttpPost]
        [ActionName("Employee-Create")]
        public async Task<IActionResult> Create([FromBody] EmployeeCreateRequestDto command)
        {
            var createResult = await _mediator.Send(command);

            return createResult.Match(
                employeeId => Ok(employeeId),
                errors => Problem(errors)
            );
        }

    }
}
