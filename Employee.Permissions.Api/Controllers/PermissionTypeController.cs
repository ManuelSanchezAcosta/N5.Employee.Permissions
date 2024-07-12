using Employee.Permissions.Domain.Dtos.Requests.PermissionTypes;
using Employee.Permissions.Domain.Dtos.Responses.PermissionTypes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Permissions.Api.Controllers
{

    [Route("[controller]/[action]")]
    public class PermissionTypeController : ApiController
    {
        private readonly ISender _mediator;

        public PermissionTypeController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }


        [HttpGet]
        [ActionName("PermissionType-GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var permissionTypesResult = await _mediator.Send(new PermissionTypeResponseGetAllDto());

            return permissionTypesResult.Match(
                permissionTypes => Ok(permissionTypes),
                errors => Problem(errors)
            );
        }

        [HttpPost]
        [ActionName("PermissionType-Create")]
        public async Task<IActionResult> Create([FromBody] PermissonTypeCreateRequestDto command)
        {
            var createResult = await _mediator.Send(command);

            return createResult.Match(
                employeeId => Ok(employeeId),
                errors => Problem(errors)
            );
        }
    }
}
