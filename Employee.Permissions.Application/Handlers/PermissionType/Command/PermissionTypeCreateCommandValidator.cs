using Employee.Permissions.Domain.Dtos.Requests.PermissionTypes;
using FluentValidation;

namespace Employee.Permissions.Application.Handlers.PermissionType.Command
{
    public class PermissionTypeCreateCommandValidator : AbstractValidator<PermissonTypeCreateRequestDto>
    {
        public PermissionTypeCreateCommandValidator()
        {
            RuleFor(r => r.Description).NotEmpty().MaximumLength(50);
        }
    }
}
