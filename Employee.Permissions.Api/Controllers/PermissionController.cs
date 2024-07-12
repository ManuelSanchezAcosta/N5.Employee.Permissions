using AutoMapper;
using Employee.Permissions.Domain.Dtos.Requests.Permissions;
using Employee.Permissions.Domain.Dtos.Responses.Employees;
using Employee.Permissions.Domain.Dtos.Responses.Permissions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Permissions.Api.Controllers
{

    [Route("[controller]/[action]")]
    public class PermissionController : ApiController
    {

        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public PermissionController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper;
        }

        [HttpGet]
        [ActionName("Permission-GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var employeesResult = await _mediator.Send(new PermissionResponseGetAllDto());

            return employeesResult.Match(
                employees => Ok(employees),
                errors => Problem(errors)
            );
        }

        [HttpPost]
        [ActionName("Permission-Create")]
        public async Task<IActionResult> Create([FromBody] PermissionCreateRequestDto request)
        {
            var createResult = await _mediator.Send(request);

            return createResult.Match(
                employeeId => Ok(employeeId),
                errors => Problem(errors)
            );
        }

        [HttpDelete]
        [ActionName("Permission-Delete")]
        public async Task<IActionResult> Delete([FromBody] PermissionDeleteRequestDto request)
        {
            var createResult = await _mediator.Send(request);

            return createResult.Match(
                employeeId => Ok(employeeId),
                errors => Problem(errors)
            );
        }

    }
}
