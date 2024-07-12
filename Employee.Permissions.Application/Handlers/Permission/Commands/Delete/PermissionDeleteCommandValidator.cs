using Employee.Permissions.Domain.Dtos.Requests.Permissions;
using FluentValidation;

namespace Employee.Permissions.Application.Handlers.Permission.Commands.Delete
{
    public class PermissionDeleteCommandValidator : AbstractValidator<PermissionDeleteRequestDto>
    {
        public PermissionDeleteCommandValidator()
        {
            RuleFor(r => r.IdEmployee).NotEmpty();
            RuleFor(r => r.IdPermissionType).NotEmpty();            
        }
    }
}
