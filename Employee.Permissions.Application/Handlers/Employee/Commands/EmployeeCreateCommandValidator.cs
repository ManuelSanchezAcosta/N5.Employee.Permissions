using Employee.Permissions.Domain.Dtos.Requests.Employees;
using FluentValidation;

namespace Employee.Permissions.Application.Handlers.Employee.Commands
{
    public class EmployeeCreateCommandValidator : AbstractValidator<EmployeeCreateRequestDto>
    {
        public EmployeeCreateCommandValidator()
        {
            RuleFor(r => r.Name).NotEmpty().MaximumLength(50);
            RuleFor(r => r.LastName).NotEmpty().MaximumLength(50);
            RuleFor(r => r.Email).NotEmpty().MaximumLength(255).EmailAddress();
        }
    }
}
