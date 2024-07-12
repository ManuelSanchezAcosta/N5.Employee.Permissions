using Employee.Permissions.Domain.Dtos.Requests.Permissions;
using FluentValidation;

namespace Employee.Permissions.Application.Handlers.Permission.Commands.Create
{
    public class PermissionCreateCommandValidator : AbstractValidator<PermissionCreateRequestDto>
    {
        public PermissionCreateCommandValidator()
        {
            RuleFor(r => r.IdEmployee).NotEmpty();
            RuleFor(r => r.IdPermissionType).NotEmpty();
        }
    }
}
